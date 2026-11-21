using System;
using System.Windows.Forms;

namespace OOP_Hospital_Schedule_Management
{
    public partial class main_ui : Form
    {
        public main_ui()
        {
            InitializeComponent();
        }

        private void doctorBtn_Click(object sender, EventArgs e)
        {
            doctor_main_ui doctorForm = new doctor_main_ui();
            this.Hide();
            doctorForm.FormClosed += (s, args) => this.Show();
            doctorForm.Show();
        }

        private void staffBtn_Click(object sender, EventArgs e)
        {
            staff_main_ui staffForm = new staff_main_ui();
            this.Hide();
            staffForm.FormClosed += (s, args) => this.Show();
            staffForm.Show();
        }
    }
}