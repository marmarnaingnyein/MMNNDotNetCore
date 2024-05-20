namespace MMNNDotNetCore.NLayerRestApi.Features.Blog;

public class DA_Blog
{
    private readonly EfAppDbContext _db;

    public DA_Blog()
    {
        _db = new EfAppDbContext();
    }

    public List<BlogModel> GetList()
    {
        List<BlogModel> lst = _db.Blogs.ToList();
        
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

    public int Update(BlogModel model)
    {
        _db.Update(model);
        return _db.SaveChanges();
    }

    public int Delete(BlogModel item)
    {
        _db.Remove(item);
        return _db.SaveChanges();
    }
}