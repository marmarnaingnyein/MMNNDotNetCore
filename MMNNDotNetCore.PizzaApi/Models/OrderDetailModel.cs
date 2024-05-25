namespace MMNNDotNetCore.PizzaApi.Models;

public class OrderDetailModel
{
    public string InvoiceNo { get; set; }
    public string PizzaName { get; set; }
    public decimal TotalAmount { get; set; }
    public List<string> ExtraNameList { get; set; }
}
