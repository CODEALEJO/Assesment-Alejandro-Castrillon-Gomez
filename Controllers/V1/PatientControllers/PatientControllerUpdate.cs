using System.Threading.Tasks;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.DTO;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Interface;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.Controllers.V1.PatientControllers
{
    [ApiController]
    [Route("api/v1/patients")]
    [Tags("Patient")]
    public class PatientControllerUpdate : ControllerBase
    {
        private readonly IPatientInterface _patientInterface;

        public PatientControllerUpdate(IPatientInterface patientInterface)
        {
            _patientInterface = patientInterface;
        }

        /// <summary>
        /// Update an existing patient by ID.
        /// </summary>
        /// <param name="id">The ID of the patient to update.</param>
        /// <param name="patientDto">The updated patient details.</param>
        /// <returns>The updated patient with a 200 status code.</returns>
        /// <response code="200">Returns the updated patient.</response>
        /// <response code="400">If the provided data is invalid.</response>
        /// <response code="404">If the patient with the given ID does not exist.</response>
        /// <response code="500">If an internal server error occurs.</response>
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update an existing patient", Description = "Updates the details of an existing patient based on the provided ID.")]
        [ProducesResponseType(typeof(Patient), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Patient>> UpdatePatient(int id, [FromBody] PatientDto patientDto)
        {
            try
            {
                if (patientDto == null)
                    return BadRequest("Patient details are required.");

                // Check if the patient exists
                var existingPatient = await _patientInterface.GetById(id);
                if (existingPatient == null)
                    return NotFound($"Patient with ID {id} not found.");

                // Map the updated values from PatientDto
                existingPatient.Name = patientDto.Name;
                existingPatient.Email = patientDto.Email;
                existingPatient.Phone = patientDto.Phone;

                // Call the service to update the patient
                await _patientInterface.Update(existingPatient);

                return Ok(existingPatient);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
