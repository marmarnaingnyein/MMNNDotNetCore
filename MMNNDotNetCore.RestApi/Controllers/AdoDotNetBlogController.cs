using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
        
        int result = _service.Execute(Query.Create, model);
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
        
        BlogModel? item = _service.GetFirstById<BlogModel>(Query.SelectById, model);
        if (item is null)
        {
            return Ok("Data not found!");
        }
        
        int result = _service.Execute(Query.Update, model);
        string message = result > 0 ? "Update Success." : "Update Fail!";
        return Ok(message);
    }
    
    [HttpPatch]
    public IActionResult Patch(BlogModel model)
    {
        BlogModel? item = _service.GetFirstById<BlogModel>(Query.SelectById, model);
        if (item is null)
        {
            return Ok("Data not found!");
        }

        if (!string.IsNullOrEmpty(model.BlogTitle))
        {
            item.BlogTitle = model.BlogTitle;
        }
        if (!string.IsNullOrEmpty(model.BlogAuthor))
        {
            item.BlogAuthor = model.BlogAuthor;
        }
        if (!string.IsNullOrEmpty(model.BlogContent))
        {
            item.BlogContent = model.BlogContent;
        }
        
        int result = _service.Execute(Query.Update, model);
        string message = result > 0 ? "Update Success." : "Update Fail!";
        return Ok(message);
    }
    
    [HttpDelete]
    public IActionResult Delete(int id)
    {
        BlogModel? item = _service.GetFirstById<BlogModel>(Query.SelectById, 
            new BlogModel{BlogId = id });
        if (item is null)
        {
            return Ok("Data not found!");
        }

        int result = _service.Execute(Query.Delete, item);
        string message = result > 0 ? "Delete Success." : "Delete Fail!";
        return Ok(message);
    }
}