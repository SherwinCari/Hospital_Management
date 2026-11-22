using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace OOP_Hospital_Schedule_Management.doctor_tab
{
    public partial class login_form : Form
    {
        public login_form()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            errorLbl.Text = "";

            if (string.IsNullOrWhiteSpace(usernameTxt.Text) || string.IsNullOrWhiteSpace(passwordTxt.Text))
            {
                errorLbl.Text = "Enter username and password.";
                return;
            }

            string sql = @"SELECT d.doctor_id, u.full_name, d.department_id, dep.department_name
                   FROM Users u
                   JOIN Doctors d ON d.user_id = u.user_id
                   JOIN Departments dep ON dep.department_id = d.department_id
                   WHERE u.username = @username
                     AND u.password = @password
                     AND u.role = 'Doctor'";

            try
            {
                using (SqlConnection conn = Db.GetConnection())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@username", usernameTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", passwordTxt.Text);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Doctor doctor = new Doctor(
                                reader.GetInt32(0),    // doctor_id
                                reader.GetString(1),   // full_name
                                reader.GetInt32(2),    // department_id
                                reader.GetString(3));  // department_name

                            doctor_main_ui doctorForm = new doctor_main_ui(doctor);
                            doctorForm.FormClosed += (s, args) => this.Close();
                            doctorForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            errorLbl.Text = "Invalid username or password.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }
    }
}