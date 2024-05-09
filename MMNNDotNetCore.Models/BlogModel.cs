using System.ComponentModel.DataAnnotations.Schema;

namespace MMNNDotNetCore.Models;

[Table("Tbl_Blog")]
public class BlogModel
{
    public int BlogId { get; set; }
    public string BlogTitle { get; set; }
    public string BlogAuthor { get; set; }
    public string BlogContent { get; set; }
}