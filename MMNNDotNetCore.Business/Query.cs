namespace MMNNDotNetCore.Business;

public class Query
{
    public const string Select = "select * from Tbl_Blog";
    public const string Create = @"Insert Into Tbl_Blog (BlogTitle, BlogAuthor, BlogContent) Values(@BlogTitle, @BlogAuthor, @BlogContent)";
    public const string SelectById = @"Select * from Tbl_Blog Where BlogId = @BlogId";
    public static string Update = @"Update Tbl_Blog SET BlogTitle = @BlogTitle,BlogAuthor = @BlogAuthor,BlogContent = @BlogContent Where BlogId = @BlogId";
    public static string Delete = @"Delete From Tbl_Blog Where BlogId = @BlogId";
}