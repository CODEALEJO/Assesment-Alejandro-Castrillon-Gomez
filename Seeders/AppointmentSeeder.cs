using System;
using System.Collections.Generic;
using System.Linq;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Models;
using Microsoft.EntityFrameworkCore;

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.Seeders
{
    public class AppointmentSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 1,
                    Date = DateTime.Now.AddDays(1),
                    Motive = "Consulta General",
                    State = "Pendiente",
                    Note = "Revisión anual",
                    PatientId = 1,
                    DoctorId = 1
                },
                new Appointment
                {
                    Id = 2,
                    Date = DateTime.Now.AddDays(2),
                    Motive = "Chequeo de salud",
                    State = "Confirmada",
                    Note = "Chequeo regular",
                    PatientId = 2,
                    DoctorId = 2
                },
                new Appointment
                {
                    Id = 3,
                    Date = DateTime.Now.AddDays(3),
                    Motive = "Revisión de resultados",
                    State = "Completada",
                    Note = "Resultados de análisis",
                    PatientId = 3,
                    DoctorId = 3
                },
                new Appointment
                {
                    Id = 4,
                    Date = DateTime.Now.AddDays(4),
                    Motive = "Urgencia médica",
                    State = "Pendiente",
                    Note = "Accidente en el trabajo",
                    PatientId = 4,
                    DoctorId = 4
                },
                new Appointment
                {
                    Id = 5,
                    Date = DateTime.Now.AddDays(5),
                    Motive = "Control post operatorio",
                    State = "Confirmada",
                    Note = "Revisión después de la cirugía",
                    PatientId = 5,
                    DoctorId = 1
                }
            );
        }
    }
}
