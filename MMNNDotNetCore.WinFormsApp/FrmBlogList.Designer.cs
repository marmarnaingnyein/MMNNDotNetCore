namespace MMNNDotNetCore.WinFormsApp
{
    partial class FrmBlogList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridBlog = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            colCheckBox = new DataGridViewCheckBoxColumn();
            colTitle = new DataGridViewTextBoxColumn();
            colAuthor = new DataGridViewTextBoxColumn();
            colContent = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridBlog).BeginInit();
            SuspendLayout();
            // 
            // dataGridBlog
            // 
            dataGridBlog.AllowUserToAddRows = false;
            dataGridBlog.AllowUserToDeleteRows = false;
            dataGridBlog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridBlog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridBlog.Columns.AddRange(new DataGridViewColumn[] { colID, colCheckBox, colTitle, colAuthor, colContent });
            dataGridBlog.Dock = DockStyle.Fill;
            dataGridBlog.Location = new Point(0, 0);
            dataGridBlog.Name = "dataGridBlog";
            dataGridBlog.ReadOnly = true;
            dataGridBlog.RowTemplate.Height = 25;
            dataGridBlog.Size = new Size(591, 450);
            dataGridBlog.TabIndex = 0;
            // 
            // colID
            // 
            colID.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colID.DataPropertyName = "BlogId";
            colID.HeaderText = "ID";
            colID.Name = "colID";
            colID.ReadOnly = true;
            colID.Visible = false;
            colID.Width = 137;
            // 
            // colCheckBox
            // 
            colCheckBox.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colCheckBox.FillWeight = 40.54054F;
            colCheckBox.HeaderText = "";
            colCheckBox.IndeterminateValue = "1";
            colCheckBox.Name = "colCheckBox";
            colCheckBox.ReadOnly = true;
            colCheckBox.Resizable = DataGridViewTriState.True;
            colCheckBox.SortMode = DataGridViewColumnSortMode.Automatic;
            colCheckBox.Width = 19;
            // 
            // colTitle
            // 
            colTitle.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colTitle.DataPropertyName = "BlogTitle";
            colTitle.HeaderText = "Title";
            colTitle.Name = "colTitle";
            colTitle.ReadOnly = true;
            colTitle.Width = 54;
            // 
            // colAuthor
            // 
            colAuthor.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colAuthor.DataPropertyName = "BlogAuthor";
            colAuthor.HeaderText = "Author";
            colAuthor.Name = "colAuthor";
            colAuthor.ReadOnly = true;
            colAuthor.Width = 69;
            // 
            // colContent
            // 
            colContent.DataPropertyName = "BlogContent";
            colContent.FillWeight = 129.729736F;
            colContent.HeaderText = "Content";
            colContent.Name = "colContent";
            colContent.ReadOnly = true;
            // 
            // FrmBlogList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(591, 450);
            Controls.Add(dataGridBlog);
            Name = "FrmBlogList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmBlogList";
            Load += FrmBlogList_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridBlog).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridBlog;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewCheckBoxColumn colCheckBox;
        private DataGridViewTextBoxColumn colTitle;
        private DataGridViewTextBoxColumn colAuthor;
        private DataGridViewTextBoxColumn colContent;
    }
}