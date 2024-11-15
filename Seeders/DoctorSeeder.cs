using System;
using System.Collections.Generic;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Models;
using Microsoft.EntityFrameworkCore;

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.Seeders
{
    public class DoctorSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = 1,
                    Name = "Dr. Carlos Gómez",
                    Specialty = "Cardiología",
                    Email = "carlos.gomez@hospital.com",
                    Availability = "Lunes a Viernes: 9:00 - 17:00" 
                },
                new Doctor
                {
                    Id = 2,
                    Name = "Dra. María López",
                    Specialty = "Neurología",
                    Email = "maria.lopez@hospital.com",
                    Availability = "Lunes a Viernes: 8:00 - 15:00" 
                },
                new Doctor
                {
                    Id = 3,
                    Name = "Dr. Juan Pérez",
                    Specialty = "Pediatría",
                    Email = "juan.perez@hospital.com",
                    Availability = "Lunes, Miércoles y Viernes: 10:00 - 14:00" 
                },
                new Doctor
                {
                    Id = 4,
                    Name = "Dra. Laura Martínez",
                    Specialty = "Ortopedia",
                    Email = "laura.martinez@hospital.com",
                    Availability = "Martes y Jueves: 8:00 - 12:00" 
                },
                new Doctor
                {
                    Id = 5,
                    Name = "Dr. Alberto Sánchez",
                    Specialty = "Ginecología",
                    Email = "alberto.sanchez@hospital.com",
                    Availability = "Lunes a Viernes: 9:00 - 16:00" 
                }
            );
        }
    }
}
