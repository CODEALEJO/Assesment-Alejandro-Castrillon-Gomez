using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.Models;

public class Doctor
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
    [Column("specialty")]
    public string Specialty { get; set; }
    [Column("email")]
    public string Email { get; set; }
    [Column("availability")]
    public string Availability { get; set; }
    [Column("appointments")]
    public List<Appointment> Appointments { get; set; }
}