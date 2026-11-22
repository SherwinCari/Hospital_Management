using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace OOP_Hospital_Schedule_Management.staff_tab
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

            string sql = @"SELECT user_id, full_name
                           FROM Users
                           WHERE username = @username
                             AND password = @password
                             AND role = 'Staff'";

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
                            int userId = reader.GetInt32(0);
                            string staffName = reader.GetString(1);

                            staff_main_ui staffForm = new staff_main_ui(userId, staffName);
                            staffForm.FormClosed += (s, args) => this.Close();
                            staffForm.Show();
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