using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.Models;
[Table("users")]
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string FullName { get; set; }
    [Column("email")]
    [EmailAddress]
    public string Email { get; set; }
    [Column("password_hash")]
    public string PasswordHash { get; set; }
    [Column("role")]
    public string Role { get; set; } 

}