using Microsoft.AspNetCore.Mvc;
using MMNNDotNetCore.Business.Service;
using MMNNDotNetCore.RestApi.Service;

namespace MMNNDotNetCore.RestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdoDotNetBlogController : Controller
{
    private readonly AdoDotNetService _service;
    private readonly ValidationService _validation;

}