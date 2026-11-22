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
            registerBtn.BackColor = Color.Transparent;
            registerBtn.BackgroundImage = Properties.Resources.Button1;
            registerBtn.FlatAppearance.BorderSize = 0;
            registerBtn.FlatStyle = FlatStyle.Flat;
            registerBtn.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            registerBtn.ForeColor = Color.White;
            registerBtn.Image = Properties.Resources.Button1;
            registerBtn.Location = new Point(83, 31);
            registerBtn.Margin = new Padding(3, 2, 3, 2);
            registerBtn.Name = "registerBtn";
            registerBtn.Size = new Size(196, 68);
            registerBtn.TabIndex = 0;
            registerBtn.Text = "Register new patients";
            registerBtn.UseVisualStyleBackColor = false;
            registerBtn.Click += registerBtn_Click;
            // 
            // searchBtn
            // 
            searchBtn.BackColor = Color.Transparent;
            searchBtn.BackgroundImage = Properties.Resources.Button1;
            searchBtn.FlatAppearance.BorderSize = 0;
            searchBtn.FlatStyle = FlatStyle.Flat;
            searchBtn.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            searchBtn.ForeColor = Color.White;
            searchBtn.Image = Properties.Resources.Button1;
            searchBtn.Location = new Point(83, 91);
            searchBtn.Margin = new Padding(3, 2, 3, 2);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(196, 68);
            searchBtn.TabIndex = 1;
            searchBtn.Text = "Search existing patients";
            searchBtn.UseVisualStyleBackColor = false;
            searchBtn.Click += searchBtn_Click;
            // 
            // scheduleBtn
            // 
            scheduleBtn.BackColor = Color.Transparent;
            scheduleBtn.BackgroundImage = Properties.Resources.Button1;
            scheduleBtn.FlatAppearance.BorderSize = 0;
            scheduleBtn.FlatStyle = FlatStyle.Flat;
            scheduleBtn.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            scheduleBtn.ForeColor = Color.White;
            scheduleBtn.Image = Properties.Resources.Button1;
            scheduleBtn.Location = new Point(83, 151);
            scheduleBtn.Margin = new Padding(3, 2, 3, 2);
            scheduleBtn.Name = "scheduleBtn";
            scheduleBtn.Size = new Size(196, 68);
            scheduleBtn.TabIndex = 2;
            scheduleBtn.Text = "View and manage schedules";
            scheduleBtn.UseVisualStyleBackColor = false;
            scheduleBtn.Click += scheduleBtn_Click;
            // 
            // requestBtn
            // 
            requestBtn.BackColor = Color.Transparent;
            requestBtn.BackgroundImage = Properties.Resources.Button1;
            requestBtn.FlatAppearance.BorderSize = 0;
            requestBtn.FlatStyle = FlatStyle.Flat;
            requestBtn.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            requestBtn.ForeColor = Color.White;
            requestBtn.Image = Properties.Resources.Button1;
            requestBtn.Location = new Point(83, 211);
            requestBtn.Margin = new Padding(3, 2, 3, 2);
            requestBtn.Name = "requestBtn";
            requestBtn.Size = new Size(196, 68);
            requestBtn.TabIndex = 3;
            requestBtn.Text = "Submit and track appointment request";
            requestBtn.UseVisualStyleBackColor = false;
            requestBtn.Click += requestBtn_Click;
            // 
            // staff_main_ui
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.BG2;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(359, 307);
            Controls.Add(registerBtn);
            Controls.Add(searchBtn);
            Controls.Add(scheduleBtn);
            Controls.Add(requestBtn);
            DoubleBuffered = true;
            Margin = new Padding(3, 2, 3, 2);
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