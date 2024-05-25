namespace MMNNDotNetCore.PizzaApi.Models;

public class OrderRequestModel
{
    public int PizzaId { get; set; }
    public List<int> ExtraList { get; set; }
}