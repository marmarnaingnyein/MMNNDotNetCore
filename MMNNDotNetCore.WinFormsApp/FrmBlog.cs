using MMNNDotNetCore.Business;
using MMNNDotNetCore.Business.Service;
using MMNNDotNetCore.Models;

namespace MMNNDotNetCore.WinFormsApp;

public partial class FrmBlog : Form
{
    private readonly DapperService _dapperService;
    private bool IsNew = true;
    public FrmBlog()
    {
        Initialize();
        _dapperService = new DapperService();
    }

    public FrmBlog(int blogId)
    {
        IsNew = false;
        Initialize();
        _dapperService = new DapperService();

        BlogModel? item = _dapperService.GetFirstById<BlogModel>(Query.SelectById,
           new BlogModel { BlogId = blogId });

        if (item != null)
        {
            txtTitle.Text = item.BlogTitle;
            txtAuthor.Text = item.BlogAuthor;
            txtContent.Text = item.BlogContent;
        }
    }

    private async void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                MessageBox.Show("Blog Title is required!");
                return;
            }

            if (string.IsNullOrEmpty(txtAuthor.Text))
            {
                MessageBox.Show("Blog Author is required!");
                return;
            }

            if (string.IsNullOrEmpty(txtContent.Text))
            {
                MessageBox.Show("Blog Content is required!");
                return;
            }

            BlogModel blogModel = new BlogModel()
            {
                BlogTitle = txtTitle.Text.Trim(),
                BlogAuthor = txtAuthor.Text.Trim(),
                BlogContent = txtContent.Text.Trim()
            };

            int result = _dapperService.Execute(Query.Create, blogModel);
            string message = result > 0 ? "Saving Successful." : "Saving Fail!";

            if (result == 0)
            {
                MessageBox.Show(message, "Blog Create", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(message, "Blog Create", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clear();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();

        txtTitle.Focus();
    }

    private void Clear()
    {
        txtTitle.Clear();
        txtAuthor.Clear();
        txtContent.Clear();
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {

    }

    private void Initialize()
    {
        InitializeComponent();
        btnSave.Visible = IsNew;
        btnEdit.Visible = !IsNew;
    }
}