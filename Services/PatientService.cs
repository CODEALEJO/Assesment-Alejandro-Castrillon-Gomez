using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Data;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Interface;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Models;

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.Services
{
    public class PatientService : IPatientInterface
    {
        private readonly ApplicationDbContext _context;

        public PatientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Patient> Add(Patient patient)
        {
            if (patient == null)
                throw new ArgumentNullException(nameof(patient));

            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task Delete(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
                throw new KeyNotFoundException($"Patient with ID {id} not found.");

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Patient>> GetAll()
        {
            return await Task.FromResult(_context.Patients.ToList());
        }

        public async Task<Patient> GetById(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
                throw new KeyNotFoundException($"Patient with ID {id} not found.");

            return patient;
        }

        public async Task Update(Patient patient)
        {
            if (patient == null)
                throw new ArgumentNullException(nameof(patient));

            var existingPatient = await _context.Patients.FindAsync(patient.Id);
            if (existingPatient == null)
                throw new KeyNotFoundException($"Patient with ID {patient.Id} not found.");

            existingPatient.Name = patient.Name;
            existingPatient.Email = patient.Email;
            existingPatient.Phone = patient.Phone;

            _context.Patients.Update(existingPatient);
            await _context.SaveChangesAsync();
        }
    }
}
