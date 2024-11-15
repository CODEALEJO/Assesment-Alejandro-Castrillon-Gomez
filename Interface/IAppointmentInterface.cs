using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Models;

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.Interface;
public interface IAppointmentInterface
{
    Task<Appointment> Add(Appointment appointment);
    Task<IEnumerable<Appointment>> GetAll();
    Task<Appointment> GetById(int id);
    Task<Appointment> Update(Appointment appointment);
    Task Delete(int id);
    Task<Appointment> GetByDoctorAndDate(int doctorId, DateTime date);
    Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int patientId);  
    Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int doctorId);
}
