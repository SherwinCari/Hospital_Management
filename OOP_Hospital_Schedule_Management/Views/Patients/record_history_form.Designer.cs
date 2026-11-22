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
            SuspendLayout();
            // 
            // diagnosisLbl
            // 
            diagnosisLbl.AutoSize = true;
            diagnosisLbl.Location = new Point(20, 15);
            diagnosisLbl.Name = "diagnosisLbl";
            diagnosisLbl.Text = "Diagnosis";
            // 
            // diagnosisTxt
            // 
            diagnosisTxt.Location = new Point(20, 42);
            diagnosisTxt.MaxLength = 200;
            diagnosisTxt.Name = "diagnosisTxt";
            diagnosisTxt.Size = new Size(520, 31);
            diagnosisTxt.TabIndex = 0;
            // 
            // prescriptionLbl
            // 
            prescriptionLbl.AutoSize = true;
            prescriptionLbl.Location = new Point(20, 90);
            prescriptionLbl.Name = "prescriptionLbl";
            prescriptionLbl.Text = "Prescription";
            // 
            // prescriptionTxt
            // 
            prescriptionTxt.Location = new Point(20, 117);
            prescriptionTxt.MaxLength = 300;
            prescriptionTxt.Name = "prescriptionTxt";
            prescriptionTxt.Size = new Size(520, 31);
            prescriptionTxt.TabIndex = 1;
            // 
            // notesLbl
            // 
            notesLbl.AutoSize = true;
            notesLbl.Location = new Point(20, 165);
            notesLbl.Name = "notesLbl";
            notesLbl.Text = "Notes (what happened in the check-up)";
            // 
            // notesTxt
            // 
            notesTxt.Location = new Point(20, 192);
            notesTxt.Multiline = true;
            notesTxt.Name = "notesTxt";
            notesTxt.ScrollBars = ScrollBars.Vertical;
            notesTxt.Size = new Size(520, 190);
            notesTxt.TabIndex = 2;
            // 
            // followUpChk
            // 
            followUpChk.AutoSize = true;
            followUpChk.Location = new Point(20, 400);
            followUpChk.Name = "followUpChk";
            followUpChk.TabIndex = 3;
            followUpChk.Text = "Follow-up date";
            followUpChk.UseVisualStyleBackColor = true;
            followUpChk.CheckedChanged += followUpChk_CheckedChanged;
            // 
            // followUpDate
            // 
            followUpDate.Enabled = false;
            followUpDate.Format = DateTimePickerFormat.Short;
            followUpDate.Location = new Point(200, 396);
            followUpDate.Name = "followUpDate";
            followUpDate.Size = new Size(200, 31);
            followUpDate.TabIndex = 4;
            // 
            // saveBtn
            // 
            saveBtn.Location = new Point(20, 470);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(250, 50);
            saveBtn.TabIndex = 5;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.DialogResult = DialogResult.Cancel;
            cancelBtn.Location = new Point(290, 470);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(250, 50);
            cancelBtn.TabIndex = 6;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            // 
            // record_history_form
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelBtn;
            ClientSize = new Size(560, 545);
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
            FormBorderStyle = FormBorderStyle.FixedDialog;
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
    }
}