using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Models;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Seeders;
using Microsoft.EntityFrameworkCore;

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.Data;
public class ApplicationDbContext : DbContext
{
    //tables
    public DbSet<HistoryDating> HistoryDatings { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<User> Users { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //Seeders
        UserSeeder.Seed(modelBuilder);
        AppointmentSeeder.Seed(modelBuilder);
        DoctorSeeder.Seed(modelBuilder);
        HistoryDatingSeeder.Seed(modelBuilder);
        PatientSeeder.Seed(modelBuilder);

    }

}
