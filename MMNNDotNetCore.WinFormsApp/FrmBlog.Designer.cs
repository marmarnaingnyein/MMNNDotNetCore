namespace MMNNDotNetCore.WinFormsApp;

partial class FrmBlog
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        btnSave = new Button();
        label1 = new Label();
        label2 = new Label();
        label3 = new Label();
        txtTitle = new TextBox();
        txtAuthor = new TextBox();
        txtContent = new TextBox();
        btnCancel = new Button();
        btnEdit = new Button();
        SuspendLayout();
        // 
        // btnSave
        // 
        btnSave.BackColor = Color.FromArgb(0, 192, 192);
        btnSave.DialogResult = DialogResult.OK;
        btnSave.FlatAppearance.BorderSize = 0;
        btnSave.FlatStyle = FlatStyle.Flat;
        btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        btnSave.ForeColor = Color.Cornsilk;
        btnSave.Location = new Point(362, 274);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(75, 26);
        btnSave.TabIndex = 0;
        btnSave.Text = "&Add";
        btnSave.UseVisualStyleBackColor = false;
        btnSave.Click += btnSave_Click;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        label1.Location = new Point(23, 28);
        label1.Name = "label1";
        label1.Size = new Size(46, 19);
        label1.TabIndex = 1;
        label1.Text = "Title :";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        label2.Location = new Point(23, 135);
        label2.Name = "label2";
        label2.Size = new Size(69, 19);
        label2.TabIndex = 2;
        label2.Text = "Content :";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        label3.Location = new Point(23, 82);
        label3.Name = "label3";
        label3.Size = new Size(63, 19);
        label3.TabIndex = 3;
        label3.Text = "Author :";
        // 
        // txtTitle
        // 
        txtTitle.Location = new Point(115, 25);
        txtTitle.Name = "txtTitle";
        txtTitle.Size = new Size(322, 25);
        txtTitle.TabIndex = 4;
        // 
        // txtAuthor
        // 
        txtAuthor.Location = new Point(115, 79);
        txtAuthor.Name = "txtAuthor";
        txtAuthor.Size = new Size(322, 25);
        txtAuthor.TabIndex = 5;
        // 
        // txtContent
        // 
        txtContent.Location = new Point(115, 135);
        txtContent.Multiline = true;
        txtContent.Name = "txtContent";
        txtContent.Size = new Size(322, 90);
        txtContent.TabIndex = 6;
        // 
        // btnCancel
        // 
        btnCancel.BackColor = Color.FromArgb(97, 97, 97);
        btnCancel.FlatAppearance.BorderSize = 0;
        btnCancel.FlatStyle = FlatStyle.Flat;
        btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        btnCancel.ForeColor = SystemColors.Control;
        btnCancel.Location = new Point(255, 274);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(75, 26);
        btnCancel.TabIndex = 7;
        btnCancel.Text = "&Cancel";
        btnCancel.UseVisualStyleBackColor = false;
        btnCancel.Click += btnCancel_Click;
        // 
        // btnEdit
        // 
        btnEdit.BackColor = Color.Lime;
        btnEdit.Cursor = Cursors.IBeam;
        btnEdit.FlatAppearance.BorderSize = 0;
        btnEdit.FlatStyle = FlatStyle.Flat;
        btnEdit.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        btnEdit.ForeColor = Color.Cornsilk;
        btnEdit.Location = new Point(362, 274);
        btnEdit.Name = "btnEdit";
        btnEdit.Size = new Size(75, 26);
        btnEdit.TabIndex = 8;
        btnEdit.Text = "&Update";
        btnEdit.UseVisualStyleBackColor = false;
        btnEdit.Click += btnEdit_Click;
        // 
        // FrmBlog
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(484, 320);
        Controls.Add(btnEdit);
        Controls.Add(btnCancel);
        Controls.Add(txtContent);
        Controls.Add(txtAuthor);
        Controls.Add(txtTitle);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(btnSave);
        Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        Name = "FrmBlog";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Blog";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button btnSave;
    private Label label1;
    private Label label2;
    private Label label3;
    private TextBox txtTitle;
    private TextBox txtAuthor;
    private TextBox txtContent;
    private Button btnCancel;
    private Button btnEdit;
}