using System;
using System.Threading.Tasks;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.Controllers.V1.AppointmentControllers
{
    [ApiController]
    [Route("api/v1/appointments")]
        [Tags("Appointment")]

    public class AppointmentControllerDelete : AppointmentController
    {
        public AppointmentControllerDelete(IAppointmentInterface appointmentInterface) : base(appointmentInterface) { }

        /// <summary>
        /// Delete an appointment by its ID.
        /// </summary>
        /// <param name="id">The ID of the appointment to delete.</param>
        /// <returns>No content if successful; otherwise, an error message.</returns>
        [Authorize(Roles = "Admin, Doctor")]
        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete an appointment",
            Description = "Deletes an existing appointment by its unique ID."
        )]
        [ProducesResponseType(204)] 
        [ProducesResponseType(404)] 
        [ProducesResponseType(500)] 
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            try
            {
                var existingAppointment = await _appointmentInterface.GetById(id);
                if (existingAppointment == null)
                {
                    return NotFound($"Appointment with ID {id} not found.");
                }

                await _appointmentInterface.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
