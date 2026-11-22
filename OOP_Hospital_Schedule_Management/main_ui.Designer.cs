namespace OOP_Hospital_Schedule_Management
{
    partial class main_ui
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            doctorBtn = new Button();
            staffBtn = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // doctorBtn
            // 
            doctorBtn.BackColor = Color.Transparent;
            doctorBtn.BackgroundImage = Properties.Resources._6;
            doctorBtn.BackgroundImageLayout = ImageLayout.Zoom;
            doctorBtn.FlatAppearance.BorderSize = 0;
            doctorBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            doctorBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            doctorBtn.FlatStyle = FlatStyle.Flat;
            doctorBtn.ForeColor = Color.Transparent;
            doctorBtn.Location = new Point(85, 84);
            doctorBtn.Margin = new Padding(2);
            doctorBtn.Name = "doctorBtn";
            doctorBtn.Size = new Size(165, 161);
            doctorBtn.TabIndex = 0;
            doctorBtn.UseVisualStyleBackColor = false;
            doctorBtn.Click += doctorBtn_Click;
            // 
            // staffBtn
            // 
            staffBtn.BackColor = Color.Transparent;
            staffBtn.BackgroundImage = Properties.Resources._5;
            staffBtn.BackgroundImageLayout = ImageLayout.Stretch;
            staffBtn.FlatAppearance.BorderSize = 0;
            staffBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            staffBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            staffBtn.FlatStyle = FlatStyle.Flat;
            staffBtn.ForeColor = Color.Transparent;
            staffBtn.Location = new Point(271, 84);
            staffBtn.Margin = new Padding(2);
            staffBtn.Name = "staffBtn";
            staffBtn.Size = new Size(165, 161);
            staffBtn.TabIndex = 1;
            staffBtn.UseVisualStyleBackColor = false;
            staffBtn.Click += staffBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Consolas", 10F, FontStyle.Bold);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(140, 247);
            label1.Name = "label1";
            label1.Size = new Size(56, 17);
            label1.TabIndex = 2;
            label1.Text = "DOCTOR";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Consolas", 10F, FontStyle.Bold);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(333, 247);
            label2.Name = "label2";
            label2.Size = new Size(48, 17);
            label2.TabIndex = 2;
            label2.Text = "STAFF";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Airnt", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Teal;
            label3.Location = new Point(42, 44);
            label3.Name = "label3";
            label3.Size = new Size(456, 19);
            label3.TabIndex = 2;
            label3.Text = "SELECT YOUR ROLE TO CONTINUE";
            // 
            // main_ui
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.BG1;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(537, 320);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(staffBtn);
            Controls.Add(doctorBtn);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2);
            Name = "main_ui";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main UI";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button doctorBtn;
        private Button staffBtn;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
