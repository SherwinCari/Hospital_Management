using System;
using System.Windows.Forms;
using OOP_Hospital_Schedule_Management.Controllers;

namespace OOP_Hospital_Schedule_Management.staff_tab
{
    public partial class search_patient_form : Form
    {
        private readonly PatientController _controller = new(new PatientRepository());
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
            try
            {
                var table = _controller.Search(searchTxt.Text);
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
