namespace MMNNDotNetCore.RestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{
    private readonly EFCoreDbService _service;
    private readonly ValidationService _validation;

    public BlogController(EFCoreDbService service, ValidationService validation)
    {
        _service = service;
        _validation = validation;
    }

    [HttpGet]
    public IActionResult GetList()
    {
        List<BlogModel> lst = _service.GetList(new BlogModel());
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
        List<BlogModel> lst = _service.GetList(filter);
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
        
        int result = _service.Create(model);
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
        
        BlogModel? item = _service.GetById(model.BlogId);
        if (item is null)
        {
            return Ok("Data not found!");
        }
        
        int result = _service.Update(model);
        string message = result > 0 ? "Update Success." : "Update Fail!";
        return Ok(message);
    }
    
    [HttpPatch]
    public IActionResult Patch(BlogModel model)
    {
        BlogModel? item = _service.GetById(model.BlogId);
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
        
        int result = _service.Update(item);
        string message = result > 0 ? "Update Success." : "Update Fail!";
        return Ok(message);
    }
    
    [HttpDelete]
    public IActionResult Delete(int id)
    {
        BlogModel? item = _service.GetById(id);
        if (item is null)
        {
            return Ok("Data not found!");
        }

        int result = _service.Delete(item);
        string message = result > 0 ? "Delete Success." : "Delete Fail!";
        return Ok(message);
    }
}