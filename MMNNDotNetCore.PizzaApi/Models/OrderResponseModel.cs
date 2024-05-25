namespace MMNNDotNetCore.PizzaApi.Models;

public class OrderResponseModel
{
    public string Message { get; set; }
    public string InvoiceNo { get; set; }
    public decimal TotalAmount { get; set; }
}