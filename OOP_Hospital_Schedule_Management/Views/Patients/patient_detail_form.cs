using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace OOP_Hospital_Schedule_Management
{
    public partial class patient_detail_form : Form
    {
        private readonly int _appointmentId;
        private readonly int _patientId;
        private readonly int _doctorId;
        private readonly int _departmentId;
        private string _status = "";
        private int? _assignedDoctorId;
        private string _assignedDoctorName = "";

        public patient_detail_form(int appointmentId, int patientId, int doctorId, int departmentId)
        {
            InitializeComponent();
            _appointmentId = appointmentId;
            _patientId = patientId;
            _doctorId = doctorId;
            _departmentId = departmentId;

            historyGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void patient_detail_form_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private static string S(SqlDataReader r, int i)
        {
            return r.IsDBNull(i) ? "-" : r.GetValue(i).ToString();
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = Db.GetConnection())
                {
                    conn.Open();

                    // 1) Patient info - allowed if the appointment is in the doctor's department,
                    //    or the patient was registered in the doctor's department
                    string patientSql = @"
                        SELECT p.full_name, p.birthdate, p.contact_no, p.address, p.blood_type,
                               p.allergies, p.existing_conditions, p.emergency_contact_name,
                               p.emergency_contact_no, a.status, p.problem_description,
                               a.doctor_id, d.full_name
                        FROM Patients p
                        LEFT JOIN Appointments a
                               ON a.appointment_id = @aid
                              AND a.patient_id = p.patient_id
                              AND a.department_id = @dep
                        LEFT JOIN Doctors d ON d.doctor_id = a.doctor_id
                        WHERE p.patient_id = @pid
                          AND (a.appointment_id IS NOT NULL OR p.department_id = @dep)";

                    using (SqlCommand cmd = new SqlCommand(patientSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@aid", _appointmentId);
                        cmd.Parameters.AddWithValue("@pid", _patientId);
                        cmd.Parameters.AddWithValue("@dep", _departmentId);

                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            if (!r.Read())
                            {
                                MessageBox.Show("You can't access this patient.");
                                this.Close();
                                return;
                            }

                            string birth = "-";
                            if (!r.IsDBNull(1))
                            {
                                DateTime bd = r.GetDateTime(1);
                                int age = DateTime.Today.Year - bd.Year;
                                if (bd.Date > DateTime.Today.AddYears(-age)) age--;
                                birth = bd.ToString("MMM d, yyyy") + " (age " + age + ")";
                            }

                            nameLbl.Text = r.GetString(0);
                            infoLbl.Text =
                                "Birthdate: " + birth + "     Contact: " + S(r, 2) + "\n" +
                                "Address: " + S(r, 3) + "\n" +
                                "Blood type: " + S(r, 4) + "     Allergies: " + S(r, 5) + "\n" +
                                "Existing conditions: " + S(r, 6) + "\n" +
                                "Emergency contact: " + S(r, 7) + " (" + S(r, 8) + ")";
                            _status = r.IsDBNull(9) ? "Not yet scheduled" : r.GetString(9);
                            problemTxt.Text = r.IsDBNull(10) ? "No description entered." : r.GetString(10);
                            _assignedDoctorId = r.IsDBNull(11) ? (int?)null : r.GetInt32(11);
                            _assignedDoctorName = r.IsDBNull(12) ? "" : r.GetString(12);
                        }
                    }

                    // 2) Header + buttons depend on status and assigned doctor
                    string doctorText = _appointmentId == 0 ? "" :
                        (_assignedDoctorId == null ? "  -  Waiting for a doctor" : "  -  Doctor: " + _assignedDoctorName);
                    nurseTitleLbl.Text = "Nurse summary (this visit)  -  Status: " + _status + doctorText;

                    // only a waiting patient (no doctor yet) can be taken
                    startBtn.Enabled = (_status == "Scheduled" && _assignedDoctorId == null);

                    nurseLbl.Text = "No vitals recorded yet (patient hasn't been checked in).";

                    string vitalsSql = @"SELECT blood_pressure, temperature_c, pulse_rate, weight_kg, chief_complaint
                                         FROM Vitals WHERE appointment_id = @aid";
                    using (SqlCommand cmd = new SqlCommand(vitalsSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@aid", _appointmentId);
                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                nurseLbl.Text =
                                    "BP: " + S(r, 0) + "     Temp: " + S(r, 1) + " C     Pulse: " + S(r, 2) + "     Weight: " + S(r, 3) + " kg\n" +
                                    "Chief complaint: " + S(r, 4);
                            }
                        }
                    }

                    // 3) Returning = has a medical record from a different appointment
                    bool isReturning;
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT COUNT(*) FROM MedicalRecords WHERE patient_id = @pid AND appointment_id <> @aid", conn))
                    {
                        cmd.Parameters.AddWithValue("@pid", _patientId);
                        cmd.Parameters.AddWithValue("@aid", _appointmentId);
                        isReturning = (int)cmd.ExecuteScalar() > 0;
                    }

                    // 4) Record history
                    string historySql = @"
                        SELECT CONVERT(VARCHAR(10), appointment_date, 120) AS [Date],
                               department_name AS [Department],
                               doctor_name AS [Doctor],
                               chief_complaint AS [Complaint],
                               blood_pressure AS [BP],
                               temperature_c AS [Temp],
                               pulse_rate AS [Pulse],
                               weight_kg AS [Weight],
                               diagnosis AS [Diagnosis],
                               prescription AS [Prescription],
                               notes AS [Notes],
                               CONVERT(VARCHAR(10), follow_up_date, 120) AS [Follow-up]
                        FROM vw_PatientVisitHistory
                        WHERE patient_id = @pid AND record_id IS NOT NULL
                        ORDER BY appointment_date DESC, record_id DESC";

                    DataTable history = new DataTable();
                    using (SqlCommand cmd = new SqlCommand(historySql, conn))
                    {
                        cmd.Parameters.AddWithValue("@pid", _patientId);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(history);
                        }
                    }
                    historyGrid.DataSource = history;

                    if (isReturning)
                        historyTitleLbl.Text = "Previous visits (record history)";
                    else if (history.Rows.Count > 0)
                        historyTitleLbl.Text = "First visit - record saved";
                    else
                        historyTitleLbl.Text = "First visit - no previous records (see nurse summary above)";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }

        // The doctor who presses this becomes the assigned doctor
        private void startBtn_Click(object sender, EventArgs e)
        {
            // doctor_id IS NULL in the WHERE makes this safe if two doctors click at once:
            // only one UPDATE can match, the other one affects 0 rows
            string sql = @"
                UPDATE Appointments
                SET doctor_id = @doc,
                    status = 'Checked-in',
                    checked_in_at = GETDATE(),
                    queue_number = (SELECT ISNULL(MAX(queue_number), 0) + 1
                                    FROM Appointments
                                    WHERE doctor_id = @doc
                                      AND appointment_date = CAST(GETDATE() AS DATE))
                WHERE appointment_id = @aid
                  AND department_id = @dep
                  AND doctor_id IS NULL
                  AND status = 'Scheduled'";

            try
            {
                using (SqlConnection conn = Db.GetConnection())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@doc", _doctorId);
                    cmd.Parameters.AddWithValue("@aid", _appointmentId);
                    cmd.Parameters.AddWithValue("@dep", _departmentId);
                    conn.Open();

                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        MessageBox.Show("Another doctor already took this patient.");
                    }
                }

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }

        private void recordBtn_Click(object sender, EventArgs e)
        {
            if (_status == "Not yet scheduled")
            {
                MessageBox.Show("This patient has no appointment yet.");
                return;
            }
            if (_status == "Cancelled" || _status == "No-show")
            {
                MessageBox.Show("This appointment was cancelled.");
                return;
            }
            if (_status == "Completed")
            {
                MessageBox.Show("This visit already has a saved record.");
                return;
            }
            if (_assignedDoctorId == null)
            {
                MessageBox.Show("Press Start check-up first. A doctor must be assigned before recording.");
                return;
            }
            if (_assignedDoctorId != _doctorId)
            {
                MessageBox.Show("This patient is assigned to " + _assignedDoctorName + ".");
                return;
            }
            if (_status == "Scheduled")
            {
                MessageBox.Show("This patient hasn't checked in yet.");
                return;
            }

            using (record_history_form form = new record_history_form(_appointmentId, _patientId, _doctorId, _departmentId))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }
    }
}