namespace OOP_Hospital_Schedule_Management.doctor_tab
{
    partial class login_form
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
            titleLbl = new Label();
            usernameLbl = new Label();
            passwordLbl = new Label();
            usernameTxt = new TextBox();
            passwordTxt = new TextBox();
            loginBtn = new Button();
            errorLbl = new Label();
            SuspendLayout();
            // 
            // titleLbl
            // 
            titleLbl.AutoSize = true;
            titleLbl.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            titleLbl.Location = new Point(110, 30);
            titleLbl.Name = "titleLbl";
            titleLbl.Text = "Doctor Login";
            // 
            // usernameLbl
            // 
            usernameLbl.AutoSize = true;
            usernameLbl.Location = new Point(50, 100);
            usernameLbl.Name = "usernameLbl";
            usernameLbl.Text = "Username";
            // 
            // usernameTxt
            // 
            usernameTxt.Location = new Point(50, 130);
            usernameTxt.Name = "usernameTxt";
            usernameTxt.Size = new Size(300, 31);
            usernameTxt.TabIndex = 0;
            // 
            // passwordLbl
            // 
            passwordLbl.AutoSize = true;
            passwordLbl.Location = new Point(50, 180);
            passwordLbl.Name = "passwordLbl";
            passwordLbl.Text = "Password";
            // 
            // passwordTxt
            // 
            passwordTxt.Location = new Point(50, 210);
            passwordTxt.Name = "passwordTxt";
            passwordTxt.PasswordChar = '*';
            passwordTxt.Size = new Size(300, 31);
            passwordTxt.TabIndex = 1;
            // 
            // errorLbl
            // 
            errorLbl.AutoSize = true;
            errorLbl.ForeColor = Color.Firebrick;
            errorLbl.Location = new Point(50, 255);
            errorLbl.Name = "errorLbl";
            errorLbl.Text = "";
            // 
            // loginBtn
            // 
            loginBtn.Location = new Point(50, 295);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(300, 50);
            loginBtn.TabIndex = 2;
            loginBtn.Text = "Login";
            loginBtn.UseVisualStyleBackColor = true;
            loginBtn.Click += loginBtn_Click;
            // 
            // login_form
            // 
            AcceptButton = loginBtn;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 380);
            Controls.Add(titleLbl);
            Controls.Add(usernameLbl);
            Controls.Add(usernameTxt);
            Controls.Add(passwordLbl);
            Controls.Add(passwordTxt);
            Controls.Add(errorLbl);
            Controls.Add(loginBtn);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "login_form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label titleLbl;
        private Label usernameLbl;
        private Label passwordLbl;
        private TextBox usernameTxt;
        private TextBox passwordTxt;
        private Button loginBtn;
        private Label errorLbl;
    }
}