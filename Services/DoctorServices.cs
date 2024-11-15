using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Data;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Interface;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Models;

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.Services
{
    public class DoctorServices : IDoctorInterface
    {
        private readonly ApplicationDbContext _context;

        public DoctorServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Doctor> Add(Doctor doctor)
        {
            if (doctor == null)
                throw new ArgumentNullException(nameof(doctor));

            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }

        public async Task Delete(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
                throw new KeyNotFoundException($"Doctor with ID {id} not found.");

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Doctor>> GetAll()
        {
            return await Task.FromResult(_context.Doctors.ToList());
        }

        public async Task<Doctor> GetById(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
                throw new KeyNotFoundException($"Doctor with ID {id} not found.");

            return doctor;
        }

        public async Task<Doctor> Update(Doctor doctor)
        {
            if (doctor == null)
                throw new ArgumentNullException(nameof(doctor));

            var existingDoctor = await _context.Doctors.FindAsync(doctor.Id);
            if (existingDoctor == null)
                throw new KeyNotFoundException($"Doctor with ID {doctor.Id} not found.");

            // Actualizar los valores del doctor
            existingDoctor.Name = doctor.Name;
            existingDoctor.Specialty = doctor.Specialty;
            existingDoctor.Email = doctor.Email;

            _context.Doctors.Update(existingDoctor);
            await _context.SaveChangesAsync();

            // Retornar el doctor actualizado
            return existingDoctor;
        }

    }
}
