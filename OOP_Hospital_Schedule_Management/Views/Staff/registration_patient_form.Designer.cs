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
            SuspendLayout();
            // 
            // fullNameLbl / fullNameTxt
            // 
            fullNameLbl.AutoSize = true;
            fullNameLbl.Location = new Point(20, 15);
            fullNameLbl.Name = "fullNameLbl";
            fullNameLbl.Text = "Full name *";
            fullNameTxt.Location = new Point(20, 42);
            fullNameTxt.MaxLength = 100;
            fullNameTxt.Name = "fullNameTxt";
            fullNameTxt.Size = new Size(250, 31);
            fullNameTxt.TabIndex = 0;
            // 
            // birthdateLbl / birthdateDtp
            // 
            birthdateLbl.AutoSize = true;
            birthdateLbl.Location = new Point(290, 15);
            birthdateLbl.Name = "birthdateLbl";
            birthdateLbl.Text = "Birthdate (tick to set)";
            birthdateDtp.Checked = false;
            birthdateDtp.Format = DateTimePickerFormat.Short;
            birthdateDtp.Location = new Point(290, 42);
            birthdateDtp.Name = "birthdateDtp";
            birthdateDtp.ShowCheckBox = true;
            birthdateDtp.Size = new Size(250, 31);
            birthdateDtp.TabIndex = 1;
            // 
            // contactLbl / contactTxt
            // 
            contactLbl.AutoSize = true;
            contactLbl.Location = new Point(20, 85);
            contactLbl.Name = "contactLbl";
            contactLbl.Text = "Contact no.";
            contactTxt.Location = new Point(20, 112);
            contactTxt.MaxLength = 20;
            contactTxt.Name = "contactTxt";
            contactTxt.Size = new Size(250, 31);
            contactTxt.TabIndex = 2;
            // 
            // bloodTypeLbl / bloodTypeCmb
            // 
            bloodTypeLbl.AutoSize = true;
            bloodTypeLbl.Location = new Point(290, 85);
            bloodTypeLbl.Name = "bloodTypeLbl";
            bloodTypeLbl.Text = "Blood type";
            bloodTypeCmb.DropDownStyle = ComboBoxStyle.DropDownList;
            bloodTypeCmb.Items.AddRange(new object[] { "", "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" });
            bloodTypeCmb.Location = new Point(290, 112);
            bloodTypeCmb.Name = "bloodTypeCmb";
            bloodTypeCmb.Size = new Size(250, 33);
            bloodTypeCmb.TabIndex = 3;
            // 
            // addressLbl / addressTxt
            // 
            addressLbl.AutoSize = true;
            addressLbl.Location = new Point(20, 155);
            addressLbl.Name = "addressLbl";
            addressLbl.Text = "Address";
            addressTxt.Location = new Point(20, 182);
            addressTxt.MaxLength = 200;
            addressTxt.Name = "addressTxt";
            addressTxt.Size = new Size(520, 31);
            addressTxt.TabIndex = 4;
            // 
            // allergiesLbl / allergiesTxt
            // 
            allergiesLbl.AutoSize = true;
            allergiesLbl.Location = new Point(20, 225);
            allergiesLbl.Name = "allergiesLbl";
            allergiesLbl.Text = "Allergies";
            allergiesTxt.Location = new Point(20, 252);
            allergiesTxt.MaxLength = 200;
            allergiesTxt.Name = "allergiesTxt";
            allergiesTxt.Size = new Size(250, 31);
            allergiesTxt.TabIndex = 5;
            // 
            // conditionsLbl / conditionsTxt
            // 
            conditionsLbl.AutoSize = true;
            conditionsLbl.Location = new Point(290, 225);
            conditionsLbl.Name = "conditionsLbl";
            conditionsLbl.Text = "Existing conditions (optional)";
            conditionsTxt.Location = new Point(290, 252);
            conditionsTxt.MaxLength = 200;
            conditionsTxt.Name = "conditionsTxt";
            conditionsTxt.Size = new Size(250, 31);
            conditionsTxt.TabIndex = 6;
            // 
            // ecNameLbl / ecNameTxt
            // 
            ecNameLbl.AutoSize = true;
            ecNameLbl.Location = new Point(20, 295);
            ecNameLbl.Name = "ecNameLbl";
            ecNameLbl.Text = "Emergency contact name";
            ecNameTxt.Location = new Point(20, 322);
            ecNameTxt.MaxLength = 100;
            ecNameTxt.Name = "ecNameTxt";
            ecNameTxt.Size = new Size(250, 31);
            ecNameTxt.TabIndex = 7;
            // 
            // ecNoLbl / ecNoTxt
            // 
            ecNoLbl.AutoSize = true;
            ecNoLbl.Location = new Point(290, 295);
            ecNoLbl.Name = "ecNoLbl";
            ecNoLbl.Text = "Emergency contact no.";
            ecNoTxt.Location = new Point(290, 322);
            ecNoTxt.MaxLength = 20;
            ecNoTxt.Name = "ecNoTxt";
            ecNoTxt.Size = new Size(250, 31);
            ecNoTxt.TabIndex = 8;
            // 
            // departmentLbl / departmentCmb
            // 
            departmentLbl.AutoSize = true;
            departmentLbl.Location = new Point(20, 365);
            departmentLbl.Name = "departmentLbl";
            departmentLbl.Text = "Department *";
            departmentCmb.DropDownStyle = ComboBoxStyle.DropDownList;
            departmentCmb.Location = new Point(20, 392);
            departmentCmb.Name = "departmentCmb";
            departmentCmb.Size = new Size(520, 33);
            departmentCmb.TabIndex = 9;
            // 
            // problemLbl / problemTxt
            // 
            problemLbl.AutoSize = true;
            problemLbl.Location = new Point(20, 435);
            problemLbl.Name = "problemLbl";
            problemLbl.Text = "Problem description (what is the patient experiencing?)";
            problemTxt.Location = new Point(20, 462);
            problemTxt.Multiline = true;
            problemTxt.Name = "problemTxt";
            problemTxt.ScrollBars = ScrollBars.Vertical;
            problemTxt.Size = new Size(520, 110);
            problemTxt.TabIndex = 10;
            // 
            // saveBtn
            // 
            saveBtn.Location = new Point(20, 590);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(250, 50);
            saveBtn.TabIndex = 11;
            saveBtn.Text = "Register";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.DialogResult = DialogResult.Cancel;
            cancelBtn.Location = new Point(290, 590);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(250, 50);
            cancelBtn.TabIndex = 12;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            // 
            // register_patient_form
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelBtn;
            ClientSize = new Size(560, 660);
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
            FormBorderStyle = FormBorderStyle.FixedDialog;
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
    }
}