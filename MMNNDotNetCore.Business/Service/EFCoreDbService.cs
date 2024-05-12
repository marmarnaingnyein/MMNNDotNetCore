using Microsoft.EntityFrameworkCore;
using MMNNDotNetCore.EFCore.EfAppDbContext;
using MMNNDotNetCore.Models;

namespace MMNNDotNetCore.Business.Service;

public class EFCoreDbService
{
    private readonly EfAppDbContext _db = new EfAppDbContext();

    public List<BlogModel> GetList(BlogModel filter)
    {
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

        return lst;
    }

    public BlogModel? GetById(int id)
    {
        BlogModel? item = _db.Blogs.AsNoTracking()
            .FirstOrDefault(w => w.BlogId == id);

        return item;
    }

    public int Create(BlogModel model)
    {
        _db.Add(model);
        return _db.SaveChanges();
    }

    public int Update(int id, BlogModel newBlog)
    {
        BlogModel? item = GetById(id);
        item!.BlogTitle = newBlog.BlogTitle;
        item.BlogAuthor = newBlog.BlogAuthor;
        item.BlogContent = newBlog.BlogContent;

        return _db.SaveChanges();
    }

    public int Delete(int id, BlogModel item)
    {
        _db.Remove(item);
        return _db.SaveChanges();
    }
}