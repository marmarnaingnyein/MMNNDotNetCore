namespace MMNNDotNetCore.RestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DapperBlogController : Controller
{
    private readonly DapperService _service;
    private readonly ValidationService _validation;

    public DapperBlogController(DapperService service, ValidationService validation)
    {
        _service = service;
        _validation = validation;
    }

    [HttpGet]
    public IActionResult GetList()
    {
        List<BlogModel> lst = _service.GetList<BlogModel>(Query.Select);
        return Ok(lst);
    }
    
    [HttpPost]
    [Route("selectBy")]
    public IActionResult GetList(BlogModel? filter)
    {
        if (filter is null)
        {
            return Ok("Filter is required.");
        }
        
        string query = Query.Select;
        if (filter.BlogId > 0)
        {
            query += " Where BlogId = @BlogId";
        }
        else if (!string.IsNullOrEmpty(filter.BlogTitle))
        {
            query += " Where BlogTitle = @BlogTitle";
        }
        else if (!string.IsNullOrEmpty(filter.BlogAuthor))
        {
            query += " Where BlogAuthor = @BlogAuthor";
        }

        List<BlogModel> lst = _service.GetList<BlogModel>(query, filter);
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