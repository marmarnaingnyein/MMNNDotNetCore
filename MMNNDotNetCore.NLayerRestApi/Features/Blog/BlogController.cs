using Microsoft.AspNetCore.Mvc;
using MMNNDotNetCore.NLayerRestApi.Model;

namespace MMNNDotNetCore.NLayerRestApi.Features.Blog;

[Route("api/[controller]")]
[ApiController]
public class BlogController : Controller
{
    private BL_Blog _blogBl;

    public BlogController(BL_Blog blogBl)
    {
        _blogBl = blogBl;
    }
    
    
    [HttpGet]
    public IActionResult GetList()
    {
        List<BlogModel> lst = _blogBl.GetList(new BlogModel());
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
        List<BlogModel> lst = _blogBl.GetList(filter);
        return Ok(lst);
    }
    
    
    [HttpPost]
    [Route("selectById")]
    public IActionResult SelectById(int id)
    {
        BlogResponseModel res = _blogBl.GetById(id);
        if (res.Response.IsError)
        {
            return Ok($"{res.Response.ResMessage}");
        }
        
        return Ok(res.ResData);
    }

    
    [HttpPost]
    public IActionResult Create(BlogModel model)
    {
        BlogResponseModel res = _blogBl.Create(model);
        return Ok(res.Response.ResMessage);
    }
    
    [HttpPut]
    public IActionResult Update(BlogModel model)
    {
        BlogResponseModel res = _blogBl.Update(model);
        return Ok(res.Response.ResMessage);
    }
    
    [HttpDelete]
    public IActionResult Delete(int id)
    {
        BlogResponseModel res = _blogBl.Delete(id);
        return Ok(res.Response.ResMessage);
    }
}