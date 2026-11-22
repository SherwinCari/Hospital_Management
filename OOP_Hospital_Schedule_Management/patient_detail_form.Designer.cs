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
            ((System.ComponentModel.ISupportInitialize)historyGrid).BeginInit();
            SuspendLayout();
            // 
            // nameLbl
            // 
            nameLbl.AutoSize = false;
            nameLbl.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            nameLbl.Location = new Point(20, 15);
            nameLbl.Name = "nameLbl";
            nameLbl.Size = new Size(840, 32);
            nameLbl.Text = "Patient name";
            // 
            // infoLbl
            // 
            infoLbl.AutoSize = false;
            infoLbl.Location = new Point(20, 50);
            infoLbl.Name = "infoLbl";
            infoLbl.Size = new Size(840, 105);
            infoLbl.Text = "Patient info";
            // 
            // nurseTitleLbl
            // 
            nurseTitleLbl.AutoSize = false;
            nurseTitleLbl.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            nurseTitleLbl.Location = new Point(20, 165);
            nurseTitleLbl.Name = "nurseTitleLbl";
            nurseTitleLbl.Size = new Size(840, 26);
            nurseTitleLbl.Text = "Nurse summary (this visit)";
            // 
            // nurseLbl
            // 
            nurseLbl.AutoSize = false;
            nurseLbl.Location = new Point(20, 192);
            nurseLbl.Name = "nurseLbl";
            nurseLbl.Size = new Size(840, 65);
            nurseLbl.Text = "Vitals";
            // 
            // problemTitleLbl
            // 
            problemTitleLbl.AutoSize = false;
            problemTitleLbl.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            problemTitleLbl.Location = new Point(20, 265);
            problemTitleLbl.Name = "problemTitleLbl";
            problemTitleLbl.Size = new Size(840, 26);
            problemTitleLbl.Text = "Problem description (entered at registration)";
            // 
            // problemTxt
            // 
            problemTxt.Location = new Point(20, 292);
            problemTxt.Multiline = true;
            problemTxt.Name = "problemTxt";
            problemTxt.ReadOnly = true;
            problemTxt.ScrollBars = ScrollBars.Vertical;
            problemTxt.Size = new Size(840, 70);
            problemTxt.TabStop = false;
            // 
            // historyTitleLbl
            // 
            historyTitleLbl.AutoSize = false;
            historyTitleLbl.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            historyTitleLbl.Location = new Point(20, 372);
            historyTitleLbl.Name = "historyTitleLbl";
            historyTitleLbl.Size = new Size(840, 26);
            historyTitleLbl.Text = "Record history";
            // 
            // historyGrid
            // 
            historyGrid.AllowUserToAddRows = false;
            historyGrid.AllowUserToDeleteRows = false;
            historyGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            historyGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            historyGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            historyGrid.Location = new Point(20, 402);
            historyGrid.Name = "historyGrid";
            historyGrid.ReadOnly = true;
            historyGrid.RowHeadersVisible = false;
            historyGrid.RowHeadersWidth = 62;
            historyGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            historyGrid.Size = new Size(840, 193);
            historyGrid.TabIndex = 0;
            // 
            // recordBtn
            // 
            recordBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            recordBtn.Location = new Point(20, 615);
            recordBtn.Name = "recordBtn";
            recordBtn.Size = new Size(220, 48);
            recordBtn.TabIndex = 1;
            recordBtn.Text = "Record History";
            recordBtn.UseVisualStyleBackColor = true;
            recordBtn.Click += recordBtn_Click;
            // 
            // closeBtn
            // 
            closeBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            closeBtn.Location = new Point(640, 615);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(220, 48);
            closeBtn.TabIndex = 2;
            closeBtn.Text = "Close";
            closeBtn.UseVisualStyleBackColor = true;
            closeBtn.Click += closeBtn_Click;
            // 
            // patient_detail_form
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 680);
            Controls.Add(nameLbl);
            Controls.Add(infoLbl);
            Controls.Add(nurseTitleLbl);
            Controls.Add(nurseLbl);
            Controls.Add(problemTitleLbl);
            Controls.Add(problemTxt);
            Controls.Add(historyTitleLbl);
            Controls.Add(historyGrid);
            Controls.Add(recordBtn);
            Controls.Add(closeBtn);
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
    }
}