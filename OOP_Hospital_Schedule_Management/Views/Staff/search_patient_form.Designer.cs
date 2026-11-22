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
            ((System.ComponentModel.ISupportInitialize)resultsGrid).BeginInit();
            SuspendLayout();
            // 
            // searchLbl
            // 
            searchLbl.AutoSize = true;
            searchLbl.Location = new Point(20, 20);
            searchLbl.Name = "searchLbl";
            searchLbl.Text = "Name or contact no.:";
            // 
            // searchTxt
            // 
            searchTxt.Location = new Point(200, 16);
            searchTxt.Name = "searchTxt";
            searchTxt.Size = new Size(420, 31);
            searchTxt.TabIndex = 0;
            // 
            // searchBtn
            // 
            searchBtn.Location = new Point(635, 13);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(120, 38);
            searchBtn.TabIndex = 1;
            searchBtn.Text = "Search";
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // countLbl
            // 
            countLbl.AutoSize = true;
            countLbl.Location = new Point(20, 62);
            countLbl.Name = "countLbl";
            countLbl.Text = "";
            // 
            // resultsGrid
            // 
            resultsGrid.AllowUserToAddRows = false;
            resultsGrid.AllowUserToDeleteRows = false;
            resultsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            resultsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            resultsGrid.Location = new Point(20, 95);
            resultsGrid.Name = "resultsGrid";
            resultsGrid.ReadOnly = true;
            resultsGrid.RowHeadersVisible = false;
            resultsGrid.RowHeadersWidth = 62;
            resultsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            resultsGrid.Size = new Size(940, 420);
            resultsGrid.TabIndex = 2;
            // 
            // closeBtn
            // 
            closeBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            closeBtn.Location = new Point(790, 530);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(170, 45);
            closeBtn.TabIndex = 3;
            closeBtn.Text = "Close";
            closeBtn.UseVisualStyleBackColor = true;
            closeBtn.Click += closeBtn_Click;
            // 
            // search_patient_form
            // 
            AcceptButton = searchBtn;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 590);
            Controls.Add(searchLbl);
            Controls.Add(searchTxt);
            Controls.Add(searchBtn);
            Controls.Add(countLbl);
            Controls.Add(resultsGrid);
            Controls.Add(closeBtn);
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
    }
}