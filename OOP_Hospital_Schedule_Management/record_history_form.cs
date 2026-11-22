using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace OOP_Hospital_Schedule_Management
{
    public partial class record_history_form : Form
    {
        private readonly int _appointmentId;
        private readonly int _patientId;
        private readonly int _doctorId;
        private readonly int _departmentId;

        public record_history_form(int appointmentId, int patientId, int doctorId, int departmentId)
        {
            InitializeComponent();
            _appointmentId = appointmentId;
            _patientId = patientId;
            _doctorId = doctorId;
            _departmentId = departmentId;

            followUpDate.MinDate = DateTime.Today;
            followUpDate.Value = DateTime.Today.AddDays(7);
        }

        private void followUpChk_CheckedChanged(object sender, EventArgs e)
        {
            followUpDate.Enabled = followUpChk.Checked;
        }

        private static object Nz(string text)
        {
            return string.IsNullOrWhiteSpace(text) ? (object)DBNull.Value : text.Trim();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(diagnosisTxt.Text) && string.IsNullOrWhiteSpace(notesTxt.Text))
            {
                MessageBox.Show("Enter a diagnosis or notes.");
                return;
            }

            try
            {
                using (SqlConnection conn = Db.GetConnection())
                {
                    conn.Open();
                    using (SqlTransaction tx = conn.BeginTransaction())
                    {
                        string insertSql = @"
                            INSERT INTO MedicalRecords
                                (appointment_id, patient_id, recorded_by, diagnosis, prescription, notes, follow_up_date)
                            VALUES (@aid, @pid, @doc, @dx, @rx, @notes, @fu)";

                        using (SqlCommand cmd = new SqlCommand(insertSql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@aid", _appointmentId);
                            cmd.Parameters.AddWithValue("@pid", _patientId);
                            cmd.Parameters.AddWithValue("@doc", _doctorId);
                            cmd.Parameters.AddWithValue("@dx", Nz(diagnosisTxt.Text));
                            cmd.Parameters.AddWithValue("@rx", Nz(prescriptionTxt.Text));
                            cmd.Parameters.AddWithValue("@notes", Nz(notesTxt.Text));
                            cmd.Parameters.AddWithValue("@fu", followUpChk.Checked ? (object)followUpDate.Value.Date : DBNull.Value);
                            cmd.ExecuteNonQuery();
                        }

                        string updateSql = @"UPDATE Appointments SET status = 'Completed'
                                             WHERE appointment_id = @aid AND department_id = @dep AND status = 'Checked-in'";
                        using (SqlCommand cmd = new SqlCommand(updateSql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@aid", _appointmentId);
                            cmd.Parameters.AddWithValue("@dep", _departmentId);
                            if (cmd.ExecuteNonQuery() == 0)
                            {
                                tx.Rollback();
                                MessageBox.Show("Could not save: the appointment is no longer checked in.");
                                return;
                            }
                        }

                        tx.Commit();
                    }
                }

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }
    }
}