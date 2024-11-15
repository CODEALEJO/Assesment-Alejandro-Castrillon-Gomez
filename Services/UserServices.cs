using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Data;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Interface;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Models;
using Microsoft.EntityFrameworkCore;

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.Services
{
    public class UserServices : IUserInterface
    {
        private readonly ApplicationDbContext _context;

        public UserServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> Add(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users
                .Select(user => new User
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Email = user.Email,
                })
                .ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users
                .Where(u => u.Id == id)
                .Select(user => new User
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Email = user.Email,
                })
                .FirstOrDefaultAsync();
        }

        public async Task Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Register(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "The guest cannot be null."); 
            }

            try
            {
                await _context.Users.AddAsync(user); 
                await _context.SaveChangesAsync(); 
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception("Error while adding the guest to the database.", dbEx); 
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while adding the guest.", ex); 
            }
        }

    }
}