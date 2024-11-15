using System.Threading.Tasks;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.Controllers.V1.PatientControllers
{
    [ApiController]
    [Route("api/v1/patients")]
    [Tags("Patient")]
    public class PatientControllerDelete : ControllerBase
    {
        private readonly IPatientInterface _patientInterface;

        public PatientControllerDelete(IPatientInterface patientInterface)
        {
            _patientInterface = patientInterface;
        }

        /// <summary>
        /// Delete a patient by ID.
        /// </summary>
        /// <param name="id">The ID of the patient to delete.</param>
        /// <returns>No content if deleted successfully.</returns>
        /// <response code="204">If the patient is deleted successfully.</response>
        /// <response code="404">If the patient with the given ID does not exist.</response>
        /// <response code="500">If an internal server error occurs.</response>
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a patient by ID", Description = "Deletes a patient record by their ID.")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> DeletePatient(int id)
        {
            try
            {
                await _patientInterface.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Patient with ID {id} not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
