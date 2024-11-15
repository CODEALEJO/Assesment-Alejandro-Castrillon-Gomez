using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.Models;
[Table("history_datings")]
public class HistoryDating
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Column("description")]
    public string Description { get; set; }
    [Column("last_update")]
    public DateTime LastUpdate { get; set; }

    [Column("patient_id")]
    public int PatientId { get; set; }
    [ForeignKey("PatientId")]
    public Patient Patient { get; set; }
}