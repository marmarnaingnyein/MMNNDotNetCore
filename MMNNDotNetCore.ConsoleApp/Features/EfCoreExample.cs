using MMNNDotNetCore.ConsoleApp.DbService;
using MMNNDotNetCore.ConsoleApp.Service;

namespace MMNNDotNetCore.ConsoleApp.Features;

public class EfCoreExample
{
    private DataGenerateService _dataGenerateService = new DataGenerateService();

    public void SelectAll()
    {
        AppDbContext db = new AppDbContext();
        List<BlogModel> lstBlog = db.Blogs.ToList();
        foreach (var item in lstBlog)
        {
            _dataGenerateService.WriteDataList(item);
        }
    }
}