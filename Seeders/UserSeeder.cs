using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Models;
using Microsoft.EntityFrameworkCore;

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.Seeders
{
    public class UserSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FullName = "John",
                    Email = "john.doe@example.com",
                    PasswordHash = "hashedpassword1",
                    Role = "Admin"
                },
                new User
                {
                    Id = 2,
                    FullName = "Jane",
                    Email = "jane.smith@example.com",
                    PasswordHash = "hashedpassword2",
                    Role = "Doctor"  
                },
                new User
                {
                    Id = 3,
                    FullName = "Jim",
                    Email = "jim.brown@example.com",
                    PasswordHash = "hashedpassword3",
                    Role = "Patient"  
                }
            );
        }
    }

}