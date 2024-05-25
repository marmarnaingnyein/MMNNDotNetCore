using MMNNDotNetCore.Models;
using Refit;

namespace MMNNDotNetCore.ConsoleAppRefitExamples;

public interface IBlogApi
{
    [Get("/api/blog")]
    Task<List<BlogModel>> GetBlogs();

    [Post("/api/blog/selectby")]
    Task<BlogModel> SelectBy(BlogModel filter);

    [Post("/api/blog")]
    Task<string> Create(BlogModel reqModel);

    [Put("/api/blog")]
    Task<string> Update(BlogModel reqModel);
    
    [Delete("/api/blog/{id}")]
    Task<string> Delete(int id);
}