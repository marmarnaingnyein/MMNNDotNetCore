using System.Windows.Forms;

namespace MMNNDotNetCore.WinFormsApp;

public partial class FrmMainMenu : Form
{
    public FrmMainMenu()
    {
        InitializeComponent();
    }

    private void newBlogToolStripMenuItem_Click(object sender, EventArgs e)
    {
        FrmBlog frmBlog = new FrmBlog();
        frmBlog.ShowDialog();
    }

    private void blogListToolStripMenuItem_Click(object sender, EventArgs e)
    {
        FrmBlogList frmBlogList = new FrmBlogList();
        frmBlogList.ShowDialog();
    }
}