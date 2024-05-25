using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMNNDotNetCore.Models;

[Table("Tbl_Pizza")]
public class PizzaModel
{
    [Key]
    [Column("PizzaId")]
    public int PizzaId { get; set; }
    [Column("Pizza")]
    public string Name { get; set; }
    [Column("Price")]
    public decimal Price { get; set; }
}