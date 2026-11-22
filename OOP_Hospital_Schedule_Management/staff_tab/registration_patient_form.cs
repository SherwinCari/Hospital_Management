using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace OOP_Hospital_Schedule_Management.staff_tab
{
    public partial class register_patient_form : Form
    {
        private readonly int _staffUserId;

        public register_patient_form(int staffUserId)
        {
            InitializeComponent();
            _staffUserId = staffUserId;
            birthdateDtp.MaxDate = DateTime.Today;
            bloodTypeCmb.SelectedIndex = 0;
            LoadDepartments();
        }

        // empty text becomes a database NULL
        private static object Nz(string text)
        {
            return string.IsNullOrWhiteSpace(text) ? (object)DBNull.Value : text.Trim();
        }

        private void LoadDepartments()
        {
            try
            {
                DataTable table = new DataTable();
                using (SqlConnection conn = Db.GetConnection())
                using (SqlDataAdapter adapter = new SqlDataAdapter(
                    "SELECT department_id, department_name FROM Departments ORDER BY department_name", conn))
                {
                    adapter.Fill(table);
                }

                departmentCmb.DataSource = table;
                departmentCmb.DisplayMember = "department_name";
                departmentCmb.ValueMember = "department_id";
                departmentCmb.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (departmentCmb.SelectedValue == null)
            {
                MessageBox.Show("Select a department.");
                return;
            }

            // 1) Fill the Patient object (its setters check the rules)
            Patient patient;
            try
            {
                patient = new Patient(fullNameTxt.Text);
                patient.Birthdate = birthdateDtp.Checked ? (DateTime?)birthdateDtp.Value : null;
                patient.BloodType = bloodTypeCmb.Text;
                patient.ContactNo = contactTxt.Text;
                patient.Address = addressTxt.Text;
                patient.Allergies = allergiesTxt.Text;
                patient.ExistingConditions = conditionsTxt.Text;
                patient.EmergencyContactName = ecNameTxt.Text;
                patient.EmergencyContactNo = ecNoTxt.Text;
                patient.DepartmentId = Convert.ToInt32(departmentCmb.SelectedValue);
                patient.ProblemDescription = problemTxt.Text;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            // 2) Save the patient AND add them to today's department queue (one transaction)
            try
            {
                using (SqlConnection conn = Db.GetConnection())
                {
                    conn.Open();

                    // already registered? (same name + birthdate)
                    string dupSql = @"SELECT COUNT(*) FROM Patients
                                      WHERE full_name = @name
                                        AND ((birthdate IS NULL AND @bd IS NULL) OR birthdate = @bd)";
                    using (SqlCommand cmd = new SqlCommand(dupSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", patient.FullName);
                        cmd.Parameters.Add("@bd", SqlDbType.Date).Value = (object)patient.Birthdate ?? DBNull.Value;

                        if ((int)cmd.ExecuteScalar() > 0)
                        {
                            MessageBox.Show("A patient with this name and birthdate is already registered.");
                            return;
                        }
                    }

                    using (SqlTransaction tx = conn.BeginTransaction())
                    {
                        // a) save the patient
                        string insertSql = @"
                            INSERT INTO Patients
                                (full_name, birthdate, contact_no, address, blood_type, allergies,
                                 existing_conditions, emergency_contact_name, emergency_contact_no,
                                 department_id, problem_description)
                            OUTPUT INSERTED.patient_id
                            VALUES
                                (@name, @bd, @contact, @address, @blood, @allergies,
                                 @conditions, @ecName, @ecNo, @dep, @problem)";

                        int patientId;
                        using (SqlCommand cmd = new SqlCommand(insertSql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@name", patient.FullName);
                            cmd.Parameters.Add("@bd", SqlDbType.Date).Value = (object)patient.Birthdate ?? DBNull.Value;
                            cmd.Parameters.AddWithValue("@contact", Nz(patient.ContactNo));
                            cmd.Parameters.AddWithValue("@address", Nz(patient.Address));
                            cmd.Parameters.AddWithValue("@blood", Nz(patient.BloodType));
                            cmd.Parameters.AddWithValue("@allergies", Nz(patient.Allergies));
                            cmd.Parameters.AddWithValue("@conditions", Nz(patient.ExistingConditions));
                            cmd.Parameters.AddWithValue("@ecName", Nz(patient.EmergencyContactName));
                            cmd.Parameters.AddWithValue("@ecNo", Nz(patient.EmergencyContactNo));
                            cmd.Parameters.AddWithValue("@dep", patient.DepartmentId);
                            cmd.Parameters.AddWithValue("@problem", Nz(patient.ProblemDescription));
                            patientId = (int)cmd.ExecuteScalar();
                        }

                        // b) join today's queue: NO doctor yet (the doctor who takes them is assigned later)
                        string apptSql = @"
                            INSERT INTO Appointments
                                (patient_id, department_id, created_by,
                                 appointment_date, appointment_time, status)
                            VALUES
                                (@pid, @dep, @staff,
                                 CAST(GETDATE() AS DATE), CAST(GETDATE() AS TIME(0)), 'Scheduled')";

                        using (SqlCommand cmd = new SqlCommand(apptSql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@pid", patientId);
                            cmd.Parameters.AddWithValue("@dep", patient.DepartmentId);
                            cmd.Parameters.AddWithValue("@staff", _staffUserId);
                            cmd.ExecuteNonQuery();
                        }

                        tx.Commit();
                    }
                }

                MessageBox.Show("Patient registered and added to the " + departmentCmb.Text + " queue.");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }
    }
}