using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace OOP_Hospital_Schedule_Management.staff_tab
{
    public partial class search_patient_form : Form
    {
        public search_patient_form()
        {
            InitializeComponent();
        }

        private void search_patient_form_Load(object sender, EventArgs e)
        {
            SearchPatients();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            SearchPatients();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SearchPatients()
        {
            string sql = @"
                SELECT patient_id AS [ID],
                       full_name AS [Name],
                       CONVERT(VARCHAR(10), birthdate, 120) AS [Birthdate],
                       contact_no AS [Contact],
                       address AS [Address],
                       blood_type AS [Blood type],
                       allergies AS [Allergies],
                       existing_conditions AS [Conditions],
                       emergency_contact_name AS [Emergency contact],
                       emergency_contact_no AS [Emergency no.]
                FROM Patients
                WHERE full_name LIKE @q OR contact_no LIKE @q
                ORDER BY full_name";

            try
            {
                DataTable table = new DataTable();
                using (SqlConnection conn = Db.GetConnection())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@q", "%" + searchTxt.Text.Trim() + "%");
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }
                }

                resultsGrid.DataSource = table;
                countLbl.Text = table.Rows.Count + " patient(s) found";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }
    }
}