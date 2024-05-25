namespace MMNNDotNetCore.Business;

public class Query
{
    public const string Select = "select * from Tbl_Blog";
    public const string Create = @"Insert Into Tbl_Blog (BlogTitle, BlogAuthor, BlogContent) Values(@BlogTitle, @BlogAuthor, @BlogContent)";
    public const string SelectById = @"Select * from Tbl_Blog Where BlogId = @BlogId";
    public static string Update = @"Update Tbl_Blog SET BlogTitle = @BlogTitle,BlogAuthor = @BlogAuthor,BlogContent = @BlogContent Where BlogId = @BlogId";
    public static string Delete = @"Delete From Tbl_Blog Where BlogId = @BlogId";
    
    public static string PizzaOrderQuery { get; } = 
        @"select po.*, p.Pizza, p.Price from [dbo].[Tbl_PizzaOrder] po
            inner join Tbl_Pizza p on p.PizzaId = po.PizzaId
            where PizzaOrderInvoiceNo = @PizzaOrderInvoiceNo;
            ";

    public static string PizzaOrderDetailQuery { get; } =
        @"select pod.*, pe.PizzaExtraName, pe.Price from [dbo].[Tbl_PizzaOrderDetail] pod
            inner join Tbl_PizzaExtra pe on pod.PizzaExtraId = pe.PizzaExtraId
            where PizzaOrderInvoiceNo = @PizzaOrderInvoiceNo;";
}