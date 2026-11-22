namespace OOP_Hospital_Schedule_Management.staff_tab
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
            registerBtn = new Button();
            searchBtn = new Button();
            scheduleBtn = new Button();
            requestBtn = new Button();
            SuspendLayout();
            // 
            // registerBtn
            // 
            registerBtn.Location = new Point(60, 30);
            registerBtn.Name = "registerBtn";
            registerBtn.Size = new Size(360, 60);
            registerBtn.TabIndex = 0;
            registerBtn.Text = "Register new patients";
            registerBtn.UseVisualStyleBackColor = true;
            registerBtn.Click += registerBtn_Click;
            // 
            // searchBtn
            // 
            searchBtn.Location = new Point(60, 110);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(360, 60);
            searchBtn.TabIndex = 1;
            searchBtn.Text = "Search existing patients";
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // scheduleBtn
            // 
            scheduleBtn.Location = new Point(60, 190);
            scheduleBtn.Name = "scheduleBtn";
            scheduleBtn.Size = new Size(360, 60);
            scheduleBtn.TabIndex = 2;
            scheduleBtn.Text = "   View and manage schedules";
            scheduleBtn.UseVisualStyleBackColor = true;
            scheduleBtn.Click += scheduleBtn_Click;
            // 
            // requestBtn
            // 
            requestBtn.Location = new Point(60, 270);
            requestBtn.Name = "requestBtn";
            requestBtn.Size = new Size(360, 60);
            requestBtn.TabIndex = 3;
            requestBtn.Text = "Submit and track appointment request";
            requestBtn.UseVisualStyleBackColor = true;
            requestBtn.Click += requestBtn_Click;
            // 
            // staff_main_ui
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 380);
            Controls.Add(registerBtn);
            Controls.Add(searchBtn);
            Controls.Add(scheduleBtn);
            Controls.Add(requestBtn);
            Name = "staff_main_ui";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Staff";
            ResumeLayout(false);
        }

        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Button scheduleBtn;
        private System.Windows.Forms.Button requestBtn;
    }
}