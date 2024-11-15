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
    public class HistoryDatingService : IHistoryDatingInterface
    {
        private readonly ApplicationDbContext _context;

        public HistoryDatingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<HistoryDating> Add(HistoryDating historyDating)
        {
            if (historyDating == null)
                throw new ArgumentNullException(nameof(historyDating));

            await _context.HistoryDatings.AddAsync(historyDating);
            await _context.SaveChangesAsync();
            return historyDating;
        }

        public async Task Delete(int id)
        {
            var historyDating = await _context.HistoryDatings.FindAsync(id);
            if (historyDating == null)
                throw new KeyNotFoundException($"HistoryDating with ID {id} not found.");

            _context.HistoryDatings.Remove(historyDating);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<HistoryDating>> GetAll()
        {
            return await Task.FromResult(_context.HistoryDatings.ToList());
        }

        public async Task<HistoryDating> GetById(int id)
        {
            var historyDating = await _context.HistoryDatings.FindAsync(id);
            if (historyDating == null)
                throw new KeyNotFoundException($"HistoryDating with ID {id} not found.");

            return historyDating;
        }

        public async Task Update(HistoryDating historyDating)
        {
            if (historyDating == null)
                throw new ArgumentNullException(nameof(historyDating));

            var existingHistoryDating = await _context.HistoryDatings.FindAsync(historyDating.Id);
            if (existingHistoryDating == null)
                throw new KeyNotFoundException($"HistoryDating with ID {historyDating.Id} not found.");

            // Actualizar las propiedades existentes
            existingHistoryDating.Description = historyDating.Description;
            existingHistoryDating.LastUpdate = historyDating.LastUpdate;
            existingHistoryDating.PatientId = historyDating.PatientId;

            _context.HistoryDatings.Update(existingHistoryDating);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<HistoryDating>> GetFiltered(int? patientId, DateTime? date, string reason)
        {
            var query = _context.HistoryDatings.AsQueryable();

            if (patientId.HasValue)
            {
                query = query.Where(h => h.PatientId == patientId);
            }

            if (date.HasValue)
            {
                query = query.Where(h => h.LastUpdate.Date == date.Value.Date);
            }

            if (!string.IsNullOrEmpty(reason))
            {
                query = query.Where(h => h.Description.Contains(reason));
            }

            return await query.ToListAsync();
        }

    }
}
