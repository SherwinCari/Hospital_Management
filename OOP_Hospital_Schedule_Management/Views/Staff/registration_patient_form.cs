using System;
using System.Windows.Forms;
using OOP_Hospital_Schedule_Management.Controllers;

namespace OOP_Hospital_Schedule_Management.staff_tab
{
    public partial class register_patient_form : Form
    {
        private readonly int _staffUserId;
        private readonly PatientController _controller = new(new PatientRepository());

        public register_patient_form(int staffUserId)
        {
            InitializeComponent();
            _staffUserId = staffUserId;
            birthdateDtp.MaxDate = DateTime.Today;
            bloodTypeCmb.SelectedIndex = 0;
            LoadDepartments();
        }

        private void LoadDepartments()
        {
            try
            {
                var table = _controller.GetDepartments();

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

            try
            {
                PatientActionResult result = _controller.Register(patient, _staffUserId);
                if (!result.IsSuccess)
                {
                    MessageBox.Show(result.Message);
                    return;
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
