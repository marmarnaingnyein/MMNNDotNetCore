using MMNNDotNetCore.Models;

namespace MMNNDotNetCore.RestApi.Service;

public class ValidationService
{
    public string CheckRequiredField(BlogModel model)
    {
        string response = string.Empty;
        if (string.IsNullOrEmpty(model.BlogTitle))
        {
            response = "Blog Title is required.";
        }
        if (string.IsNullOrEmpty(model.BlogAuthor))
        {
            response = "Blog Author is required.";
        }
        if (string.IsNullOrEmpty(model.BlogContent))
        {
            response = "Blog Content is required.";
        }
        
        Result:
        return response;
    }
}