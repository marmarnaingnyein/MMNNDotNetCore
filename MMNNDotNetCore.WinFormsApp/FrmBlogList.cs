using MMNNDotNetCore.Business;
using MMNNDotNetCore.Business.Service;
using MMNNDotNetCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMNNDotNetCore.WinFormsApp
{
    public partial class FrmBlogList : Form
    {
        private readonly DapperService _dapperService;
        public FrmBlogList()
        {
            InitializeComponent();
            dataGridBlog.AutoGenerateColumns = false;
            _dapperService = new DapperService();
        }

        private void FrmBlogList_Load(object sender, EventArgs e)
        {
            List<BlogModel> lst = _dapperService.GetList<BlogModel>(Query.Select);
            List<BlogDataModel> lstData = lst.Select(s => new BlogDataModel()
            {
                IsSelect = 0,
                BlogId = s.BlogId,
                BlogTitle = s.BlogTitle,
                BlogAuthor = s.BlogAuthor,
                BlogContent = s.BlogContent
            }).ToList();
            dataGridBlog.DataSource = lstData;
        }

        private void dataGridBlog_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
