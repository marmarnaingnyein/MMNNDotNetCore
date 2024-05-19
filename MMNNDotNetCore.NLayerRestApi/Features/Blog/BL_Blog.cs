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
            model.Response = new ResponseModel()
            {
                ResType = EnumResType.Fail,
                ResMessage = "Id is required."
            };
            return model;
        }

        BlogModel? item = _daBlog.GetById(id);
        if (item == null)
        {
            model.Response = new ResponseModel()
            {
                ResType = EnumResType.Fail,
                ResMessage = "Data not Found."
            };
            return model;
        }

        model.ResData = item;
        model.Response = new ResponseModel()
        {
            ResType = EnumResType.Success,
            ResMessage = "Success."
        };
        return model;
    }
}