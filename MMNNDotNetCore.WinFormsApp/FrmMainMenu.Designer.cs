using System.ComponentModel;

namespace MMNNDotNetCore.WinFormsApp;

partial class FrmMainMenu
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        menuStrip1 = new MenuStrip();
        blogsToolStripMenuItem = new ToolStripMenuItem();
        blogListToolStripMenuItem = new ToolStripMenuItem();
        newBlogToolStripMenuItem = new ToolStripMenuItem();
        menuStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // menuStrip1
        // 
        menuStrip1.Items.AddRange(new ToolStripItem[] { blogsToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(298, 24);
        menuStrip1.TabIndex = 0;
        menuStrip1.Text = "menuStrip1";
        // 
        // blogsToolStripMenuItem
        // 
        blogsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { blogListToolStripMenuItem, newBlogToolStripMenuItem });
        blogsToolStripMenuItem.Name = "blogsToolStripMenuItem";
        blogsToolStripMenuItem.Size = new Size(48, 20);
        blogsToolStripMenuItem.Text = "Blogs";
        // 
        // blogListToolStripMenuItem
        // 
        blogListToolStripMenuItem.Name = "blogListToolStripMenuItem";
        blogListToolStripMenuItem.Size = new Size(180, 22);
        blogListToolStripMenuItem.Text = "Blog List";
        blogListToolStripMenuItem.Click += blogListToolStripMenuItem_Click;
        // 
        // newBlogToolStripMenuItem
        // 
        newBlogToolStripMenuItem.Name = "newBlogToolStripMenuItem";
        newBlogToolStripMenuItem.Size = new Size(180, 22);
        newBlogToolStripMenuItem.Text = "New Blog";
        newBlogToolStripMenuItem.Click += newBlogToolStripMenuItem_Click;
        // 
        // FrmMainMenu
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(298, 188);
        Controls.Add(menuStrip1);
        MainMenuStrip = menuStrip1;
        Name = "FrmMainMenu";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "FrmMainMenu";
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private MenuStrip menuStrip1;
    private ToolStripMenuItem blogsToolStripMenuItem;
    private ToolStripMenuItem blogListToolStripMenuItem;
    private ToolStripMenuItem newBlogToolStripMenuItem;
}