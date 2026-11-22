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
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // doctorBtn
            // 
            doctorBtn.Location = new Point(19, 13);
            doctorBtn.Name = "doctorBtn";
            doctorBtn.Size = new Size(276, 114);
            doctorBtn.TabIndex = 0;
            doctorBtn.Text = "DOCTOR";
            doctorBtn.UseVisualStyleBackColor = true;
            doctorBtn.Click += doctorBtn_Click;
            // 
            // staffBtn
            // 
            staffBtn.Location = new Point(301, 13);
            staffBtn.Name = "staffBtn";
            staffBtn.Size = new Size(276, 114);
            staffBtn.TabIndex = 1;
            staffBtn.Text = "STAFF";
            staffBtn.UseVisualStyleBackColor = true;
            staffBtn.Click += staffBtn_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel1.Location = new Point(13, 13);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(0, 0);
            flowLayoutPanel1.TabIndex = 2;
            flowLayoutPanel1.WrapContents = false;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Anchor = AnchorStyles.None;
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel2.Controls.Add(flowLayoutPanel1);
            flowLayoutPanel2.Controls.Add(doctorBtn);
            flowLayoutPanel2.Controls.Add(staffBtn);
            flowLayoutPanel2.Location = new Point(231, 166);
            flowLayoutPanel2.Margin = new Padding(20);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Padding = new Padding(10);
            flowLayoutPanel2.Size = new Size(590, 140);
            flowLayoutPanel2.TabIndex = 3;
            flowLayoutPanel2.WrapContents = false;
            // 
            // main_ui
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1029, 506);
            Controls.Add(flowLayoutPanel2);
            Name = "main_ui";
            Text = "Main UI";
            flowLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button doctorBtn;
        private Button staffBtn;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
    }
}
