using System.Data;
using Microsoft.Data.SqlClient;
using OOP_Hospital_Schedule_Management.Models;

namespace OOP_Hospital_Schedule_Management.Repositories;

/// <summary>Persists appointments and supplies the data used by the scheduling view.</summary>
public sealed class AppointmentRepository
{
    public DataTable GetPatients()
    {
        const string sql = "SELECT patient_id, full_name FROM Patients ORDER BY full_name";
        var table = new DataTable();
        using var connection = Db.GetConnection();
        using var adapter = new SqlDataAdapter(sql, connection);
        adapter.Fill(table);
        return table;
    }

    public DataTable GetDoctors()
    {
        const string sql = "SELECT doctor_id, full_name FROM Doctors ORDER BY full_name";
        var table = new DataTable();
        using var connection = Db.GetConnection();
        using var adapter = new SqlDataAdapter(sql, connection);
        adapter.Fill(table);
        return table;
    }

    public DataTable GetSchedules(DateTime date)
    {
        const string sql = @"
            SELECT a.appointment_id AS ID,
                   a.patient_id, a.doctor_id,
                   p.full_name AS Patient,
                   d.full_name AS Doctor,
                   a.appointment_date AS [Date],
                   a.appointment_time AS [Time],
                   a.status AS Status
            FROM Appointments a
            JOIN Patients p ON p.patient_id = a.patient_id
            LEFT JOIN Doctors d ON d.doctor_id = a.doctor_id
            WHERE a.appointment_date = @date
            ORDER BY a.appointment_time";

        var table = new DataTable();
        using var connection = Db.GetConnection();
        using var command = new SqlCommand(sql, connection);
        command.Parameters.Add("@date", SqlDbType.Date).Value = date.Date;
        using var adapter = new SqlDataAdapter(command);
        adapter.Fill(table);
        return table;
    }

    public void Create(AppointmentScheduleRequest request, int staffUserId)
    {
        using var connection = Db.GetConnection();
        connection.Open();
        using var transaction = connection.BeginTransaction(IsolationLevel.Serializable);
        try
        {
            EnsureSlotAvailable(connection, transaction, request, appointmentId: null);
            const string sql = @"
                INSERT INTO Appointments
                    (patient_id, department_id, doctor_id, created_by,
                     appointment_date, appointment_time, status)
                SELECT @patient, d.department_id, d.doctor_id, @staff,
                       @date, @time, 'Scheduled'
                FROM Doctors d
                WHERE d.doctor_id = @doctor
                  AND EXISTS (SELECT 1 FROM Patients p WHERE p.patient_id = @patient)";
            using var command = new SqlCommand(sql, connection, transaction);
            AddAppointmentParameters(command, request);
            command.Parameters.Add("@staff", SqlDbType.Int).Value = staffUserId;
            if (command.ExecuteNonQuery() == 0)
                throw new InvalidAppointmentException("Select an existing patient and doctor.");
            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public bool Reschedule(int appointmentId, AppointmentScheduleRequest request)
    {
        using var connection = Db.GetConnection();
        connection.Open();
        using var transaction = connection.BeginTransaction(IsolationLevel.Serializable);
        try
        {
            EnsureSlotAvailable(connection, transaction, request, appointmentId);
            const string sql = @"
                UPDATE a
                SET patient_id = @patient,
                    doctor_id = d.doctor_id,
                    department_id = d.department_id,
                    appointment_date = @date,
                    appointment_time = @time
                FROM Appointments a
                JOIN Doctors d ON d.doctor_id = @doctor
                WHERE a.appointment_id = @id
                  AND a.status = 'Scheduled'
                  AND EXISTS (SELECT 1 FROM Patients p WHERE p.patient_id = @patient)";
            using var command = new SqlCommand(sql, connection, transaction);
            AddAppointmentParameters(command, request);
            command.Parameters.Add("@id", SqlDbType.Int).Value = appointmentId;
            bool updated = command.ExecuteNonQuery() > 0;
            transaction.Commit();
            return updated;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public bool Cancel(int appointmentId)
    {
        const string sql = @"
            UPDATE Appointments
            SET status = 'Cancelled'
            WHERE appointment_id = @id AND status = 'Scheduled'";
        using var connection = Db.GetConnection();
        using var command = new SqlCommand(sql, connection);
        command.Parameters.Add("@id", SqlDbType.Int).Value = appointmentId;
        connection.Open();
        return command.ExecuteNonQuery() > 0;
    }

    private static void EnsureSlotAvailable(
        SqlConnection connection,
        SqlTransaction transaction,
        AppointmentScheduleRequest request,
        int? appointmentId)
    {
        const string sql = @"
            SELECT COUNT(*)
            FROM Appointments WITH (UPDLOCK, HOLDLOCK)
            WHERE (doctor_id = @doctor OR patient_id = @patient)
              AND appointment_date = @date
              AND appointment_time = @time
              AND status <> 'Cancelled'
              AND (@id IS NULL OR appointment_id <> @id)";
        using var command = new SqlCommand(sql, connection, transaction);
        AddAppointmentParameters(command, request);
        command.Parameters.Add("@id", SqlDbType.Int).Value = appointmentId.HasValue ? appointmentId.Value : DBNull.Value;
        if (Convert.ToInt32(command.ExecuteScalar()) > 0)
            throw new ScheduleConflictException();
    }

    private static void AddAppointmentParameters(SqlCommand command, AppointmentScheduleRequest request)
    {
        command.Parameters.Add("@patient", SqlDbType.Int).Value = request.PatientId;
        command.Parameters.Add("@doctor", SqlDbType.Int).Value = request.DoctorId;
        command.Parameters.Add("@date", SqlDbType.Date).Value = request.StartsAt.Date;
        command.Parameters.Add("@time", SqlDbType.Time).Value = request.StartsAt.TimeOfDay;
    }
}

public sealed class ScheduleConflictException : Exception
{
    public ScheduleConflictException() : base("The patient or doctor already has an appointment at this date and time.") { }
}

public sealed class InvalidAppointmentException(string message) : Exception(message) { }
