using MMNNDotNetCore.NLayerRestApi.Model;

namespace MMNNDotNetCore.NLayerRestApi.Features.Blog;

public class BL_Blog
{
    private DA_Blog _daBlog;

    public BL_Blog()
    {
        _daBlog = new DA_Blog();
    }

    public List<BlogModel> GetList(BlogModel filter)
    {
        List<BlogModel> lst = _daBlog.GetList();
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

    public BlogResponseModel GetById(int id)
    {
        BlogResponseModel model = new BlogResponseModel();
        if (id <= 0)
        {
            model.Response = new ResponseModel(EnumResType.Fail, "Id is required.");
            return model;
        }

        BlogModel? item = _daBlog.GetById(id);
        if (item == null)
        {
            model.Response = new ResponseModel(EnumResType.Fail,"Data not Found.");
            return model;
        }

        model.ResData = item;
        model.Response = new ResponseModel(EnumResType.Success, "Success.");
        return model;
    }

    public BlogResponseModel Create(BlogModel reqModel)
    {
        BlogResponseModel model = new BlogResponseModel();
        if (string.IsNullOrEmpty(reqModel.BlogTitle))
        {
            model.Response = new ResponseModel(EnumResType.Fail, "Blog Title is required.");
            return model;
        }

        if (string.IsNullOrEmpty(reqModel.BlogAuthor))
        {
            model.Response = new ResponseModel(EnumResType.Fail, "Blog Author is required.");
            return model;
        }
        if (string.IsNullOrEmpty(reqModel.BlogContent))
        {
            model.Response = new ResponseModel(EnumResType.Fail, "Blog Author is required.");
            return model;
        }
        
        if (string.IsNullOrEmpty(reqModel.BlogContent))
        {
            model.Response = new ResponseModel(EnumResType.Fail, "Blog Content is required.");
            return model;
        }
        
        int result = _daBlog.Create(reqModel);
        
        model.Response = result > 0 ? new ResponseModel(EnumResType.Success, "Create Success.") :
            new ResponseModel(EnumResType.Fail, "Create Fail.");
        
        return model;
    }
    
    public BlogResponseModel Update(BlogModel reqModel)
    {
        BlogResponseModel model = new BlogResponseModel();
        if (reqModel.BlogId <= 0)
        {
            model.Response = new ResponseModel(EnumResType.Fail, "Blog Id is required.");
            return model;
        }

        BlogModel? item = _daBlog.GetById(reqModel.BlogId);
        if (item == null)
        {
            model.Response = new ResponseModel(EnumResType.Fail,"Data not Found.");
            return model;
        }
        
        if (string.IsNullOrEmpty(reqModel.BlogTitle))
        {
            model.Response = new ResponseModel(EnumResType.Fail, "Blog Title is required.");
            return model;
        }

        if (string.IsNullOrEmpty(reqModel.BlogAuthor))
        {
            model.Response = new ResponseModel(EnumResType.Fail, "Blog Author is required.");
            return model;
        }
        if (string.IsNullOrEmpty(reqModel.BlogContent))
        {
            model.Response = new ResponseModel(EnumResType.Fail, "Blog Author is required.");
            return model;
        }
        
        if (string.IsNullOrEmpty(reqModel.BlogContent))
        {
            model.Response = new ResponseModel(EnumResType.Fail, "Blog Content is required.");
            return model;
        }
        
        int result = _daBlog.Update(reqModel);
        
        model.Response = result > 0 ? new ResponseModel(EnumResType.Success, "Delete Success.") :
            new ResponseModel(EnumResType.Fail, "Delete Fail.");
        
        return model;
    }
    
}