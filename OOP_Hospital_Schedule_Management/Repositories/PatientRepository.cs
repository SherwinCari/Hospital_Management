using System.Data;
using Microsoft.Data.SqlClient;

namespace OOP_Hospital_Schedule_Management;

/// <summary>SQL persistence for patient registration and directory queries.</summary>
public sealed class PatientRepository
{
    public DataTable GetDepartments()
    {
        var table = new DataTable();
        using var connection = Db.GetConnection();
        using var adapter = new SqlDataAdapter(
            "SELECT department_id, department_name FROM Departments ORDER BY department_name", connection);
        adapter.Fill(table);
        return table;
    }

    /// <summary>Creates a patient and their initial appointment atomically.</summary>
    public int RegisterAndQueue(Patient patient, int staffUserId)
    {
        using var connection = Db.GetConnection();
        connection.Open();
        using var transaction = connection.BeginTransaction(IsolationLevel.Serializable);
        try
        {
            const string duplicateSql = @"SELECT COUNT(*) FROM Patients WITH (UPDLOCK, HOLDLOCK)
                WHERE full_name = @name
                  AND ((birthdate IS NULL AND @birthdate IS NULL) OR birthdate = @birthdate)";
            using (var duplicate = new SqlCommand(duplicateSql, connection, transaction))
            {
                duplicate.Parameters.Add("@name", SqlDbType.NVarChar, 200).Value = patient.FullName;
                duplicate.Parameters.Add("@birthdate", SqlDbType.Date).Value = DbValue(patient.Birthdate);
                if (Convert.ToInt32(duplicate.ExecuteScalar()) > 0)
                    throw new DuplicatePatientException();
            }

            const string patientSql = @"
                INSERT INTO Patients
                    (full_name, birthdate, contact_no, address, blood_type, allergies,
                     existing_conditions, emergency_contact_name, emergency_contact_no,
                     department_id, problem_description)
                OUTPUT INSERTED.patient_id
                VALUES (@name, @birthdate, @contact, @address, @blood, @allergies,
                        @conditions, @emergencyName, @emergencyNo, @department, @problem)";
            int patientId;
            using (var insert = new SqlCommand(patientSql, connection, transaction))
            {
                insert.Parameters.Add("@name", SqlDbType.NVarChar, 200).Value = patient.FullName;
                insert.Parameters.Add("@birthdate", SqlDbType.Date).Value = DbValue(patient.Birthdate);
                AddText(insert, "@contact", patient.ContactNo, 50);
                AddText(insert, "@address", patient.Address, 500);
                AddText(insert, "@blood", patient.BloodType, 10);
                AddText(insert, "@allergies", patient.Allergies, -1);
                AddText(insert, "@conditions", patient.ExistingConditions, -1);
                AddText(insert, "@emergencyName", patient.EmergencyContactName, 200);
                AddText(insert, "@emergencyNo", patient.EmergencyContactNo, 50);
                insert.Parameters.Add("@department", SqlDbType.Int).Value = patient.DepartmentId;
                AddText(insert, "@problem", patient.ProblemDescription, -1);
                patientId = Convert.ToInt32(insert.ExecuteScalar());
            }

            const string queueSql = @"
                INSERT INTO Appointments
                    (patient_id, department_id, created_by, appointment_date, appointment_time, status)
                VALUES (@patient, @department, @staff, CAST(GETDATE() AS DATE), CAST(GETDATE() AS TIME(0)), 'Scheduled')";
            using (var queue = new SqlCommand(queueSql, connection, transaction))
            {
                queue.Parameters.Add("@patient", SqlDbType.Int).Value = patientId;
                queue.Parameters.Add("@department", SqlDbType.Int).Value = patient.DepartmentId;
                queue.Parameters.Add("@staff", SqlDbType.Int).Value = staffUserId;
                queue.ExecuteNonQuery();
            }
            transaction.Commit();
            return patientId;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public DataTable Search(string query)
    {
        const string sql = @"
            SELECT patient_id AS [ID], full_name AS [Name],
                   CONVERT(VARCHAR(10), birthdate, 120) AS [Birthdate], contact_no AS [Contact],
                   address AS [Address], blood_type AS [Blood type], allergies AS [Allergies],
                   existing_conditions AS [Conditions], emergency_contact_name AS [Emergency contact],
                   emergency_contact_no AS [Emergency no.]
            FROM Patients
            WHERE full_name LIKE @query OR contact_no LIKE @query
            ORDER BY full_name";
        var table = new DataTable();
        using var connection = Db.GetConnection();
        using var command = new SqlCommand(sql, connection);
        command.Parameters.Add("@query", SqlDbType.NVarChar, 500).Value = $"%{query}%";
        using var adapter = new SqlDataAdapter(command);
        adapter.Fill(table);
        return table;
    }

    private static object DbValue(DateTime? value) => value.HasValue ? value.Value.Date : DBNull.Value;

    private static void AddText(SqlCommand command, string name, string? value, int size) =>
        command.Parameters.Add(name, SqlDbType.NVarChar, size).Value =
            string.IsNullOrWhiteSpace(value) ? DBNull.Value : value.Trim();
}

public sealed class DuplicatePatientException : Exception { }
