using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace OOP_Hospital_Schedule_Management
{
    public partial class doctor_main_ui : Form
    {
        private readonly int _doctorId;
        private readonly string _doctorName;
        private readonly int _departmentId;
        private readonly string _departmentName;

        public doctor_main_ui(int doctorId, string doctorName, int departmentId, string departmentName)
        {
            InitializeComponent();
            _doctorId = doctorId;
            _doctorName = doctorName;
            _departmentId = departmentId;
            _departmentName = departmentName;

            welcomeLbl.Text = "Welcome, " + _doctorName + " - " + _departmentName;
            scheduledLbl.Text = _departmentName + " Patients (returning)";
            newPatientsLbl.Text = "New " + _departmentName + " Patients (first visit)";

            scheduledGrid.CellClick += Grid_CellClick;
            newPatientsGrid.CellClick += Grid_CellClick;

            datePicker.Value = DateTime.Today;
            LoadTables();

            // reload whenever you switch back to this window (e.g. after staff registers a patient)
            this.Activated += (s, e) => LoadTables();
        }

        private void datePicker_ValueChanged(object sender, EventArgs e)
        {
            LoadTables();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Click a patient's NAME to open the patient popup
        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridView grid = (DataGridView)sender;
            if (grid.Columns[e.ColumnIndex].Name != "Patient") return;

            object aidValue = grid.Rows[e.RowIndex].Cells["appointment_id"].Value;
            int appointmentId = (aidValue == null || aidValue == DBNull.Value) ? 0 : Convert.ToInt32(aidValue);
            int patientId = Convert.ToInt32(grid.Rows[e.RowIndex].Cells["patient_id"].Value);

            using (patient_detail_form detail = new patient_detail_form(appointmentId, patientId, _doctorId, _departmentId))
            {
                detail.ShowDialog(this);
            }

            LoadTables(); // refresh statuses after the popup closes
        }

        private void LoadTables()
        {
            string statusCase = @"CASE a.status
                                      WHEN 'Scheduled'  THEN 'Not yet here'
                                      WHEN 'Checked-in' THEN 'Checked-in'
                                      WHEN 'Completed'  THEN 'Completed'
                                      WHEN 'Cancelled'  THEN 'Cancelled'
                                  END";

            // Table 1: RETURNING patients = has a record from a different appointment
            string returningSql = @"
                SELECT a.appointment_id, p.patient_id,
                       p.full_name AS [Patient],
                       CONVERT(VARCHAR(5), a.appointment_time, 108) AS [Time],
                       " + statusCase + @" AS [Status],
                       a.queue_number AS [Queue #],
                       d.full_name AS [Doctor]
                FROM Appointments a
                JOIN Patients p ON a.patient_id = p.patient_id
                JOIN Doctors d ON a.doctor_id = d.doctor_id
                WHERE a.department_id = @departmentId
                  AND a.appointment_date = @date
                  AND a.status IN ('Scheduled', 'Checked-in', 'Completed', 'Cancelled')
                  AND EXISTS (SELECT 1 FROM MedicalRecords r
                              WHERE r.patient_id = p.patient_id
                                AND r.appointment_id <> a.appointment_id)
                ORDER BY CASE a.status WHEN 'Checked-in' THEN 0
                                       WHEN 'Scheduled'  THEN 1
                                       WHEN 'Completed'  THEN 2
                                       ELSE 3 END,
                         a.queue_number, a.appointment_time";

            // Table 2: NEW patients
            //   (A) appointments of patients with no record from another appointment
            //   (B) patients registered in this department on the selected date with no appointment yet
            string newSql = @"
                SELECT * FROM (
                    SELECT a.appointment_id, p.patient_id,
                           p.full_name AS [Patient],
                           CONVERT(VARCHAR(5), a.appointment_time, 108) AS [Time],
                           " + statusCase + @" AS [Status],
                           a.queue_number AS [Queue #],
                           d.full_name AS [Doctor]
                    FROM Appointments a
                    JOIN Patients p ON a.patient_id = p.patient_id
                    JOIN Doctors d ON a.doctor_id = d.doctor_id
                    WHERE a.department_id = @departmentId
                      AND a.appointment_date = @date
                      AND a.status IN ('Scheduled', 'Checked-in', 'Completed', 'Cancelled')
                      AND NOT EXISTS (SELECT 1 FROM MedicalRecords r
                                      WHERE r.patient_id = p.patient_id
                                        AND r.appointment_id <> a.appointment_id)

                    UNION ALL

                    SELECT CAST(NULL AS INT), p.patient_id,
                           p.full_name,
                           CONVERT(VARCHAR(5), p.created_at, 108),
                           'Newly registered',
                           CAST(NULL AS INT),
                           '-'
                    FROM Patients p
                    WHERE p.department_id = @departmentId
                      AND CAST(p.created_at AS DATE) = @date
                      AND NOT EXISTS (SELECT 1 FROM Appointments x
                                      WHERE x.patient_id = p.patient_id
                                        AND x.department_id = @departmentId)
                      AND NOT EXISTS (SELECT 1 FROM MedicalRecords r
                                      WHERE r.patient_id = p.patient_id)
                ) AS t
                ORDER BY t.[Time]";

            try
            {
                scheduledGrid.DataSource = GetTable(returningSql);
                newPatientsGrid.DataSource = GetTable(newSql);

                HideIdColumns(scheduledGrid);
                HideIdColumns(newPatientsGrid);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }

        private DataTable GetTable(string sql)
        {
            DataTable table = new DataTable();
            using (SqlConnection conn = Db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@departmentId", _departmentId);
                cmd.Parameters.AddWithValue("@date", datePicker.Value.Date);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(table);
                }
            }
            return table;
        }

        private void HideIdColumns(DataGridView grid)
        {
            if (grid.Columns["appointment_id"] != null) grid.Columns["appointment_id"].Visible = false;
            if (grid.Columns["patient_id"] != null) grid.Columns["patient_id"].Visible = false;
        }
    }
}