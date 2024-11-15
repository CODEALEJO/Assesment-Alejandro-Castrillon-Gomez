using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Interface;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.Controllers.V1.AppointmentControllers
{
    [ApiController]
    [Route("api/v1/appointments")]
    [Tags("Appointment")]

    public class AppointmentControllerRead : AppointmentController
    {
        public AppointmentControllerRead(IAppointmentInterface appointmentInterface) : base(appointmentInterface) { }

        /// <summary>
        /// Get all appointments.
        /// </summary>
        /// <returns>A list of all appointments in the system.</returns>
        /// <response code="200">Returns the list of appointments.</response>
        /// <response code="500">If an internal server error occurs.</response>
        [Authorize(Roles = "Admin, Doctor")]
        [HttpGet]
        [SwaggerOperation(
         Summary = "Get all appointments",
         Description = "Retrieves all appointments from the system."
     )]
        [ProducesResponseType(typeof(IEnumerable<Appointment>), 200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAllAppointments()
        {
            try
            {
                var appointments = await _appointmentInterface.GetAll();

                // Mapeo de citas para devolver solo los datos necesarios
                var appointmentsWithDetails = appointments.Select(a => new
                {
                    a.Id,
                    a.Date,
                    a.Motive,
                    a.State,
                    a.Note,
                    PatientName = a.Patient != null ? $"{a.Patient.Name}" : "No Patient",
                    DoctorName = a.Doctor != null ? $"{a.Doctor.Name} " : "No Doctor"
                });

                return Ok(appointmentsWithDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get a specific appointment by ID.
        /// </summary>
        /// <param name="id">The ID of the appointment to retrieve.</param>
        /// <returns>The requested appointment.</returns>
        /// <response code="200">Returns the requested appointment.</response>
        /// <response code="404">If the appointment is not found.</response>
        /// <response code="500">If an internal server error occurs.</response>
        [Authorize(Roles = "Admin, Doctor")]
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get an appointment by ID",
            Description = "Retrieves a specific appointment from the system based on its ID."
        )]
        [ProducesResponseType(typeof(Appointment), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Appointment>> GetAppointmentById(int id)
        {
            try
            {
                var appointment = await _appointmentInterface.GetById(id);
                if (appointment == null)
                    return NotFound($"Appointment with ID {id} not found.");

                return Ok(appointment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get appointments by patient ID.
        /// </summary>
        /// <param name="patientId">The ID of the patient to retrieve appointments for.</param>
        /// <returns>A list of appointments associated with the specified patient.</returns>
        /// <response code="200">Returns the list of appointments for the patient.</response>
        /// <response code="404">If the patient has no appointments.</response>
        /// <response code="500">If an internal server error occurs.</response>
        [HttpGet("patient/{patientId}")]
        [SwaggerOperation(
      Summary = "Get appointments by patient ID",
      Description = "Retrieves all appointments for the specified patient based on their ID."
  )]
        [ProducesResponseType(typeof(IEnumerable<Appointment>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointmentsByPatient(int patientId)
        {
            try
            {
            
                var appointments = await _appointmentInterface.GetAppointmentsByPatient(patientId);

                if (!appointments.Any())
                    return NotFound($"No appointments found for patient with ID {patientId}.");

           
                var appointmentsWithDetails = appointments.Select(a => new
                {
                    a.Id,
                    a.Date,
                    a.Motive,
                    a.State,
                    a.Note,
                    DoctorName = a.Doctor != null ? $"{a.Doctor.Name}" : "No Doctor"
                });

                return Ok(appointmentsWithDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize(Roles = "Admin, Doctor")]
        [HttpGet("doctor/{doctorId}")]
        [SwaggerOperation(
            Summary = "Get appointments by doctor ID",
            Description = "Retrieves all appointments for the specified doctor based on their ID."
        )]
        [ProducesResponseType(typeof(IEnumerable<Appointment>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointmentsByDoctor(int doctorId)
        {
            try
            {
           
                var appointments = await _appointmentInterface.GetAppointmentsByDoctor(doctorId);

                if (!appointments.Any())
                    return NotFound($"No appointments found for doctor with ID {doctorId}.");

                var appointmentsWithDetails = appointments.Select(a => new
                {
                    a.Id,
                    a.Date,
                    a.Motive,
                    a.State,
                    a.Note,
                    PatientName = a.Patient != null ? $"{a.Patient.Name}" : "No Patient"
                });

                return Ok(appointmentsWithDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
