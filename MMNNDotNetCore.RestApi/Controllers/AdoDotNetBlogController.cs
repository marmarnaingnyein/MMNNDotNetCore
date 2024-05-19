using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using MMNNDotNetCore.Business;
using MMNNDotNetCore.Business.Service;
using MMNNDotNetCore.Models;
using MMNNDotNetCore.RestApi.Service;

namespace MMNNDotNetCore.RestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdoDotNetBlogController : Controller
{
    private readonly AdoDotNetService _service;
    private readonly ValidationService _validation;

    public AdoDotNetBlogController(AdoDotNetService service, ValidationService validation)
    {
        _service = service;
        _validation = validation;
    }
    
    [HttpGet]
    public IActionResult GetList()
    {
        List<BlogModel> lst = new List<BlogModel>();
        DataTable data = _service.GetList(Query.Select);
        foreach (DataRow item in data.Rows)
        {
            lst.Add(new BlogModel()
            {
                BlogId = Convert.ToInt32(item["BlogId"]),
                BlogTitle = item["BlogTitle"].ToString()!,
                BlogAuthor = item["BlogAuthor"].ToString()!,
                BlogContent = item["BlogContent"].ToString()!
            });
        }
        
        return Ok(lst);
    }
    
    [HttpPost]
    [Route("selectBy")]
    public IActionResult GetList(BlogModel? filter)
    {
        List<BlogModel> lst = new List<BlogModel>();

        if (filter is null)
        {
            return Ok("Filter is required.");
        }
        SqlParameter para = new SqlParameter();
        string query = Query.Select;
        if (filter.BlogId > 0)
        {
            query += " Where BlogId = @BlogId";
            para = new SqlParameter("@BlogId", filter.BlogId);
        }
        else if (!string.IsNullOrEmpty(filter.BlogTitle))
        {
            query += " Where BlogTitle = @BlogTitle";
            para = new SqlParameter("@BlogTitle", filter.BlogTitle);
        }
        else if (!string.IsNullOrEmpty(filter.BlogAuthor))
        {
            query += " Where BlogAuthor = @BlogAuthor";
            para = new SqlParameter("@BlogAuthor", filter.BlogAuthor);
        }

        DataTable data = _service.GetList(query, para);
        
        foreach (DataRow item in data.Rows)
        {
            lst.Add(new BlogModel()
            {
                BlogId = Convert.ToInt32(item["BlogId"]),
                BlogTitle = item["BlogTitle"].ToString()!,
                BlogAuthor = item["BlogAuthor"].ToString()!,
                BlogContent = item["BlogContent"].ToString()!
            });
        }
        return Ok(lst);
    }
    
    [HttpPost]
    public IActionResult Create(BlogModel model)
    {
        string validate = _validation.CheckRequiredField(model);
        if (!string.IsNullOrEmpty(validate))
        {
            return Ok(validate);
        }

        SqlParameter[] lstpara = new[]
        {
            new SqlParameter("@BlogTitle", model.BlogTitle),
            new SqlParameter("@BlogAuthor", model.BlogAuthor),
            new SqlParameter("@BlogContent", model.BlogContent)
        };
        
        int result = _service.Execute(Query.Create, lstpara);

        string message = result > 0 ? "Create Success." : "Create Fail!";
        
        return Ok(message);
    }
    
    [HttpPut]
    public IActionResult Update(BlogModel model)
    {
        string validate = _validation.CheckRequiredField(model);
        if (!string.IsNullOrEmpty(validate))
        {
            return Ok(validate);
        }
        
        SqlParameter para = new SqlParameter("@BlogId", model.BlogId);
        
        DataTable data = _service.GetList(Query.SelectById, para);
        if (data.Rows.Count == 0)
        {
            return Ok("Data not found!");
        }
        
        SqlParameter[] lstpara = new[]
        {
            new SqlParameter("@BlogTitle", model.BlogTitle),
            new SqlParameter("@BlogAuthor", model.BlogAuthor),
            new SqlParameter("@BlogContent", model.BlogContent)
        };
        
        int result = _service.Execute(Query.Update, lstpara);

        string message = result > 0 ? "Update Success." : "Update Fail!";
        return Ok(message);
    }
    
    [HttpPatch]
    public IActionResult Patch(BlogModel model)
    {
        SqlParameter para = new SqlParameter("@BlogId", model.BlogId);
        
        DataTable data = _service.GetList(Query.SelectById, para);
        if (data.Rows.Count == 0)
        {
            return Ok("Data not found!");
        }
        
        List<SqlParameter> lstpara = new List<SqlParameter>();
        lstpara.Add(new SqlParameter("@BlogId", model.BlogId));

        if (!string.IsNullOrEmpty(model.BlogTitle))
        {
            lstpara.Add(new SqlParameter("@BlogTitle", model.BlogTitle));
        }
        if (!string.IsNullOrEmpty(model.BlogAuthor))
        {
            lstpara.Add(new SqlParameter("@BlogAuthor", model.BlogAuthor));
        }
        if (!string.IsNullOrEmpty(model.BlogContent))
        {
            lstpara.Add(new SqlParameter("@BlogContent", model.BlogContent));
        }
        
        int result = _service.Execute(Query.Update, lstpara.ToArray());
        string message = result > 0 ? "Update Success." : "Update Fail!";
        return Ok(message);
    }
    
    [HttpDelete]
    public IActionResult Delete(int id)
    {
        SqlParameter para = new SqlParameter("@BlogId", id);
        
        DataTable data = _service.GetList(Query.SelectById, para);
        if (data.Rows.Count == 0)
        {
            return Ok("Data not found!");
        }

        List<SqlParameter> lstpara = new List<SqlParameter>();
        lstpara.Add(new SqlParameter("@BlogId", id));
        
        int result = _service.Execute(Query.Delete, lstpara.ToArray());

        string message = result > 0 ? "Delete Success." : "Delete Fail!";
        return Ok(message);
    }
}