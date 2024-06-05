using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APBD10.Models;
[Table("Shopping_Carts")]
public class ShoppingCart
{
    [Column("FK_account")] public int AccountId { get; set; }
    [Column("FK_product")] public int ProductId { get; set; }
    [Column("amount")]
    public int Amount { get; set; }
}