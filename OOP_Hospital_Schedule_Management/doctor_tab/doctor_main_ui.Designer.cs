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
            this.viewPatientBtn = new System.Windows.Forms.Button();
            this.recordHistoryBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.viewPatientBtn.Location = new System.Drawing.Point(60, 35);
            this.viewPatientBtn.Name = "viewPatientBtn";
            this.viewPatientBtn.Size = new System.Drawing.Size(300, 65);
            this.viewPatientBtn.Text = "View Patient";
            this.viewPatientBtn.UseVisualStyleBackColor = true;

            this.recordHistoryBtn.Location = new System.Drawing.Point(60, 125);
            this.recordHistoryBtn.Name = "recordHistoryBtn";
            this.recordHistoryBtn.Size = new System.Drawing.Size(300, 65);
            this.recordHistoryBtn.Text = "Record check-up history";
            this.recordHistoryBtn.UseVisualStyleBackColor = true;

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 230);
            this.Controls.Add(this.viewPatientBtn);
            this.Controls.Add(this.recordHistoryBtn);
            this.Name = "doctor_main_ui";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Doctor";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button viewPatientBtn;
        private System.Windows.Forms.Button recordHistoryBtn;
    }

}