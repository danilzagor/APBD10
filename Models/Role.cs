using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD10.Models;
[Table("Roles")]
public class Role
{
    [Key] [Column("PK_role")] public int Id { get; set; }

    [Column("name")] [MaxLength(100)] public string Name { get; set; }
    public IEnumerable<Account> Accounts { get; set; }
}