namespace OOP_Hospital_Schedule_Management
{
    partial class staff_main_ui
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
            this.registerBtn = new System.Windows.Forms.Button();
            this.searchBtn = new System.Windows.Forms.Button();
            this.scheduleBtn = new System.Windows.Forms.Button();
            this.requestBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.registerBtn.Location = new System.Drawing.Point(60, 30);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(360, 60);
            this.registerBtn.Text = "Register new patients";
            this.registerBtn.UseVisualStyleBackColor = true;

            this.searchBtn.Location = new System.Drawing.Point(60, 110);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(360, 60);
            this.searchBtn.Text = "Search existing patients";
            this.searchBtn.UseVisualStyleBackColor = true;

            this.scheduleBtn.Location = new System.Drawing.Point(60, 190);
            this.scheduleBtn.Name = "scheduleBtn";
            this.scheduleBtn.Size = new System.Drawing.Size(360, 60);
            this.scheduleBtn.Text = "View and manage schedules";
            this.scheduleBtn.UseVisualStyleBackColor = true;

            this.requestBtn.Location = new System.Drawing.Point(60, 270);
            this.requestBtn.Name = "requestBtn";
            this.requestBtn.Size = new System.Drawing.Size(360, 60);
            this.requestBtn.Text = "Submit and track requests";
            this.requestBtn.UseVisualStyleBackColor = true;

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 380);
            this.Controls.Add(this.registerBtn);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.scheduleBtn);
            this.Controls.Add(this.requestBtn);
            this.Name = "staff_main_ui";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Staff";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Button scheduleBtn;
        private System.Windows.Forms.Button requestBtn;
    }
}