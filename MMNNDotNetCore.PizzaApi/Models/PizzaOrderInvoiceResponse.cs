namespace MMNNDotNetCore.PizzaApi.Models;

public class PizzaOrderInvoiceResponse
{
    public PizzaOrderInvoiceHeadModel Order { get; set; }
    public List<PizzaOrderInvoiceDetailModel> OrderDetail { get; set; }
}