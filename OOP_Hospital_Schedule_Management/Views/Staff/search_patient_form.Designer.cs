using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace OOP_Hospital_Schedule_Management.staff_tab
{
    partial class search_patient_form
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
            searchLbl = new Label();
            searchTxt = new TextBox();
            searchBtn = new Button();
            countLbl = new Label();
            resultsGrid = new DataGridView();
            closeBtn = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)resultsGrid).BeginInit();
            SuspendLayout();
            //
            // searchLbl
            //
            searchLbl.AutoSize = true;
            searchLbl.BackColor = Color.Transparent;
            searchLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            searchLbl.ForeColor = Color.Teal;
            searchLbl.Location = new Point(36, 99);
            searchLbl.Margin = new Padding(2, 0, 2, 0);
            searchLbl.Name = "searchLbl";
            searchLbl.Size = new Size(116, 15);
            searchLbl.TabIndex = 0;
            searchLbl.Text = "Name or contact no:";
            //
            // searchTxt
            //
            searchTxt.BackColor = Color.White;
            searchTxt.Location = new Point(156, 96);
            searchTxt.Margin = new Padding(2, 2, 2, 2);
            searchTxt.Name = "searchTxt";
            searchTxt.Size = new Size(295, 23);
            searchTxt.TabIndex = 0;
            //
            // searchBtn
            //
            searchBtn.BackColor = Color.Transparent;
            searchBtn.FlatAppearance.BorderSize = 0;
            searchBtn.FlatStyle = FlatStyle.Flat;
            searchBtn.ForeColor = Color.Transparent;
            searchBtn.Image = Properties.Resources.Button;
            searchBtn.Location = new Point(455, 96);
            searchBtn.Margin = new Padding(2, 2, 2, 2);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(90, 23);
            searchBtn.TabIndex = 1;
            searchBtn.Text = "Search";
            searchBtn.UseVisualStyleBackColor = false;
            searchBtn.Click += searchBtn_Click;
            //
            // countLbl
            //
            countLbl.AutoSize = true;
            countLbl.Location = new Point(14, 37);
            countLbl.Margin = new Padding(2, 0, 2, 0);
            countLbl.Name = "countLbl";
            countLbl.Size = new Size(0, 15);
            countLbl.TabIndex = 2;
            //
            // resultsGrid
            //
            resultsGrid.AllowUserToAddRows = false;
            resultsGrid.AllowUserToDeleteRows = false;
            resultsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            resultsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            resultsGrid.BackgroundColor = Color.White;
            resultsGrid.BorderStyle = BorderStyle.Fixed3D;
            resultsGrid.Location = new Point(36, 130);
            resultsGrid.Margin = new Padding(2, 2, 2, 2);
            resultsGrid.Name = "resultsGrid";
            resultsGrid.ReadOnly = true;
            resultsGrid.RowHeadersVisible = false;
            resultsGrid.RowHeadersWidth = 62;
            resultsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            resultsGrid.Size = new Size(509, 251);
            resultsGrid.TabIndex = 2;
            //
            // closeBtn
            //
            closeBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            closeBtn.BackColor = Color.Transparent;
            closeBtn.FlatAppearance.BorderSize = 0;
            closeBtn.FlatStyle = FlatStyle.Flat;
            closeBtn.ForeColor = Color.Transparent;
            closeBtn.Image = Properties.Resources.Button1;
            closeBtn.Location = new Point(426, 388);
            closeBtn.Margin = new Padding(2, 2, 2, 2);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(119, 27);
            closeBtn.TabIndex = 3;
            closeBtn.Text = "Close";
            closeBtn.UseVisualStyleBackColor = false;
            closeBtn.Click += closeBtn_Click;
            //
            // label1
            //
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new System.Drawing.Font("Airnt", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Teal;
            label1.Location = new Point(163, 37);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(251, 21);
            label1.TabIndex = 0;
            label1.Text = "PATIENT SEARCH";
            //
            // search_patient_form
            //
            AcceptButton = searchBtn;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            BackgroundImage = Properties.Resources.BG2;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(583, 430);
            Controls.Add(label1);
            Controls.Add(searchLbl);
            Controls.Add(searchTxt);
            Controls.Add(searchBtn);
            Controls.Add(countLbl);
            Controls.Add(resultsGrid);
            Controls.Add(closeBtn);
            DoubleBuffered = true;
            Margin = new Padding(2, 2, 2, 2);
            Name = "search_patient_form";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Search existing patients";
            Load += search_patient_form_Load;
            ((System.ComponentModel.ISupportInitialize)resultsGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label searchLbl;
        private TextBox searchTxt;
        private Button searchBtn;
        private Label countLbl;
        private DataGridView resultsGrid;
        private Button closeBtn;
        private Label label1;
    }
}