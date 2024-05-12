using Microsoft.AspNetCore.DataProtection.Internal;
using Microsoft.AspNetCore.Mvc;
using MMNNDotNetCore.Business.Service;
using MMNNDotNetCore.Models;

namespace MMNNDotNetCore.RestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{
    private readonly EFCoreDbService _service;

    public BlogController(EFCoreDbService service)
    {
        _service = service;
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
        if (string.IsNullOrEmpty(model.BlogTitle))
        {
            return Ok("Blog Title is required.");
        }
        if (string.IsNullOrEmpty(model.BlogAuthor))
        {
            return Ok("Blog Author is required.");
        }
        if (string.IsNullOrEmpty(model.BlogContent))
        {
            return Ok("Blog Content is required.");
        }

        int result = _service.Create(model);
        string message = result > 0 ? "Create Success." : "Create Fail!";
        return Ok(message);
    }
    
    [HttpPut]
    public IActionResult Update(BlogModel model)
    {
        BlogModel? item = _service.GetById(model.BlogId);
        if (item is null)
        {
            return Ok("Data not found!");
        }
        
        
        
        int result = _service.Update(model);
        string message = result > 0 ? "Create Success." : "Create Fail!";
        return Ok(message);
    }
    
    [HttpPatch]
    public IActionResult Patch()
    {
        return Ok();
    }
    
    [HttpDelete]
    public IActionResult Delete()
    {
        return Ok();
    }
}