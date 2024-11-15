using System;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Models;
using Microsoft.EntityFrameworkCore;

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.Seeders
{
    public class HistoryDatingSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HistoryDating>().HasData(
                new HistoryDating
                {
                    Id = 1,
                    Description = "Paciente con hipertensión diagnosticada.",
                    LastUpdate = DateTime.Now.AddMonths(-1),
                    PatientId = 1
                },
                new HistoryDating
                {
                    Id = 2,
                    Description = "Paciente con antecedentes familiares de diabetes.",
                    LastUpdate = DateTime.Now.AddMonths(-2),
                    PatientId = 2
                },
                new HistoryDating
                {
                    Id = 3,
                    Description = "Paciente con diagnóstico reciente de asma.",
                    LastUpdate = DateTime.Now.AddMonths(-3),
                    PatientId = 3
                },
                new HistoryDating
                {
                    Id = 4,
                    Description = "Paciente con cirugía reciente de rodilla.",
                    LastUpdate = DateTime.Now.AddMonths(-4),
                    PatientId = 4
                },
                new HistoryDating
                {
                    Id = 5,
                    Description = "Paciente con alergias estacionales.",
                    LastUpdate = DateTime.Now.AddMonths(-5),
                    PatientId = 5
                }
            );
        }
    }
}
