using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMNNDotNetCore.Models;

[Table("Tbl_PizzaExtra")]
public class PizzaExtraModel
{
    [Key]
    [Column("PizzaExtraId")]
    public int PizzaId { get; set; }
    [Column("PizzaExtraName")]
    public string Name { get; set; }
    [Column("Price")]
    public decimal Price { get; set; }
}