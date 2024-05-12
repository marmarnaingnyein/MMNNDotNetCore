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
    public IActionResult Create()
    {
        return Ok();
    }
    
    [HttpPut]
    public IActionResult Update()
    {
        return Ok();
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