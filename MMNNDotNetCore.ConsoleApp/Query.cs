namespace MMNNDotNetCore.ConsoleApp;

public class Query
{
    public const string Select = "select * from Tbl_Blog";
    public const string Create = @"Insert Into Tbl_Blog (BlogTitle, BlogAuthor, BlogContent) Values(@BlogTitle, @BlogAuthor, @BlogContent)";
}