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
            //timer1.Start();
            SelectList();
        }

        private void SelectList()
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<BlogDataModel> lstData = (List<BlogDataModel>)Convert.ChangeType(dataGridBlog.DataSource, typeof(List<BlogDataModel>));
            List<BlogDataModel> lstDelete = lstData.Where(w => w.IsSelect == 1).ToList();

            foreach (BlogDataModel item in lstDelete)
            {
                int result = _dapperService.Execute(Query.Delete, item);
            }

            MessageBox.Show("Delete successfully.", "Blog Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SelectList();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            List<BlogDataModel> lstData = (List<BlogDataModel>)Convert.ChangeType(dataGridBlog.DataSource, typeof(List<BlogDataModel>));
            int count = lstData.Where(w => w.IsSelect == 1).Count();

            if (count > 1)
            {
                MessageBox.Show("Please select one row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            BlogDataModel item = lstData.Where(w => w.IsSelect == 1).FirstOrDefault();

            FrmBlog frmBlog = new FrmBlog();
            frmBlog.Edit(item.BlogId);
        }

    }
}
