using System;
using System.ComponentModel.DataAnnotations;

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.DTO
{
    public class AppointmentDto
    {
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(255)]
        public string Motive { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [StringLength(255)]
        public string Note { get; set; }
        [Required]
        public int PatientId { get; set; }

        [Required]
        public int DoctorId { get; set; }
    }
}
