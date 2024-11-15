using System;
using System.Threading.Tasks;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.DTO;
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

    public class AppointmentControllerCreate : AppointmentController
    {
        public AppointmentControllerCreate(IAppointmentInterface appointmentInterface) : base(appointmentInterface) { }

        /// <summary>
        /// Create a new appointment.
        /// </summary>
        /// <param name="appointmentDto">Details of the appointment to create.</param>
        /// <returns>The created appointment with a 201 status code.</returns>
        [Authorize(Roles ="Admin, Doctor")]
        [HttpPost]
        [SwaggerOperation(
            Summary = "Create a new appointment",
            Description = "Creates a new appointment record in the system with the provided details."
        )]
        [ProducesResponseType(typeof(Appointment), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Appointment>> CreateAppointment([FromBody] AppointmentDto appointmentDto)
        {
            try
            {
                if (appointmentDto == null)
                    return BadRequest("Appointment details are required.");

                // Verificar la disponibilidad del médico
                var existingAppointment = await _appointmentInterface.GetByDoctorAndDate(appointmentDto.DoctorId, appointmentDto.Date);
                if (existingAppointment != null)
                    return Conflict("This doctor already has an appointment scheduled at this time.");

                // Crear la nueva cita
                var appointment = new Appointment
                {
                    Date = appointmentDto.Date,
                    PatientId = appointmentDto.PatientId,
                    DoctorId = appointmentDto.DoctorId,
                    Note = appointmentDto.Note
                };

                var createdAppointment = await _appointmentInterface.Add(appointment);

                return CreatedAtAction(nameof(CreateAppointment), new { id = createdAppointment.Id }, createdAppointment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
