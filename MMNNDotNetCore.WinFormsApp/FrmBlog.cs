using MMNNDotNetCore.Business;
using MMNNDotNetCore.Business.Service;
using MMNNDotNetCore.Models;

namespace MMNNDotNetCore.WinFormsApp;

public partial class FrmBlog : Form
{
    private readonly DapperService _dapperService;
    private bool IsNew = true;
    private int _BlogId = 0;
    public FrmBlog()
    {
        Initialize();
        _dapperService = new DapperService();
    }

    public FrmBlog(int blogId)
    {
        _BlogId = blogId;
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
            string message = CheckRequiredFields();
            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message);
                return;
            }

            BlogModel blogModel = new BlogModel()
            {
                BlogTitle = txtTitle.Text.Trim(),
                BlogAuthor = txtAuthor.Text.Trim(),
                BlogContent = txtContent.Text.Trim()
            };

            int result = _dapperService.Execute(Query.Create, blogModel);
            message = result > 0 ? "Saving Successful." : "Saving Fail!";

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

    private string CheckRequiredFields()
    {
        string message = string.Empty;
        if (string.IsNullOrEmpty(txtTitle.Text))
        {
            message = "Blog Title is required!";
            return message;
        }

        if (string.IsNullOrEmpty(txtAuthor.Text))
        {
            message = "Blog Author is required!";
            return message;
        }

        if (string.IsNullOrEmpty(txtContent.Text))
        {
            message = "Blog Content is required!";
            return message;
        }

        return message;
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            string message = CheckRequiredFields();
            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message);
                return;
            }

            BlogModel blogModel = new BlogModel()
            {
                BlogId = _BlogId,
                BlogTitle = txtTitle.Text.Trim(),
                BlogAuthor = txtAuthor.Text.Trim(),
                BlogContent = txtContent.Text.Trim()
            };

            int result = _dapperService.Execute(Query.Update, blogModel);
            message = result > 0 ? "Saving Successful." : "Saving Fail!";

            if (result == 0)
            {
                MessageBox.Show(message, "Blog Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(message, "Blog Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void Initialize()
    {
        InitializeComponent();
        btnSave.Visible = IsNew;
        btnEdit.Visible = !IsNew;
    }
}