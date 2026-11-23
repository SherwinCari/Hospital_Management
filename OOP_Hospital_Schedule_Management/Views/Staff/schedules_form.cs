using OOP_Hospital_Schedule_Management.Controllers;
using OOP_Hospital_Schedule_Management.Models;
using OOP_Hospital_Schedule_Management.Repositories;

namespace OOP_Hospital_Schedule_Management
{
    public partial class schedules_form : Form
    {
        private readonly int _staffUserId;
        private readonly ScheduleController _controller;

        // Parameterless constructor supports the WinForms designer.
        public schedules_form() : this(0, new ScheduleController(new AppointmentRepository())) { }

        public schedules_form(int staffUserId, ScheduleController controller)
        {
            InitializeComponent();
            _staffUserId = staffUserId;
            _controller = controller;

            Load += (s, e) => { LoadCombos(); LoadSchedules(); };
            btnRefresh.Click += (s, e) => LoadSchedules();
            dtpDate.ValueChanged += (s, e) => LoadSchedules();
            btnAdd.Click += (s, e) => AddSchedule();
            btnUpdate.Click += (s, e) => UpdateSchedule();
            btnDelete.Click += (s, e) => CancelSchedule();
            dgvSchedules.SelectionChanged += (s, e) => FillInputs();
            cmbStatus.Enabled = false; // Lifecycle status is changed by check-in/visit workflows.
            btnDelete.Text = "Cancel";
        }

        private void LoadCombos()
        {
            try
            {
                cmbStatus.Items.Clear();
                cmbStatus.Items.AddRange(new object[] { "Scheduled", "Checked-in", "Completed", "Cancelled", "No-show" });
                cmbStatus.SelectedIndex = 0;

                cmbPatient.DisplayMember = "full_name";
                cmbPatient.ValueMember = "patient_id";
                cmbPatient.DataSource = _controller.GetPatients();

                cmbDoctor.DisplayMember = "full_name";
                cmbDoctor.ValueMember = "doctor_id";
                cmbDoctor.DataSource = _controller.GetDoctors();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load patient and doctor lists: " + ex.Message);
            }
        }

        private void LoadSchedules()
        {
            try
            {
                dgvSchedules.DataSource = _controller.GetSchedules(dtpDate.Value.Date);
                if (dgvSchedules.Columns.Contains("patient_id")) dgvSchedules.Columns["patient_id"].Visible = false;
                if (dgvSchedules.Columns.Contains("doctor_id")) dgvSchedules.Columns["doctor_id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load appointments: " + ex.Message);
            }
        }

        private void FillInputs()
        {
            var row = dgvSchedules.CurrentRow;
            if (row == null || !dgvSchedules.Columns.Contains("patient_id")) return;
            if (row.Cells["ID"].Value == null || row.Cells["ID"].Value == DBNull.Value) return;

            cmbPatient.SelectedValue = Convert.ToInt32(row.Cells["patient_id"].Value);
            if (row.Cells["doctor_id"].Value == DBNull.Value)
                cmbDoctor.SelectedIndex = -1;
            else
                cmbDoctor.SelectedValue = Convert.ToInt32(row.Cells["doctor_id"].Value);
            cmbStatus.SelectedItem = row.Cells["Status"].Value?.ToString();
            if (row.Cells["Time"].Value is TimeSpan time)
                dtpTime.Value = DateTime.Today.Add(time);
        }

        private void AddSchedule()
        {
            try
            {
                ScheduleActionResult result = _controller.Create(BuildRequest(), _staffUserId);
                ShowResult(result);
                if (result.IsSuccess) LoadSchedules();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to schedule the appointment: " + ex.Message);
            }
        }

        private void UpdateSchedule()
        {
            if (!TryGetSelectedAppointmentId(out int appointmentId))
            {
                MessageBox.Show("Select an appointment first.");
                return;
            }

            try
            {
                ScheduleActionResult result = _controller.Reschedule(appointmentId, BuildRequest());
                ShowResult(result);
                if (result.IsSuccess) LoadSchedules();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to update the appointment: " + ex.Message);
            }
        }

        private void CancelSchedule()
        {
            if (!TryGetSelectedAppointmentId(out int appointmentId))
            {
                MessageBox.Show("Select an appointment first.");
                return;
            }
            if (MessageBox.Show("Cancel this scheduled appointment?", "Confirm cancellation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                ScheduleActionResult result = _controller.Cancel(appointmentId);
                ShowResult(result);
                if (result.IsSuccess) LoadSchedules();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to cancel the appointment: " + ex.Message);
            }
        }

        private AppointmentScheduleRequest BuildRequest()
        {
            int patientId = cmbPatient.SelectedValue is null ? 0 : Convert.ToInt32(cmbPatient.SelectedValue);
            int doctorId = cmbDoctor.SelectedValue is null ? 0 : Convert.ToInt32(cmbDoctor.SelectedValue);
            DateTime startsAt = dtpDate.Value.Date.Add(dtpTime.Value.TimeOfDay);
            return new AppointmentScheduleRequest(patientId, doctorId, startsAt);
        }

        private bool TryGetSelectedAppointmentId(out int appointmentId)
        {
            appointmentId = 0;
            var row = dgvSchedules.CurrentRow;
            if (row == null || !dgvSchedules.Columns.Contains("ID") ||
                row.Cells["ID"].Value == null || row.Cells["ID"].Value == DBNull.Value)
                return false;
            appointmentId = Convert.ToInt32(row.Cells["ID"].Value);
            return appointmentId > 0;
        }

        private static void ShowResult(ScheduleActionResult result)
        {
            MessageBox.Show(result.Message, "Appointments", MessageBoxButtons.OK,
                result.IsSuccess ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }
    }
}
