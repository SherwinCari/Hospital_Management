using System;
using System.Windows.Forms;

namespace OOP_Hospital_Schedule_Management.staff_tab
{
    public partial class staff_main_ui : Form
    {
        private readonly int _userId;
        private readonly string _staffName;
        private readonly OOP_Hospital_Schedule_Management.Controllers.ScheduleController _scheduleController;

        public staff_main_ui(int userId, string staffName)
        {
            InitializeComponent();
            _userId = userId;
            _staffName = staffName;
            _scheduleController = new OOP_Hospital_Schedule_Management.Controllers.ScheduleController(
                new OOP_Hospital_Schedule_Management.Repositories.AppointmentRepository());
            Text = "Staff - " + _staffName;
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            using (register_patient_form form = new register_patient_form(_userId))
            {
                form.ShowDialog(this);
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            using (search_patient_form form = new search_patient_form())
            {
                form.ShowDialog(this);
            }
        }

        private void scheduleBtn_Click(object sender, EventArgs e)
        {
            using (schedules_form form = new schedules_form(_userId, _scheduleController))
            {
                form.ShowDialog(this);
            }
        }

        private void requestBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming soon.");
        }
    }
}
