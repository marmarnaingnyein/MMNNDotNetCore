using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MMNNDotNetCore.EFCore.EfAppDbContext;
using MMNNDotNetCore.Models;

namespace MMNNDotNetCore.PizzaApi.Features.Pizza;

[Route("api/{controller}")]
[ApiController]
public class PizzaController : Controller
{
    private readonly EfAppDbContext _db;

    public PizzaController()
    {
        _db = new EfAppDbContext();
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        List<PizzaModel> lst = await _db.Pizzas.AsNoTracking().ToListAsync();
        return Ok(lst);
    }

    [HttpGet("Extra")]
    public async Task<IActionResult> GetExtraList()
    {
        List<PizzaExtraModel> lst = await _db.PizzaExtras.AsNoTracking().ToListAsync();
        return Ok(lst);
    }
}