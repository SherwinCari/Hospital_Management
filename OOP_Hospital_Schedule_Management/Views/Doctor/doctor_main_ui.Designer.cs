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
            welcomeLbl.BackColor = Color.Transparent;
            welcomeLbl.Font = new Font("Airnt", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            welcomeLbl.ForeColor = Color.Teal;
            welcomeLbl.Location = new Point(34, 39);
            welcomeLbl.Margin = new Padding(2, 0, 2, 0);
            welcomeLbl.Name = "welcomeLbl";
            welcomeLbl.Size = new Size(163, 21);
            welcomeLbl.TabIndex = 0;
            welcomeLbl.Text = "Welcome !";
            //
            // dateLbl
            //
            dateLbl.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dateLbl.AutoSize = true;
            dateLbl.BackColor = Color.Transparent;
            dateLbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateLbl.ForeColor = Color.Teal;
            dateLbl.Location = new Point(322, 46);
            dateLbl.Margin = new Padding(2, 0, 2, 0);
            dateLbl.Name = "dateLbl";
            dateLbl.Size = new Size(53, 15);
            dateLbl.TabIndex = 1;
            dateLbl.Text = "Today is:";
            //
            // datePicker
            //
            datePicker.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            datePicker.Format = DateTimePickerFormat.Short;
            datePicker.Location = new Point(379, 43);
            datePicker.Margin = new Padding(2, 2, 2, 2);
            datePicker.Name = "datePicker";
            datePicker.Size = new Size(109, 23);
            datePicker.TabIndex = 2;
            datePicker.ValueChanged += datePicker_ValueChanged;
            //
            // logoutBtn
            //
            logoutBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            logoutBtn.BackColor = Color.Transparent;
            logoutBtn.ForeColor = Color.White;
            logoutBtn.Image = Properties.Resources.Button1;
            logoutBtn.Location = new Point(492, 39);
            logoutBtn.Margin = new Padding(2, 2, 2, 2);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Size = new Size(66, 27);
            logoutBtn.TabIndex = 3;
            logoutBtn.Text = "Logout";
            logoutBtn.UseVisualStyleBackColor = false;
            logoutBtn.Click += logoutBtn_Click;
            //
            // scheduledLbl
            //
            scheduledLbl.AutoSize = true;
            scheduledLbl.BackColor = Color.Transparent;
            scheduledLbl.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            scheduledLbl.ForeColor = Color.Teal;
            scheduledLbl.Location = new Point(34, 79);
            scheduledLbl.Margin = new Padding(2, 0, 2, 0);
            scheduledLbl.Name = "scheduledLbl";
            scheduledLbl.Size = new Size(123, 17);
            scheduledLbl.TabIndex = 4;
            scheduledLbl.Text = "Scheduled Patients";
            //
            // scheduledGrid
            //
            scheduledGrid.AllowUserToAddRows = false;
            scheduledGrid.AllowUserToDeleteRows = false;
            scheduledGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            scheduledGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            scheduledGrid.BackgroundColor = Color.White;
            scheduledGrid.BorderStyle = BorderStyle.Fixed3D;
            scheduledGrid.Location = new Point(34, 99);
            scheduledGrid.Margin = new Padding(2, 2, 2, 2);
            scheduledGrid.Name = "scheduledGrid";
            scheduledGrid.ReadOnly = true;
            scheduledGrid.RowHeadersVisible = false;
            scheduledGrid.RowHeadersWidth = 62;
            scheduledGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            scheduledGrid.Size = new Size(524, 220);
            scheduledGrid.TabIndex = 5;
            //
            // newPatientsLbl
            //
            newPatientsLbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            newPatientsLbl.AutoSize = true;
            newPatientsLbl.BackColor = Color.Transparent;
            newPatientsLbl.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            newPatientsLbl.ForeColor = Color.Teal;
            newPatientsLbl.Location = new Point(34, 322);
            newPatientsLbl.Margin = new Padding(2, 0, 2, 0);
            newPatientsLbl.Name = "newPatientsLbl";
            newPatientsLbl.Size = new Size(265, 17);
            newPatientsLbl.TabIndex = 6;
            newPatientsLbl.Text = "New Patients (no previous medical record)";
            //
            // newPatientsGrid
            //
            newPatientsGrid.AllowUserToAddRows = false;
            newPatientsGrid.AllowUserToDeleteRows = false;
            newPatientsGrid.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            newPatientsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            newPatientsGrid.BackgroundColor = Color.White;
            newPatientsGrid.BorderStyle = BorderStyle.Fixed3D;
            newPatientsGrid.Location = new Point(34, 342);
            newPatientsGrid.Margin = new Padding(2, 2, 2, 2);
            newPatientsGrid.Name = "newPatientsGrid";
            newPatientsGrid.ReadOnly = true;
            newPatientsGrid.RowHeadersVisible = false;
            newPatientsGrid.RowHeadersWidth = 62;
            newPatientsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            newPatientsGrid.Size = new Size(524, 123);
            newPatientsGrid.TabIndex = 7;
            //
            // doctor_main_ui
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.BG2;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(592, 499);
            Controls.Add(welcomeLbl);
            Controls.Add(dateLbl);
            Controls.Add(datePicker);
            Controls.Add(logoutBtn);
            Controls.Add(scheduledLbl);
            Controls.Add(scheduledGrid);
            Controls.Add(newPatientsLbl);
            Controls.Add(newPatientsGrid);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2, 2, 2, 2);
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