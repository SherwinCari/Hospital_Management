namespace OOP_Hospital_Schedule_Management
{
    partial class doctor_main_ui
    {
        private System.ComponentModel.IContainer components = null;

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
            welcomeLbl = new Label();
            dateLbl = new Label();
            datePicker = new DateTimePicker();
            logoutBtn = new Button();
            scheduledLbl = new Label();
            scheduledGrid = new DataGridView();
            newPatientsLbl = new Label();
            newPatientsGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)scheduledGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)newPatientsGrid).BeginInit();
            SuspendLayout();
            // 
            // welcomeLbl
            // 
            welcomeLbl.AutoSize = true;
            welcomeLbl.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            welcomeLbl.Location = new Point(20, 15);
            welcomeLbl.Name = "welcomeLbl";
            welcomeLbl.Text = "Welcome";
            // 
            // dateLbl
            // 
            dateLbl.AutoSize = true;
            dateLbl.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dateLbl.Location = new Point(590, 20);
            dateLbl.Name = "dateLbl";
            dateLbl.Text = "Date:";
            // 
            // datePicker
            // 
            datePicker.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            datePicker.Format = DateTimePickerFormat.Short;
            datePicker.Location = new Point(660, 15);
            datePicker.Name = "datePicker";
            datePicker.Size = new Size(210, 31);
            datePicker.ValueChanged += datePicker_ValueChanged;
            // 
            // logoutBtn
            // 
            logoutBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            logoutBtn.Location = new Point(885, 12);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Size = new Size(95, 36);
            logoutBtn.Text = "Logout";
            logoutBtn.UseVisualStyleBackColor = true;
            logoutBtn.Click += logoutBtn_Click;
            // 
            // scheduledLbl
            // 
            scheduledLbl.AutoSize = true;
            scheduledLbl.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            scheduledLbl.Location = new Point(20, 65);
            scheduledLbl.Name = "scheduledLbl";
            scheduledLbl.Text = "Scheduled Patients";
            // 
            // scheduledGrid
            // 
            scheduledGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            scheduledGrid.AllowUserToAddRows = false;
            scheduledGrid.AllowUserToDeleteRows = false;
            scheduledGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            scheduledGrid.ReadOnly = true;
            scheduledGrid.RowHeadersVisible = false;
            scheduledGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            scheduledGrid.Location = new Point(20, 95);
            scheduledGrid.Name = "scheduledGrid";
            scheduledGrid.RowHeadersWidth = 62;
            scheduledGrid.Size = new Size(960, 270);
            // 
            // newPatientsLbl
            // 
            newPatientsLbl.AutoSize = true;
            newPatientsLbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            newPatientsLbl.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            newPatientsLbl.Location = new Point(20, 385);
            newPatientsLbl.Name = "newPatientsLbl";
            newPatientsLbl.Text = "New Patients (no previous medical record)";
            // 
            // newPatientsGrid
            // 
            newPatientsGrid.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            newPatientsGrid.AllowUserToAddRows = false;
            newPatientsGrid.AllowUserToDeleteRows = false;
            newPatientsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            newPatientsGrid.ReadOnly = true;
            newPatientsGrid.RowHeadersVisible = false;
            newPatientsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            newPatientsGrid.Location = new Point(20, 415);
            newPatientsGrid.Name = "newPatientsGrid";
            newPatientsGrid.RowHeadersWidth = 62;
            newPatientsGrid.Size = new Size(960, 250);
            // 
            // doctor_main_ui
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 690);
            Controls.Add(welcomeLbl);
            Controls.Add(dateLbl);
            Controls.Add(datePicker);
            Controls.Add(logoutBtn);
            Controls.Add(scheduledLbl);
            Controls.Add(scheduledGrid);
            Controls.Add(newPatientsLbl);
            Controls.Add(newPatientsGrid);
            Name = "doctor_main_ui";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Doctor";
            ((System.ComponentModel.ISupportInitialize)scheduledGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)newPatientsGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label welcomeLbl;
        private Label dateLbl;
        private DateTimePicker datePicker;
        private Button logoutBtn;
        private Label scheduledLbl;
        private DataGridView scheduledGrid;
        private Label newPatientsLbl;
        private DataGridView newPatientsGrid;
    }
}