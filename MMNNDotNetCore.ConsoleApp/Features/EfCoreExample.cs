using MMNNDotNetCore.ConsoleApp.DbService;
using MMNNDotNetCore.ConsoleApp.Service;

namespace MMNNDotNetCore.ConsoleApp.Features;

public class EfCoreExample
{
    private DataGenerateService _dataGenerateService = new DataGenerateService();
    private readonly AppDbContext _db = new AppDbContext();
    public void SelectAll()
    {
        List<BlogModel> lstBlog = _db.Blogs.ToList();
        foreach (var item in lstBlog)
        {
            _dataGenerateService.WriteDataList(item);
        }
    }
    
    public void SelectBy()
    {
        BlogModel filter = _dataGenerateService.GetFiltersBlog();

        List<BlogModel> lst = _db.Blogs.ToList();

        if (filter.BlogId > 0)
        {
            lst = lst.Where(w => w.BlogId == filter.BlogId).ToList();
        }
        else if (!string.IsNullOrEmpty(filter.BlogTitle))
        {
            lst = lst.Where(w => w.BlogTitle == filter.BlogTitle).ToList();
        }
        else if (!string.IsNullOrEmpty(filter.BlogAuthor))
        {
            lst = lst.Where(w => w.BlogAuthor == filter.BlogAuthor).ToList();
        }
        
        foreach (var item in lst)
        {
            _dataGenerateService.WriteDataList(item);
        }
    }
}