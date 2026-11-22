using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace OOP_Hospital_Schedule_Management.staff_tab
{
    public partial class register_patient_form : Form
    {
        public register_patient_form()
        {
            InitializeComponent();
            birthdateDtp.MaxDate = DateTime.Today;
            bloodTypeCmb.SelectedIndex = 0;
            LoadDepartments();
        }

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
            string name = fullNameTxt.Text.Trim();
            if (name == "")
            {
                MessageBox.Show("Full name is required.");
                return;
            }

            if (departmentCmb.SelectedValue == null)
            {
                MessageBox.Show("Select a department.");
                return;
            }

            object birth = birthdateDtp.Checked ? (object)birthdateDtp.Value.Date : DBNull.Value;

            try
            {
                using (SqlConnection conn = Db.GetConnection())
                {
                    conn.Open();

                    // Duplicate check: same name + same birthdate
                    string dupSql = @"SELECT COUNT(*) FROM Patients
                                      WHERE full_name = @name
                                        AND ((birthdate IS NULL AND @bd IS NULL) OR birthdate = @bd)";
                    using (SqlCommand cmd = new SqlCommand(dupSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.Add("@bd", SqlDbType.Date).Value = birth;

                        if ((int)cmd.ExecuteScalar() > 0)
                        {
                            MessageBox.Show("A patient with this name and birthdate is already registered.");
                            return;
                        }
                    }

                    string insertSql = @"
                        INSERT INTO Patients
                            (full_name, birthdate, contact_no, address, blood_type, allergies,
                             existing_conditions, emergency_contact_name, emergency_contact_no,
                             department_id, problem_description)
                        VALUES
                            (@name, @bd, @contact, @address, @blood, @allergies,
                             @conditions, @ecName, @ecNo, @dep, @problem)";

                    using (SqlCommand cmd = new SqlCommand(insertSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.Add("@bd", SqlDbType.Date).Value = birth;
                        cmd.Parameters.AddWithValue("@contact", Nz(contactTxt.Text));
                        cmd.Parameters.AddWithValue("@address", Nz(addressTxt.Text));
                        cmd.Parameters.AddWithValue("@blood", Nz(bloodTypeCmb.Text));
                        cmd.Parameters.AddWithValue("@allergies", Nz(allergiesTxt.Text));
                        cmd.Parameters.AddWithValue("@conditions", Nz(conditionsTxt.Text));
                        cmd.Parameters.AddWithValue("@ecName", Nz(ecNameTxt.Text));
                        cmd.Parameters.AddWithValue("@ecNo", Nz(ecNoTxt.Text));
                        cmd.Parameters.AddWithValue("@dep", departmentCmb.SelectedValue);
                        cmd.Parameters.AddWithValue("@problem", Nz(problemTxt.Text));
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Patient registered.");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }
    }
}