using System.Threading.Tasks;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.Controllers.V1.DoctorControllers
{
    [ApiController]
    [Route("api/v1/doctors")]
            [Tags("Doctor")]

    public class DoctorControllerDelete : DoctorController
    {
        public DoctorControllerDelete(IDoctorInterface doctorInterfac) : base(doctorInterfac) { }

        /// <summary>
        /// Delete an existing doctor by ID.
        /// </summary>
        /// <param name="id">The ID of the doctor to delete.</param>
        /// <returns>A 204 status code if successful, 404 if doctor not found.</returns>
        /// <response code="204">Doctor deleted successfully.</response>
        /// <response code="404">If the doctor with the given ID does not exist.</response>
        /// <response code="500">If an internal server error occurs.</response>
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete an existing doctor", Description = "Deletes an existing doctor based on the provided ID.")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> DeleteDoctor(int id)
        {
            try
            {
                var doctor = await _doctorInterface.GetById(id);
                if (doctor == null)
                    return NotFound($"Doctor with ID {id} not found.");

                await _doctorInterface.Delete(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
