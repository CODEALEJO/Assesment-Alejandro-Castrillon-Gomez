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
    public class AppointmentServices : IAppointmentInterface
    {
        private readonly ApplicationDbContext _context;

        public AppointmentServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Appointment> Add(Appointment appointment)
        {
            if (appointment == null)
                throw new ArgumentNullException(nameof(appointment));


            var doctorAppointments = await _context.Appointments
                .Where(a => a.DoctorId == appointment.DoctorId && a.Date == appointment.Date)
                .ToListAsync();

            if (doctorAppointments.Any())
                throw new InvalidOperationException($"The doctor is already booked for the selected time.");


            var patientAppointments = await _context.Appointments
                .Where(a => a.PatientId == appointment.PatientId && a.Date == appointment.Date)
                .ToListAsync();

            if (patientAppointments.Any())
                throw new InvalidOperationException($"The patient already has an appointment at the selected time.");


            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }
        public async Task Delete(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
                throw new KeyNotFoundException($"Appointment with ID {id} not found.");

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAll()
        {
            return await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .ToListAsync();
        }


        public async Task<Appointment> GetByDoctorAndDate(int doctorId, DateTime date)
        {
            return await _context.Appointments
                .FirstOrDefaultAsync(a => a.DoctorId == doctorId && a.Date == date);
        }
        public async Task<Appointment> GetById(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
                throw new KeyNotFoundException($"Appointment with ID {id} not found.");

            return appointment;
        }

        public async Task<Appointment> Update(Appointment appointment)
        {
            if (appointment == null)
                throw new ArgumentNullException(nameof(appointment));

            var existingAppointment = await _context.Appointments.FindAsync(appointment.Id);
            if (existingAppointment == null)
                throw new KeyNotFoundException($"Appointment with ID {appointment.Id} not found.");


            existingAppointment.Date = appointment.Date;
            existingAppointment.DoctorId = appointment.DoctorId;
            existingAppointment.PatientId = appointment.PatientId;
            existingAppointment.Note = appointment.Note;

            _context.Appointments.Update(existingAppointment);
            await _context.SaveChangesAsync();

            return existingAppointment;
        }


  public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int patientId)
    {
        var appointments = await _context.Appointments
            .Where(a => a.PatientId == patientId)
            .Include(a => a.Doctor)  // Incluir información del doctor si es necesario
            .ToListAsync();

        return appointments;
    }

    public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int doctorId)
    {
        var appointments = await _context.Appointments
            .Where(a => a.DoctorId == doctorId)
            .Include(a => a.Patient)  // Incluir información del paciente si es necesario
            .ToListAsync();

        return appointments;
    }
    }
}
