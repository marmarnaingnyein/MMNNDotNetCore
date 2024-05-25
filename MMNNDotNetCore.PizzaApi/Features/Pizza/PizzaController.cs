using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MMNNDotNetCore.EFCore.EfAppDbContext;
using MMNNDotNetCore.Models;
using MMNNDotNetCore.PizzaApi.Models;

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

    [HttpPost("Order")]
    public async Task<IActionResult> OrderAsync(OrderRequestModel reqModel)
    {
        if (reqModel.PizzaId <= 0)
        {
            return Ok("Pizza Id is required.");
        }
        
        decimal totalAmount = await _db.Pizzas.AsNoTracking()
            .Where(x => x.PizzaId == reqModel.PizzaId)
            .Select(s => s.Price).FirstOrDefaultAsync();

        if (reqModel.ExtraList.Count > 0)
        {
            decimal extraTotal = await _db.PizzaExtras.AsNoTracking()
                .Where(x => reqModel.ExtraList.Contains(x.PizzaExtraId))
                .SumAsync(x => x.Price);

            totalAmount += extraTotal;
        }

        string invoiceNo = DateTime.Now.ToString("yyyyMMddHHmmss");
        PizzaOrderModel order = new PizzaOrderModel()
        {
            PizzaId = reqModel.PizzaId,
            PizzaOrderInvoiceNo = invoiceNo,
            TotalAmount = totalAmount
        };

        List<PizzaOrderDetailModel> lstOrderDetail = reqModel.ExtraList
            .Select(extraId => new PizzaOrderDetailModel()
            {
                PizzaExtraId = extraId,
                PizzaOrderInvoiceNo = invoiceNo
            }).ToList();

        await _db.PizzaOrders.AddAsync(order);
        await _db.PizzaOrderDetails.AddRangeAsync(lstOrderDetail);
        await _db.SaveChangesAsync();

        OrderResponseModel model = new OrderResponseModel()
        {
            InvoiceNo = invoiceNo,
            Message = "Thanks for your order. Enjoy your Pizza!",
            TotalAmount = totalAmount
        };

        return Ok(model);
    }
}