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
            colSelect = new DataGridViewCheckBoxColumn();
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
            dataGridBlog.Columns.AddRange(new DataGridViewColumn[] { colID, colSelect, colTitle, colAuthor, colContent });
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
            colID.FillWeight = 5F;
            colID.HeaderText = "ID";
            colID.MaxInputLength = 1;
            colID.Name = "colID";
            colID.ReadOnly = true;
            colID.Resizable = DataGridViewTriState.False;
            colID.Visible = false;
            colID.Width = 5;
            // 
            // colSelect
            // 
            colSelect.DataPropertyName = "IsSelect";
            colSelect.FalseValue = "0";
            colSelect.FillWeight = 13.7625122F;
            colSelect.HeaderText = "";
            colSelect.Name = "colSelect";
            colSelect.ReadOnly = true;
            colSelect.Resizable = DataGridViewTriState.False;
            colSelect.TrueValue = "1";
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
            colContent.FillWeight = 189.922668F;
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
        private DataGridViewCheckBoxColumn colSelect;
        private DataGridViewTextBoxColumn colTitle;
        private DataGridViewTextBoxColumn colAuthor;
        private DataGridViewTextBoxColumn colContent;
    }
}