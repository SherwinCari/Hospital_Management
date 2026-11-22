namespace OOP_Hospital_Schedule_Management
{
    partial class schedules_form
    {
        private System.ComponentModel.IContainer? components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlTop = new Panel();
            lblDate = new Label();
            dtpDate = new DateTimePicker();
            btnRefresh = new Button();
            dgvSchedules = new DataGridView();
            pnlBottom = new Panel();
            lblPatient = new Label();
            cmbPatient = new ComboBox();
            lblDoctor = new Label();
            cmbDoctor = new ComboBox();
            lblTime = new Label();
            dtpTime = new DateTimePicker();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();

            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSchedules).BeginInit();
            pnlBottom.SuspendLayout();
            SuspendLayout();

            pnlTop.Controls.Add(lblDate);
            pnlTop.Controls.Add(dtpDate);
            pnlTop.Controls.Add(btnRefresh);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(800, 50);

            lblDate.AutoSize = true;
            lblDate.Location = new Point(12, 16);
            lblDate.Name = "lblDate";
            lblDate.Text = "Date";

            dtpDate.Format = DateTimePickerFormat.Long;
            dtpDate.Location = new Point(60, 12);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(200, 27);

            btnRefresh.Location = new Point(280, 11);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(90, 29);
            btnRefresh.Text = "Refresh";

            dgvSchedules.AllowUserToAddRows = false;
            dgvSchedules.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSchedules.Dock = DockStyle.Fill;
            dgvSchedules.MultiSelect = false;
            dgvSchedules.Name = "dgvSchedules";
            dgvSchedules.ReadOnly = true;
            dgvSchedules.RowHeadersVisible = false;
            dgvSchedules.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            pnlBottom.Controls.Add(lblPatient);
            pnlBottom.Controls.Add(cmbPatient);
            pnlBottom.Controls.Add(lblDoctor);
            pnlBottom.Controls.Add(cmbDoctor);
            pnlBottom.Controls.Add(lblTime);
            pnlBottom.Controls.Add(dtpTime);
            pnlBottom.Controls.Add(lblStatus);
            pnlBottom.Controls.Add(cmbStatus);
            pnlBottom.Controls.Add(btnAdd);
            pnlBottom.Controls.Add(btnUpdate);
            pnlBottom.Controls.Add(btnDelete);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(800, 130);

            lblPatient.AutoSize = true;
            lblPatient.Location = new Point(12, 8);
            lblPatient.Name = "lblPatient";
            lblPatient.Text = "Patient";

            cmbPatient.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPatient.Location = new Point(12, 28);
            cmbPatient.Name = "cmbPatient";
            cmbPatient.Size = new Size(220, 28);

            lblDoctor.AutoSize = true;
            lblDoctor.Location = new Point(244, 8);
            lblDoctor.Name = "lblDoctor";
            lblDoctor.Text = "Doctor";

            cmbDoctor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDoctor.Location = new Point(244, 28);
            cmbDoctor.Name = "cmbDoctor";
            cmbDoctor.Size = new Size(220, 28);

            lblTime.AutoSize = true;
            lblTime.Location = new Point(476, 8);
            lblTime.Name = "lblTime";
            lblTime.Text = "Time";

            dtpTime.Format = DateTimePickerFormat.Time;
            dtpTime.Location = new Point(476, 28);
            dtpTime.Name = "dtpTime";
            dtpTime.ShowUpDown = true;
            dtpTime.Size = new Size(110, 27);

            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(598, 8);
            lblStatus.Name = "lblStatus";
            lblStatus.Text = "Status";

            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Location = new Point(598, 28);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(180, 28);

            btnAdd.Location = new Point(12, 76);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(90, 32);
            btnAdd.Text = "Add";

            btnUpdate.Location = new Point(112, 76);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(90, 32);
            btnUpdate.Text = "Update";

            btnDelete.Location = new Point(212, 76);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(90, 32);
            btnDelete.Text = "Delete";

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 540);
            Controls.Add(dgvSchedules);
            Controls.Add(pnlBottom);
            Controls.Add(pnlTop);
            Name = "schedules_form";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Schedules";

            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSchedules).EndInit();
            pnlBottom.ResumeLayout(false);
            pnlBottom.PerformLayout();
            ResumeLayout(false);
        }

        private Panel pnlTop;
        private Label lblDate;
        private DateTimePicker dtpDate;
        private Button btnRefresh;
        private DataGridView dgvSchedules;
        private Panel pnlBottom;
        private Label lblPatient;
        private ComboBox cmbPatient;
        private Label lblDoctor;
        private ComboBox cmbDoctor;
        private Label lblTime;
        private DateTimePicker dtpTime;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
    }
}