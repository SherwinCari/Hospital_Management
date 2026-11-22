namespace OOP_Hospital_Schedule_Management
{
    partial class record_history_form
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
            diagnosisLbl = new Label();
            diagnosisTxt = new TextBox();
            prescriptionLbl = new Label();
            prescriptionTxt = new TextBox();
            notesLbl = new Label();
            notesTxt = new TextBox();
            followUpChk = new CheckBox();
            followUpDate = new DateTimePicker();
            saveBtn = new Button();
            cancelBtn = new Button();
            label1 = new Label();
            SuspendLayout();
            //
            // diagnosisLbl
            //
            diagnosisLbl.AutoSize = true;
            diagnosisLbl.BackColor = Color.Transparent;
            diagnosisLbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            diagnosisLbl.ForeColor = Color.Teal;
            diagnosisLbl.Location = new Point(41, 73);
            diagnosisLbl.Margin = new Padding(2, 0, 2, 0);
            diagnosisLbl.Name = "diagnosisLbl";
            diagnosisLbl.Size = new Size(59, 15);
            diagnosisLbl.TabIndex = 0;
            diagnosisLbl.Text = "Diagnosis";
            //
            // diagnosisTxt
            //
            diagnosisTxt.Location = new Point(41, 89);
            diagnosisTxt.Margin = new Padding(2, 2, 2, 2);
            diagnosisTxt.MaxLength = 200;
            diagnosisTxt.Name = "diagnosisTxt";
            diagnosisTxt.Size = new Size(365, 23);
            diagnosisTxt.TabIndex = 0;
            //
            // prescriptionLbl
            //
            prescriptionLbl.AutoSize = true;
            prescriptionLbl.BackColor = Color.Transparent;
            prescriptionLbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            prescriptionLbl.ForeColor = Color.Teal;
            prescriptionLbl.Location = new Point(41, 118);
            prescriptionLbl.Margin = new Padding(2, 0, 2, 0);
            prescriptionLbl.Name = "prescriptionLbl";
            prescriptionLbl.Size = new Size(70, 15);
            prescriptionLbl.TabIndex = 1;
            prescriptionLbl.Text = "Prescription";
            //
            // prescriptionTxt
            //
            prescriptionTxt.Location = new Point(41, 134);
            prescriptionTxt.Margin = new Padding(2, 2, 2, 2);
            prescriptionTxt.MaxLength = 300;
            prescriptionTxt.Name = "prescriptionTxt";
            prescriptionTxt.Size = new Size(365, 23);
            prescriptionTxt.TabIndex = 1;
            //
            // notesLbl
            //
            notesLbl.AutoSize = true;
            notesLbl.BackColor = Color.Transparent;
            notesLbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            notesLbl.ForeColor = Color.Teal;
            notesLbl.Location = new Point(41, 163);
            notesLbl.Margin = new Padding(2, 0, 2, 0);
            notesLbl.Name = "notesLbl";
            notesLbl.Size = new Size(216, 15);
            notesLbl.TabIndex = 2;
            notesLbl.Text = "Notes (what happened in the check-up)";
            //
            // notesTxt
            //
            notesTxt.Location = new Point(41, 179);
            notesTxt.Margin = new Padding(2, 2, 2, 2);
            notesTxt.Multiline = true;
            notesTxt.Name = "notesTxt";
            notesTxt.ScrollBars = ScrollBars.Vertical;
            notesTxt.Size = new Size(365, 116);
            notesTxt.TabIndex = 2;
            //
            // followUpChk
            //
            followUpChk.AutoSize = true;
            followUpChk.BackColor = Color.Transparent;
            followUpChk.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            followUpChk.ForeColor = Color.Teal;
            followUpChk.Location = new Point(41, 307);
            followUpChk.Margin = new Padding(2, 2, 2, 2);
            followUpChk.Name = "followUpChk";
            followUpChk.Size = new Size(106, 19);
            followUpChk.TabIndex = 3;
            followUpChk.Text = "Follow-up date";
            followUpChk.UseVisualStyleBackColor = false;
            followUpChk.CheckedChanged += followUpChk_CheckedChanged;
            //
            // followUpDate
            //
            followUpDate.Enabled = false;
            followUpDate.Format = DateTimePickerFormat.Short;
            followUpDate.Location = new Point(167, 302);
            followUpDate.Margin = new Padding(2, 2, 2, 2);
            followUpDate.Name = "followUpDate";
            followUpDate.Size = new Size(141, 23);
            followUpDate.TabIndex = 4;
            //
            // saveBtn
            //
            saveBtn.FlatAppearance.BorderSize = 0;
            saveBtn.FlatStyle = FlatStyle.Flat;
            saveBtn.Font = new Font("Consolas", 9F, FontStyle.Bold);
            saveBtn.ForeColor = Color.White;
            saveBtn.Image = Properties.Resources.Button1;
            saveBtn.Location = new Point(41, 346);
            saveBtn.Margin = new Padding(2, 2, 2, 2);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(175, 30);
            saveBtn.TabIndex = 5;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            //
            // cancelBtn
            //
            cancelBtn.DialogResult = DialogResult.Cancel;
            cancelBtn.FlatAppearance.BorderSize = 0;
            cancelBtn.FlatStyle = FlatStyle.Flat;
            cancelBtn.Font = new Font("Consolas", 9F, FontStyle.Bold);
            cancelBtn.ForeColor = Color.White;
            cancelBtn.Image = Properties.Resources.Button1;
            cancelBtn.Location = new Point(230, 346);
            cancelBtn.Margin = new Padding(2, 2, 2, 2);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(175, 30);
            cancelBtn.TabIndex = 6;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            //
            // label1
            //
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Airnt", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Teal;
            label1.Location = new Point(101, 28);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(259, 21);
            label1.TabIndex = 0;
            label1.Text = "RECORD HISTORY";
            //
            // record_history_form
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            BackgroundImage = Properties.Resources.BG2;
            BackgroundImageLayout = ImageLayout.Stretch;
            CancelButton = cancelBtn;
            ClientSize = new Size(446, 406);
            Controls.Add(label1);
            Controls.Add(diagnosisLbl);
            Controls.Add(diagnosisTxt);
            Controls.Add(prescriptionLbl);
            Controls.Add(prescriptionTxt);
            Controls.Add(notesLbl);
            Controls.Add(notesTxt);
            Controls.Add(followUpChk);
            Controls.Add(followUpDate);
            Controls.Add(saveBtn);
            Controls.Add(cancelBtn);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2, 2, 2, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "record_history_form";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Record check-up history";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label diagnosisLbl;
        private TextBox diagnosisTxt;
        private Label prescriptionLbl;
        private TextBox prescriptionTxt;
        private Label notesLbl;
        private TextBox notesTxt;
        private CheckBox followUpChk;
        private DateTimePicker followUpDate;
        private Button saveBtn;
        private Button cancelBtn;
        private Label label1;
    }
}