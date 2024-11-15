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

    public class AppointmentControllerUpdate : AppointmentController
    {
        public AppointmentControllerUpdate(IAppointmentInterface appointmentInterface) : base(appointmentInterface) { }

        /// <summary>
        /// Update an existing appointment.
        /// </summary>
        /// <param name="id">The ID of the appointment to update.</param>
        /// <param name="appointmentDto">The new details for the appointment.</param>
        /// <returns>The updated appointment with a 200 status code.</returns>
        /// <response code="200">Returns the updated appointment.</response>
        /// <response code="400">If the provided data is invalid.</response>
        /// <response code="404">If the appointment with the given ID does not exist.</response>
        /// <response code="500">If an internal server error occurs.</response>
        [Authorize(Roles = "Admin, Doctor")]
        [HttpPut("{id}")]
        [SwaggerOperation(
      Summary = "Update an existing appointment",
      Description = "Updates the details of an existing appointment based on the provided ID."
  )]
        [ProducesResponseType(typeof(Appointment), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> UpdateAppointment(int id, [FromBody] AppointmentDto appointmentDto)
        {
            try
            {
                if (appointmentDto == null)
                    return BadRequest("Appointment details are required.");

                // Check if the appointment exists
                var existingAppointment = await _appointmentInterface.GetById(id);
                if (existingAppointment == null)
                    return NotFound($"Appointment with ID {id} not found.");

                // Map the updated values from AppointmentDto
                existingAppointment.Date = appointmentDto.Date;
                existingAppointment.Motive = appointmentDto.Motive;
                existingAppointment.State = appointmentDto.State;
                existingAppointment.Note = appointmentDto.Note;

                // Call the service to update the appointment
                await _appointmentInterface.Update(existingAppointment);

                return NoContent();  // Retorna 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
