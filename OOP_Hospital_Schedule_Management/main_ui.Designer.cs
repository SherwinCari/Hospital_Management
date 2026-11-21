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
            SuspendLayout();
            // 
            // doctorBtn
            // 
            doctorBtn.Location = new Point(94, 131);
            doctorBtn.Name = "doctorBtn";
            doctorBtn.Size = new Size(276, 114);
            doctorBtn.TabIndex = 0;
            doctorBtn.Text = "DOCTOR";
            doctorBtn.UseVisualStyleBackColor = true;
            doctorBtn.Click += this.doctorBtn_Click;
            // 
            // staffBtn
            // 
            staffBtn.Location = new Point(413, 131);
            staffBtn.Name = "staffBtn";
            staffBtn.Size = new Size(276, 114);
            staffBtn.TabIndex = 1;
            staffBtn.Text = "STAFF";
            staffBtn.UseVisualStyleBackColor = true;
            staffBtn.Click += this.staffBtn_Click;
            // 
            // main_ui
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(staffBtn);
            Controls.Add(doctorBtn);
            Name = "main_ui";
            Text = "Main UI";
            ResumeLayout(false);
        }

        #endregion

        private Button doctorBtn;
        private Button staffBtn;
    }
}
