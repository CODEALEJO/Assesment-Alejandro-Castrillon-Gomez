using System;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Models;
using Microsoft.EntityFrameworkCore;

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.Seeders
{
    public class PatientSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasData(
                new Patient
                {
                    Id = 1,
                    Name = "Carlos González",
                    Email = "carlos.gonzalez@example.com",
                    Phone = "3012345678"
                },
                new Patient
                {
                    Id = 2,
                    Name = "Ana Pérez",
                    Email = "ana.perez@example.com",
                    Phone = "3023456789"
                },
                new Patient
                {
                    Id = 3,
                    Name = "Luis Martínez",
                    Email = "luis.martinez@example.com",
                    Phone = "3034567890"
                },
                new Patient
                {
                    Id = 4,
                    Name = "Sofía Rodríguez",
                    Email = "sofia.rodriguez@example.com",
                    Phone = "3045678901"
                },
                new Patient
                {
                    Id = 5,
                    Name = "Juan Pérez",
                    Email = "juan.perez@example.com",
                    Phone = "3056789012"
                }
            );
        }
    }
}
