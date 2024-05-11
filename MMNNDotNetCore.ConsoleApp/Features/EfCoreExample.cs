using Microsoft.EntityFrameworkCore;
using MMNNDotNetCore.Business.Service;

namespace MMNNDotNetCore.ConsoleApp.Features;

public class EfCoreExample
{
    private DataGenerateService _dataGenerateService = new DataGenerateService();
    private readonly EFCoreDbService _efCoreDbService = new EFCoreDbService();
    public void SelectAll()
    {
        List<BlogModel> lstBlog = _efCoreDbService.GetList(new BlogModel());
        foreach (var item in lstBlog)
        {
            _dataGenerateService.WriteDataList(item);
        }
    }
    
    public void SelectBy()
    {
        BlogModel filter = _dataGenerateService.GetFiltersBlog();

        List<BlogModel> lst = _efCoreDbService.GetList(filter);
        foreach (var item in lst)
        {
            _dataGenerateService.WriteDataList(item);
        }
    }
    
    public void Create()
    {
        Console.WriteLine("----- Create Blog -----");
        BlogModel newBlog = _dataGenerateService.GetUserInputBlog();

        int result = _efCoreDbService.Create(newBlog);
        
        string message = result > 0 ? "---- Saving Successful. ----" : "---- Saving Fail! ----";
        Console.WriteLine(message);
    }

    public void Update()
    {
        Console.WriteLine("----- Update Blog -----");
        int id = _dataGenerateService.GetEditBlogId();

        BlogModel? item = _efCoreDbService.GetById(id);

        if (item is null)
        {
            Console.WriteLine("No Data Fount!");
            return;
        }
        
        _dataGenerateService.WriteDataList(item);
        
        BlogModel newBlog = _dataGenerateService.GetUserInputBlog();
        int result = _efCoreDbService.Update(id, newBlog);        
        
        string message = result > 0 ? "---- Updating Successful. ----" : "---- Updating Fail! ----";
        Console.WriteLine(message);
    }

    public void Delete()
    {
        Console.WriteLine("----- Delete Blog -----");
        int id = _dataGenerateService.GetEditBlogId();

        BlogModel? item = _efCoreDbService.GetById(id);

        if (item is null)
        {
            Console.WriteLine("No Data Fount!");
            return;
        }

        Console.WriteLine("----- Blog Info -----");
        _dataGenerateService.WriteDataList(item);
            
        if (!_dataGenerateService.ConfirmToDelete())
        {
            return;
        }

        int result = _efCoreDbService.Delete(id, item);
        
        string message = result > 0 ? "---- Delete Successful. ----" : "---- Delete Fail! ----";
        Console.WriteLine(message);
    }
}