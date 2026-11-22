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
            this.Hide();
            OOP_Hospital_Schedule_Management.doctor_tab.login_form login = new OOP_Hospital_Schedule_Management.doctor_tab.login_form();
            login.FormClosed += (s, args) => this.Show();
            login.Show();
        }

        private void staffBtn_Click(object sender, EventArgs e)
        {
            OOP_Hospital_Schedule_Management.staff_tab.login_form staffForm = new OOP_Hospital_Schedule_Management.staff_tab.login_form();
            this.Hide();
            staffForm.FormClosed += (s, args) => this.Show();
            staffForm.Show();
        }
    }
}