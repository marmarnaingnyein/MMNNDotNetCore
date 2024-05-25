using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMNNDotNetCore.Models;

[Table("Tbl_PizzaExtra")]
public class PizzaExtraModel
{
    [Key]
    [Column("PizzaExtraId")]
    public int PizzaExtraId { get; set; }
    [Column("PizzaExtraName")]
    public string ExtraName { get; set; }
    [Column("Price")]
    public decimal Price { get; set; }
}