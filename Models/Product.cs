using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Identity.Client;

namespace APBD10.Models;

[Table("Products")]
public class Product
{
    [Key] [Column("PK_product")] public int Id { get; set; }

    [Column("name")] [MaxLength(100)] public string Name { get; set; }

    [Column("weight", TypeName = "decimal(5,2)")]
    public decimal Weight { get; set; }

    [Column("width", TypeName = "decimal(5,2)")]
    public decimal Width { get; set; }

    [Column("height", TypeName = "decimal(5,2)")]
    public decimal Height { get; set; }

    [Column("depth", TypeName = "decimal(5,2)")]
    public decimal Depth { get; set; }

    public IEnumerable<Category> Categories { get; set; }
    public IEnumerable<Account> Accounts { get; set; }
    public IEnumerable<ShoppingCart> ShoppingCarts { get; set; }
}