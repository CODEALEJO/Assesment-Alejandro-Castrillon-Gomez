using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.DTO;
public class UserDto
{
    [Required]
    [StringLength(255)]
    public string FullName { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    [EmailAddress]
    [StringLength(255)]
    public string Email { get; set; }

    [Required]
    [StringLength(20)]
    public string PasswordHash { get; set; }

    [Required]
    public string Role { get; set; }
}