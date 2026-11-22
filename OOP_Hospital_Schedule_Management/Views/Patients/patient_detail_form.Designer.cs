namespace OOP_Hospital_Schedule_Management
{
    partial class patient_detail_form
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
            nameLbl = new Label();
            infoLbl = new Label();
            nurseTitleLbl = new Label();
            nurseLbl = new Label();
            problemTitleLbl = new Label();
            problemTxt = new TextBox();
            historyTitleLbl = new Label();
            historyGrid = new DataGridView();
            recordBtn = new Button();
            closeBtn = new Button();
            startBtn = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)historyGrid).BeginInit();
            SuspendLayout();
            //
            // nameLbl
            //
            nameLbl.BackColor = Color.Transparent;
            nameLbl.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            nameLbl.ForeColor = Color.Teal;
            nameLbl.Location = new Point(22, 71);
            nameLbl.Margin = new Padding(2, 0, 2, 0);
            nameLbl.Name = "nameLbl";
            nameLbl.Size = new Size(588, 32);
            nameLbl.TabIndex = 0;
            nameLbl.Text = "Patient Name";
            //
            // infoLbl
            //
            infoLbl.BackColor = Color.Transparent;
            infoLbl.Location = new Point(22, 103);
            infoLbl.Margin = new Padding(2, 0, 2, 0);
            infoLbl.Name = "infoLbl";
            infoLbl.Size = new Size(588, 45);
            infoLbl.TabIndex = 1;
            infoLbl.Text = "Patient info";
            //
            // nurseTitleLbl
            //
            nurseTitleLbl.BackColor = Color.Transparent;
            nurseTitleLbl.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            nurseTitleLbl.ForeColor = Color.Teal;
            nurseTitleLbl.Location = new Point(22, 152);
            nurseTitleLbl.Margin = new Padding(2, 0, 2, 0);
            nurseTitleLbl.Name = "nurseTitleLbl";
            nurseTitleLbl.Size = new Size(588, 16);
            nurseTitleLbl.TabIndex = 2;
            nurseTitleLbl.Text = "Nurse's Summary (this visit)";
            //
            // nurseLbl
            //
            nurseLbl.BackColor = Color.Transparent;
            nurseLbl.Location = new Point(22, 171);
            nurseLbl.Margin = new Padding(2, 0, 2, 0);
            nurseLbl.Name = "nurseLbl";
            nurseLbl.Size = new Size(588, 39);
            nurseLbl.TabIndex = 3;
            nurseLbl.Text = "Vitals";
            //
            // problemTitleLbl
            //
            problemTitleLbl.BackColor = Color.Transparent;
            problemTitleLbl.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            problemTitleLbl.ForeColor = Color.Teal;
            problemTitleLbl.Location = new Point(22, 208);
            problemTitleLbl.Margin = new Padding(2, 0, 2, 0);
            problemTitleLbl.Name = "problemTitleLbl";
            problemTitleLbl.Size = new Size(588, 16);
            problemTitleLbl.TabIndex = 4;
            problemTitleLbl.Text = "Problem Description (entered at registration)";
            //
            // problemTxt
            //
            problemTxt.BackColor = Color.White;
            problemTxt.Location = new Point(22, 229);
            problemTxt.Margin = new Padding(2, 2, 2, 2);
            problemTxt.Multiline = true;
            problemTxt.Name = "problemTxt";
            problemTxt.ReadOnly = true;
            problemTxt.ScrollBars = ScrollBars.Vertical;
            problemTxt.Size = new Size(652, 44);
            problemTxt.TabIndex = 5;
            problemTxt.TabStop = false;
            //
            // historyTitleLbl
            //
            historyTitleLbl.BackColor = Color.Transparent;
            historyTitleLbl.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            historyTitleLbl.ForeColor = Color.Teal;
            historyTitleLbl.Location = new Point(22, 277);
            historyTitleLbl.Margin = new Padding(2, 0, 2, 0);
            historyTitleLbl.Name = "historyTitleLbl";
            historyTitleLbl.Size = new Size(588, 20);
            historyTitleLbl.TabIndex = 6;
            historyTitleLbl.Text = "Record History";
            //
            // historyGrid
            //
            historyGrid.AllowUserToAddRows = false;
            historyGrid.AllowUserToDeleteRows = false;
            historyGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            historyGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            historyGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            historyGrid.BackgroundColor = Color.White;
            historyGrid.BorderStyle = BorderStyle.Fixed3D;
            historyGrid.Location = new Point(22, 299);
            historyGrid.Margin = new Padding(2, 2, 2, 2);
            historyGrid.Name = "historyGrid";
            historyGrid.ReadOnly = true;
            historyGrid.RowHeadersVisible = false;
            historyGrid.RowHeadersWidth = 62;
            historyGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            historyGrid.Size = new Size(658, 201);
            historyGrid.TabIndex = 0;
            //
            // recordBtn
            //
            recordBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            recordBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            recordBtn.BackColor = Color.Transparent;
            recordBtn.BackgroundImage = Properties.Resources.Button1;
            recordBtn.BackgroundImageLayout = ImageLayout.Zoom;
            recordBtn.FlatAppearance.BorderSize = 0;
            recordBtn.FlatStyle = FlatStyle.Flat;
            recordBtn.Font = new Font("Consolas", 8.25F, FontStyle.Bold);
            recordBtn.ForeColor = Color.White;
            recordBtn.Image = Properties.Resources.Button1;
            recordBtn.Location = new Point(362, 515);
            recordBtn.Margin = new Padding(2, 2, 2, 2);
            recordBtn.Name = "recordBtn";
            recordBtn.Size = new Size(154, 29);
            recordBtn.TabIndex = 1;
            recordBtn.Text = "Record History";
            recordBtn.UseVisualStyleBackColor = false;
            recordBtn.Click += recordBtn_Click;
            //
            // closeBtn
            //
            closeBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            closeBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            closeBtn.BackColor = Color.Transparent;
            closeBtn.BackgroundImage = Properties.Resources.Button1;
            closeBtn.BackgroundImageLayout = ImageLayout.Zoom;
            closeBtn.FlatAppearance.BorderSize = 0;
            closeBtn.FlatStyle = FlatStyle.Flat;
            closeBtn.Font = new Font("Consolas", 8.25F, FontStyle.Bold);
            closeBtn.ForeColor = Color.White;
            closeBtn.Image = Properties.Resources.Button1;
            closeBtn.Location = new Point(526, 515);
            closeBtn.Margin = new Padding(2, 2, 2, 2);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(154, 29);
            closeBtn.TabIndex = 2;
            closeBtn.Text = "Close";
            closeBtn.UseVisualStyleBackColor = false;
            closeBtn.Click += closeBtn_Click;
            //
            // startBtn
            //
            startBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            startBtn.BackColor = Color.Transparent;
            startBtn.BackgroundImage = Properties.Resources.Button1;
            startBtn.BackgroundImageLayout = ImageLayout.Zoom;
            startBtn.FlatAppearance.BorderSize = 0;
            startBtn.FlatStyle = FlatStyle.Flat;
            startBtn.Font = new Font("Consolas", 8.25F, FontStyle.Bold);
            startBtn.ForeColor = Color.White;
            startBtn.Location = new Point(198, 515);
            startBtn.Margin = new Padding(2, 2, 2, 2);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(154, 29);
            startBtn.TabIndex = 3;
            startBtn.Text = "Start check-up";
            startBtn.UseVisualStyleBackColor = false;
            startBtn.Click += startBtn_Click;
            //
            // label1
            //
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Airnt", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Teal;
            label1.Location = new Point(51, 28);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(588, 32);
            label1.TabIndex = 0;
            label1.Text = "PATIENT DETAILS";
            label1.TextAlign = ContentAlignment.TopCenter;
            //
            // patient_detail_form
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            BackgroundImage = Properties.Resources.BG2;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(701, 561);
            Controls.Add(label1);
            Controls.Add(nameLbl);
            Controls.Add(infoLbl);
            Controls.Add(nurseTitleLbl);
            Controls.Add(nurseLbl);
            Controls.Add(problemTitleLbl);
            Controls.Add(problemTxt);
            Controls.Add(historyTitleLbl);
            Controls.Add(historyGrid);
            Controls.Add(startBtn);
            Controls.Add(recordBtn);
            Controls.Add(closeBtn);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2, 2, 2, 2);
            Name = "patient_detail_form";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Patient";
            Load += patient_detail_form_Load;
            ((System.ComponentModel.ISupportInitialize)historyGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label nameLbl;
        private Label infoLbl;
        private Label nurseTitleLbl;
        private Label nurseLbl;
        private Label problemTitleLbl;
        private TextBox problemTxt;
        private Label historyTitleLbl;
        private DataGridView historyGrid;
        private Button recordBtn;
        private Button closeBtn;
        private Button startBtn;
        private Label label1;
    }
}
