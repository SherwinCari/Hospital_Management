using System.Data;
using Microsoft.Data.SqlClient;

namespace OOP_Hospital_Schedule_Management
{
    public partial class schedules_form : Form
    {
        public schedules_form()
        {
            InitializeComponent();

            Load += (s, e) => { LoadCombos(); LoadSchedules(); };
            btnRefresh.Click += (s, e) => LoadSchedules();
            dtpDate.ValueChanged += (s, e) => LoadSchedules();
            btnAdd.Click += (s, e) => AddSchedule();
            btnUpdate.Click += (s, e) => UpdateSchedule();
            btnDelete.Click += (s, e) => DeleteSchedule();
            dgvSchedules.SelectionChanged += (s, e) => FillInputs();
        }

        private void LoadCombos()
        {
            try
            {
                cmbStatus.Items.Clear();
                cmbStatus.Items.AddRange(new object[] { "Scheduled", "Checked-in", "Completed", "Cancelled", "No-show" });
                cmbStatus.SelectedIndex = 0;

                using var conn = Db.GetConnection();

                var patients = new DataTable();
                new SqlDataAdapter("SELECT patient_id, full_name FROM Patients ORDER BY full_name", conn).Fill(patients);
                cmbPatient.DisplayMember = "full_name";
                cmbPatient.ValueMember = "patient_id";
                cmbPatient.DataSource = patients;

                var doctors = new DataTable();
                new SqlDataAdapter("SELECT doctor_id, full_name FROM Doctors ORDER BY full_name", conn).Fill(doctors);
                cmbDoctor.DisplayMember = "full_name";
                cmbDoctor.ValueMember = "doctor_id";
                cmbDoctor.DataSource = doctors;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading lists: " + ex.Message);
            }
        }

        private void LoadSchedules()
        {
            try
            {
                using var conn = Db.GetConnection();
                using var cmd = new SqlCommand(@"
                    SELECT a.appointment_id AS ID,
                           a.patient_id, a.doctor_id,
                           p.full_name AS Patient,
                           d.full_name AS Doctor,
                           a.appointment_date AS [Date],
                           a.appointment_time AS [Time],
                           a.status AS Status
                    FROM Appointments a
                    JOIN Patients p ON a.patient_id = p.patient_id
                    JOIN Doctors d ON a.doctor_id = d.doctor_id
                    WHERE a.appointment_date = @date
                    ORDER BY a.appointment_time", conn);
                cmd.Parameters.AddWithValue("@date", dtpDate.Value.Date);

                var dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                dgvSchedules.DataSource = dt;

                if (dgvSchedules.Columns.Contains("patient_id")) dgvSchedules.Columns["patient_id"].Visible = false;
                if (dgvSchedules.Columns.Contains("doctor_id")) dgvSchedules.Columns["doctor_id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading schedules: " + ex.Message);
            }
        }

        private void FillInputs()
        {
            var row = dgvSchedules.CurrentRow;
            if (row == null || !dgvSchedules.Columns.Contains("patient_id")) return;
            if (row.Cells["ID"].Value == null || row.Cells["ID"].Value == DBNull.Value) return;

            cmbPatient.SelectedValue = Convert.ToInt32(row.Cells["patient_id"].Value);
            cmbDoctor.SelectedValue = Convert.ToInt32(row.Cells["doctor_id"].Value);
            cmbStatus.SelectedItem = row.Cells["Status"].Value?.ToString();
            if (row.Cells["Time"].Value is TimeSpan ts)
                dtpTime.Value = DateTime.Today.Add(ts);
        }

        private void AddSchedule()
        {
            if (cmbPatient.SelectedValue == null || cmbDoctor.SelectedValue == null)
            {
                MessageBox.Show("Pumili ng patient at doctor.");
                return;
            }

            try
            {
                using var conn = Db.GetConnection();
                using var cmd = new SqlCommand(@"
                    INSERT INTO Appointments
                        (patient_id, department_id, doctor_id, created_by, appointment_date, appointment_time, status)
                    SELECT @p, d.department_id, d.doctor_id,
                           (SELECT TOP 1 user_id FROM Users WHERE role = 'Staff'),
                           @date, @time, @status
                    FROM Doctors d WHERE d.doctor_id = @d", conn);
                cmd.Parameters.AddWithValue("@p", cmbPatient.SelectedValue);
                cmd.Parameters.AddWithValue("@d", cmbDoctor.SelectedValue);
                cmd.Parameters.AddWithValue("@date", dtpDate.Value.Date);
                cmd.Parameters.AddWithValue("@time", dtpTime.Value.TimeOfDay);
                cmd.Parameters.AddWithValue("@status", cmbStatus.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                LoadSchedules();
            }
            catch (SqlException ex) when (ex.Number == 2601 || ex.Number == 2627)
            {
                MessageBox.Show("May schedule na ang doctor sa oras na yan.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding schedule: " + ex.Message);
            }
        }

        private void UpdateSchedule()
        {
            var row = dgvSchedules.CurrentRow;
            if (row == null || row.Cells["ID"].Value == null || row.Cells["ID"].Value == DBNull.Value)
            {
                MessageBox.Show("Pumili muna ng schedule sa listahan.");
                return;
            }
            int id = Convert.ToInt32(row.Cells["ID"].Value);

            try
            {
                using var conn = Db.GetConnection();
                using var cmd = new SqlCommand(@"
                    UPDATE Appointments
                    SET patient_id = @p,
                        doctor_id = @d,
                        department_id = (SELECT department_id FROM Doctors WHERE doctor_id = @d),
                        appointment_date = @date,
                        appointment_time = @time,
                        status = @status
                    WHERE appointment_id = @id", conn);
                cmd.Parameters.AddWithValue("@p", cmbPatient.SelectedValue);
                cmd.Parameters.AddWithValue("@d", cmbDoctor.SelectedValue);
                cmd.Parameters.AddWithValue("@date", dtpDate.Value.Date);
                cmd.Parameters.AddWithValue("@time", dtpTime.Value.TimeOfDay);
                cmd.Parameters.AddWithValue("@status", cmbStatus.Text);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                LoadSchedules();
            }
            catch (SqlException ex) when (ex.Number == 2601 || ex.Number == 2627)
            {
                MessageBox.Show("May schedule na ang doctor sa oras na yan.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating schedule: " + ex.Message);
            }
        }

        private void DeleteSchedule()
        {
            var row = dgvSchedules.CurrentRow;
            if (row == null || row.Cells["ID"].Value == null || row.Cells["ID"].Value == DBNull.Value)
            {
                MessageBox.Show("Pumili muna ng schedule sa listahan.");
                return;
            }
            if (MessageBox.Show("Burahin ang schedule na ito?", "Confirm",
                MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            int id = Convert.ToInt32(row.Cells["ID"].Value);

            try
            {
                using var conn = Db.GetConnection();
                using var cmd = new SqlCommand("DELETE FROM Appointments WHERE appointment_id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                LoadSchedules();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting schedule: " + ex.Message);
            }
        }
    }
}
