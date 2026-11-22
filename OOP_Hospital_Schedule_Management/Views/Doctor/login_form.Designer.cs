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
            titleLbl.BackColor = Color.Transparent;
            titleLbl.Font = new Font("Airnt", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            titleLbl.ForeColor = Color.Teal;
            titleLbl.Location = new Point(31, 24);
            titleLbl.Margin = new Padding(2, 0, 2, 0);
            titleLbl.Name = "titleLbl";
            titleLbl.Size = new Size(217, 21);
            titleLbl.TabIndex = 0;
            titleLbl.Text = "Doctor Login";
            //
            // usernameLbl
            //
            usernameLbl.AutoSize = true;
            usernameLbl.BackColor = Color.Transparent;
            usernameLbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            usernameLbl.ForeColor = Color.Teal;
            usernameLbl.Location = new Point(35, 70);
            usernameLbl.Margin = new Padding(2, 0, 2, 0);
            usernameLbl.Name = "usernameLbl";
            usernameLbl.Size = new Size(60, 15);
            usernameLbl.TabIndex = 1;
            usernameLbl.Text = "Username";
            //
            // passwordLbl
            //
            passwordLbl.AutoSize = true;
            passwordLbl.BackColor = Color.Transparent;
            passwordLbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            passwordLbl.ForeColor = Color.Teal;
            passwordLbl.Location = new Point(35, 118);
            passwordLbl.Margin = new Padding(2, 0, 2, 0);
            passwordLbl.Name = "passwordLbl";
            passwordLbl.Size = new Size(57, 15);
            passwordLbl.TabIndex = 2;
            passwordLbl.Text = "Password";
            //
            // usernameTxt
            //
            usernameTxt.Location = new Point(35, 88);
            usernameTxt.Margin = new Padding(2, 2, 2, 2);
            usernameTxt.Name = "usernameTxt";
            usernameTxt.Size = new Size(211, 23);
            usernameTxt.TabIndex = 0;
            //
            // passwordTxt
            //
            passwordTxt.Location = new Point(35, 136);
            passwordTxt.Margin = new Padding(2, 2, 2, 2);
            passwordTxt.Name = "passwordTxt";
            passwordTxt.PasswordChar = '*';
            passwordTxt.Size = new Size(211, 23);
            passwordTxt.TabIndex = 1;
            //
            // loginBtn
            //
            loginBtn.FlatAppearance.BorderSize = 0;
            loginBtn.FlatStyle = FlatStyle.Flat;
            loginBtn.ForeColor = Color.White;
            loginBtn.Image = Properties.Resources.Button1;
            loginBtn.Location = new Point(35, 177);
            loginBtn.Margin = new Padding(2, 2, 2, 2);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(210, 30);
            loginBtn.TabIndex = 2;
            loginBtn.Text = "Login";
            loginBtn.UseVisualStyleBackColor = true;
            loginBtn.Click += loginBtn_Click;
            //
            // errorLbl
            //
            errorLbl.AutoSize = true;
            errorLbl.ForeColor = Color.Firebrick;
            errorLbl.Location = new Point(35, 153);
            errorLbl.Margin = new Padding(2, 0, 2, 0);
            errorLbl.Name = "errorLbl";
            errorLbl.Size = new Size(0, 15);
            errorLbl.TabIndex = 3;
            //
            // login_form
            //
            AcceptButton = loginBtn;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.BG2;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(280, 228);
            Controls.Add(titleLbl);
            Controls.Add(usernameLbl);
            Controls.Add(usernameTxt);
            Controls.Add(passwordLbl);
            Controls.Add(passwordTxt);
            Controls.Add(errorLbl);
            Controls.Add(loginBtn);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(2, 2, 2, 2);
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