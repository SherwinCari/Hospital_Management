namespace OOP_Hospital_Schedule_Management.staff_tab
{
    partial class register_patient_form
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
            fullNameLbl = new Label();
            fullNameTxt = new TextBox();
            birthdateLbl = new Label();
            birthdateDtp = new DateTimePicker();
            contactLbl = new Label();
            contactTxt = new TextBox();
            bloodTypeLbl = new Label();
            bloodTypeCmb = new ComboBox();
            addressLbl = new Label();
            addressTxt = new TextBox();
            allergiesLbl = new Label();
            allergiesTxt = new TextBox();
            conditionsLbl = new Label();
            conditionsTxt = new TextBox();
            ecNameLbl = new Label();
            ecNameTxt = new TextBox();
            ecNoLbl = new Label();
            ecNoTxt = new TextBox();
            departmentLbl = new Label();
            departmentCmb = new ComboBox();
            problemLbl = new Label();
            problemTxt = new TextBox();
            saveBtn = new Button();
            cancelBtn = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // fullNameLbl
            // 
            fullNameLbl.AutoSize = true;
            fullNameLbl.BackColor = Color.Transparent;
            fullNameLbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            fullNameLbl.ForeColor = Color.Teal;
            fullNameLbl.Location = new Point(52, 84);
            fullNameLbl.Margin = new Padding(2, 0, 2, 0);
            fullNameLbl.Name = "fullNameLbl";
            fullNameLbl.Size = new Size(67, 15);
            fullNameLbl.TabIndex = 0;
            fullNameLbl.Text = "Full name *";
            // 
            // fullNameTxt
            // 
            fullNameTxt.Location = new Point(52, 100);
            fullNameTxt.Margin = new Padding(2, 2, 2, 2);
            fullNameTxt.MaxLength = 100;
            fullNameTxt.Name = "fullNameTxt";
            fullNameTxt.Size = new Size(176, 23);
            fullNameTxt.TabIndex = 0;
            // 
            // birthdateLbl
            // 
            birthdateLbl.AutoSize = true;
            birthdateLbl.BackColor = Color.Transparent;
            birthdateLbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            birthdateLbl.ForeColor = Color.Teal;
            birthdateLbl.Location = new Point(241, 84);
            birthdateLbl.Margin = new Padding(2, 0, 2, 0);
            birthdateLbl.Name = "birthdateLbl";
            birthdateLbl.Size = new Size(117, 15);
            birthdateLbl.TabIndex = 1;
            birthdateLbl.Text = "Birthdate (tick to set)";
            // 
            // birthdateDtp
            // 
            birthdateDtp.Checked = false;
            birthdateDtp.Format = DateTimePickerFormat.Short;
            birthdateDtp.Location = new Point(241, 100);
            birthdateDtp.Margin = new Padding(2, 2, 2, 2);
            birthdateDtp.Name = "birthdateDtp";
            birthdateDtp.ShowCheckBox = true;
            birthdateDtp.Size = new Size(176, 23);
            birthdateDtp.TabIndex = 1;
            // 
            // contactLbl
            // 
            contactLbl.AutoSize = true;
            contactLbl.BackColor = Color.Transparent;
            contactLbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            contactLbl.ForeColor = Color.Teal;
            contactLbl.Location = new Point(52, 126);
            contactLbl.Margin = new Padding(2, 0, 2, 0);
            contactLbl.Name = "contactLbl";
            contactLbl.Size = new Size(68, 15);
            contactLbl.TabIndex = 2;
            contactLbl.Text = "Contact no.";
            // 
            // contactTxt
            // 
            contactTxt.Location = new Point(52, 142);
            contactTxt.Margin = new Padding(2, 2, 2, 2);
            contactTxt.MaxLength = 20;
            contactTxt.Name = "contactTxt";
            contactTxt.Size = new Size(176, 23);
            contactTxt.TabIndex = 2;
            // 
            // bloodTypeLbl
            // 
            bloodTypeLbl.AutoSize = true;
            bloodTypeLbl.BackColor = Color.Transparent;
            bloodTypeLbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            bloodTypeLbl.ForeColor = Color.Teal;
            bloodTypeLbl.Location = new Point(241, 126);
            bloodTypeLbl.Margin = new Padding(2, 0, 2, 0);
            bloodTypeLbl.Name = "bloodTypeLbl";
            bloodTypeLbl.Size = new Size(64, 15);
            bloodTypeLbl.TabIndex = 3;
            bloodTypeLbl.Text = "Blood type";
            // 
            // bloodTypeCmb
            // 
            bloodTypeCmb.DropDownStyle = ComboBoxStyle.DropDownList;
            bloodTypeCmb.Items.AddRange(new object[] { "", "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" });
            bloodTypeCmb.Location = new Point(241, 142);
            bloodTypeCmb.Margin = new Padding(2, 2, 2, 2);
            bloodTypeCmb.Name = "bloodTypeCmb";
            bloodTypeCmb.Size = new Size(176, 23);
            bloodTypeCmb.TabIndex = 3;
            // 
            // addressLbl
            // 
            addressLbl.AutoSize = true;
            addressLbl.BackColor = Color.Transparent;
            addressLbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            addressLbl.ForeColor = Color.Teal;
            addressLbl.Location = new Point(52, 168);
            addressLbl.Margin = new Padding(2, 0, 2, 0);
            addressLbl.Name = "addressLbl";
            addressLbl.Size = new Size(49, 15);
            addressLbl.TabIndex = 4;
            addressLbl.Text = "Address";
            // 
            // addressTxt
            // 
            addressTxt.Location = new Point(52, 184);
            addressTxt.Margin = new Padding(2, 2, 2, 2);
            addressTxt.MaxLength = 200;
            addressTxt.Name = "addressTxt";
            addressTxt.Size = new Size(365, 23);
            addressTxt.TabIndex = 4;
            // 
            // allergiesLbl
            // 
            allergiesLbl.AutoSize = true;
            allergiesLbl.BackColor = Color.Transparent;
            allergiesLbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            allergiesLbl.ForeColor = Color.Teal;
            allergiesLbl.Location = new Point(52, 210);
            allergiesLbl.Margin = new Padding(2, 0, 2, 0);
            allergiesLbl.Name = "allergiesLbl";
            allergiesLbl.Size = new Size(52, 15);
            allergiesLbl.TabIndex = 5;
            allergiesLbl.Text = "Allergies";
            // 
            // allergiesTxt
            // 
            allergiesTxt.Location = new Point(52, 226);
            allergiesTxt.Margin = new Padding(2, 2, 2, 2);
            allergiesTxt.MaxLength = 200;
            allergiesTxt.Name = "allergiesTxt";
            allergiesTxt.Size = new Size(176, 23);
            allergiesTxt.TabIndex = 5;
            // 
            // conditionsLbl
            // 
            conditionsLbl.AutoSize = true;
            conditionsLbl.BackColor = Color.Transparent;
            conditionsLbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            conditionsLbl.ForeColor = Color.Teal;
            conditionsLbl.Location = new Point(241, 210);
            conditionsLbl.Margin = new Padding(2, 0, 2, 0);
            conditionsLbl.Name = "conditionsLbl";
            conditionsLbl.Size = new Size(162, 15);
            conditionsLbl.TabIndex = 6;
            conditionsLbl.Text = "Existing conditions (optional)";
            // 
            // conditionsTxt
            // 
            conditionsTxt.Location = new Point(241, 226);
            conditionsTxt.Margin = new Padding(2, 2, 2, 2);
            conditionsTxt.MaxLength = 200;
            conditionsTxt.Name = "conditionsTxt";
            conditionsTxt.Size = new Size(176, 23);
            conditionsTxt.TabIndex = 6;
            // 
            // ecNameLbl
            // 
            ecNameLbl.AutoSize = true;
            ecNameLbl.BackColor = Color.Transparent;
            ecNameLbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            ecNameLbl.ForeColor = Color.Teal;
            ecNameLbl.Location = new Point(52, 252);
            ecNameLbl.Margin = new Padding(2, 0, 2, 0);
            ecNameLbl.Name = "ecNameLbl";
            ecNameLbl.Size = new Size(142, 15);
            ecNameLbl.TabIndex = 7;
            ecNameLbl.Text = "Emergency contact name";
            // 
            // ecNameTxt
            // 
            ecNameTxt.Location = new Point(52, 268);
            ecNameTxt.Margin = new Padding(2, 2, 2, 2);
            ecNameTxt.MaxLength = 100;
            ecNameTxt.Name = "ecNameTxt";
            ecNameTxt.Size = new Size(176, 23);
            ecNameTxt.TabIndex = 7;
            // 
            // ecNoLbl
            // 
            ecNoLbl.AutoSize = true;
            ecNoLbl.BackColor = Color.Transparent;
            ecNoLbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            ecNoLbl.ForeColor = Color.Teal;
            ecNoLbl.Location = new Point(241, 252);
            ecNoLbl.Margin = new Padding(2, 0, 2, 0);
            ecNoLbl.Name = "ecNoLbl";
            ecNoLbl.Size = new Size(129, 15);
            ecNoLbl.TabIndex = 8;
            ecNoLbl.Text = "Emergency contact no.";
            // 
            // ecNoTxt
            // 
            ecNoTxt.Location = new Point(241, 268);
            ecNoTxt.Margin = new Padding(2, 2, 2, 2);
            ecNoTxt.MaxLength = 20;
            ecNoTxt.Name = "ecNoTxt";
            ecNoTxt.Size = new Size(176, 23);
            ecNoTxt.TabIndex = 8;
            // 
            // departmentLbl
            // 
            departmentLbl.AutoSize = true;
            departmentLbl.BackColor = Color.Transparent;
            departmentLbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            departmentLbl.ForeColor = Color.Teal;
            departmentLbl.Location = new Point(52, 294);
            departmentLbl.Margin = new Padding(2, 0, 2, 0);
            departmentLbl.Name = "departmentLbl";
            departmentLbl.Size = new Size(79, 15);
            departmentLbl.TabIndex = 9;
            departmentLbl.Text = "Department *";
            // 
            // departmentCmb
            // 
            departmentCmb.DropDownStyle = ComboBoxStyle.DropDownList;
            departmentCmb.Location = new Point(52, 310);
            departmentCmb.Margin = new Padding(2, 2, 2, 2);
            departmentCmb.Name = "departmentCmb";
            departmentCmb.Size = new Size(365, 23);
            departmentCmb.TabIndex = 9;
            // 
            // problemLbl
            // 
            problemLbl.AutoSize = true;
            problemLbl.BackColor = Color.Transparent;
            problemLbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            problemLbl.ForeColor = Color.Teal;
            problemLbl.Location = new Point(52, 336);
            problemLbl.Margin = new Padding(2, 0, 2, 0);
            problemLbl.Name = "problemLbl";
            problemLbl.Size = new Size(298, 15);
            problemLbl.TabIndex = 10;
            problemLbl.Text = "Problem description (what is the patient experiencing?)";
            // 
            // problemTxt
            // 
            problemTxt.Location = new Point(52, 352);
            problemTxt.Margin = new Padding(2, 2, 2, 2);
            problemTxt.Multiline = true;
            problemTxt.Name = "problemTxt";
            problemTxt.ScrollBars = ScrollBars.Vertical;
            problemTxt.Size = new Size(365, 68);
            problemTxt.TabIndex = 10;
            // 
            // saveBtn
            // 
            saveBtn.FlatAppearance.BorderSize = 0;
            saveBtn.FlatStyle = FlatStyle.Flat;
            saveBtn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            saveBtn.ForeColor = Color.White;
            saveBtn.Image = Properties.Resources.Button1;
            saveBtn.Location = new Point(52, 429);
            saveBtn.Margin = new Padding(2, 2, 2, 2);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(175, 30);
            saveBtn.TabIndex = 11;
            saveBtn.Text = "Register";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.DialogResult = DialogResult.Cancel;
            cancelBtn.FlatAppearance.BorderSize = 0;
            cancelBtn.FlatStyle = FlatStyle.Flat;
            cancelBtn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            cancelBtn.ForeColor = Color.White;
            cancelBtn.Image = Properties.Resources.Button1;
            cancelBtn.Location = new Point(241, 429);
            cancelBtn.Margin = new Padding(2, 2, 2, 2);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(175, 30);
            cancelBtn.TabIndex = 12;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Airnt", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Teal;
            label1.Location = new Point(69, 32);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(334, 21);
            label1.TabIndex = 0;
            label1.Text = "PATIENT REGISTRATION";
            // 
            // register_patient_form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.BG2;
            BackgroundImageLayout = ImageLayout.Stretch;
            CancelButton = cancelBtn;
            ClientSize = new Size(470, 514);
            Controls.Add(label1);
            Controls.Add(fullNameLbl);
            Controls.Add(fullNameTxt);
            Controls.Add(birthdateLbl);
            Controls.Add(birthdateDtp);
            Controls.Add(contactLbl);
            Controls.Add(contactTxt);
            Controls.Add(bloodTypeLbl);
            Controls.Add(bloodTypeCmb);
            Controls.Add(addressLbl);
            Controls.Add(addressTxt);
            Controls.Add(allergiesLbl);
            Controls.Add(allergiesTxt);
            Controls.Add(conditionsLbl);
            Controls.Add(conditionsTxt);
            Controls.Add(ecNameLbl);
            Controls.Add(ecNameTxt);
            Controls.Add(ecNoLbl);
            Controls.Add(ecNoTxt);
            Controls.Add(departmentLbl);
            Controls.Add(departmentCmb);
            Controls.Add(problemLbl);
            Controls.Add(problemTxt);
            Controls.Add(saveBtn);
            Controls.Add(cancelBtn);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2, 2, 2, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "register_patient_form";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Register new patient";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label fullNameLbl;
        private TextBox fullNameTxt;
        private Label birthdateLbl;
        private DateTimePicker birthdateDtp;
        private Label contactLbl;
        private TextBox contactTxt;
        private Label bloodTypeLbl;
        private ComboBox bloodTypeCmb;
        private Label addressLbl;
        private TextBox addressTxt;
        private Label allergiesLbl;
        private TextBox allergiesTxt;
        private Label conditionsLbl;
        private TextBox conditionsTxt;
        private Label ecNameLbl;
        private TextBox ecNameTxt;
        private Label ecNoLbl;
        private TextBox ecNoTxt;
        private Label departmentLbl;
        private ComboBox departmentCmb;
        private Label problemLbl;
        private TextBox problemTxt;
        private Button saveBtn;
        private Button cancelBtn;
        private Label label1;
    }
}