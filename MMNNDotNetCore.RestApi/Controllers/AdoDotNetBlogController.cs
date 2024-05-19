using Microsoft.AspNetCore.Mvc;
using MMNNDotNetCore.RestApi.Service;

namespace MMNNDotNetCore.RestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdoDotNetBlogController : Controller
{
    private readonly ValidationService _validation;

}