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
    public class PatientControllerCreate : ControllerBase
    {
        private readonly IPatientInterface _patientInterface;

        public PatientControllerCreate(IPatientInterface patientInterface)
        {
            _patientInterface = patientInterface;
        }

        /// <summary>
        /// Create a new patient.
        /// </summary>
        /// <param name="patientDto">The patient details to create.</param>
        /// <returns>The created patient with a 201 status code.</returns>
        /// <response code="201">Returns the created patient.</response>
        /// <response code="400">If the provided data is invalid.</response>
        /// <response code="500">If an internal server error occurs.</response>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [SwaggerOperation(Summary = "Create a new patient", Description = "Creates a new patient record.")]
        [ProducesResponseType(typeof(Patient), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Patient>> CreatePatient([FromBody] PatientDto patientDto)
        {
            try
            {
                if (patientDto == null)
                    return BadRequest("Patient details are required.");

                var patient = new Patient
                {
                    Name = patientDto.Name,
                    Email = patientDto.Email,
                    Phone = patientDto.Phone
                };

                var createdPatient = await _patientInterface.Add(patient);

                return CreatedAtAction(nameof(GetPatientById), new { id = createdPatient.Id }, createdPatient);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get a patient by ID.
        /// </summary>
        /// <param name="id">The ID of the patient.</param>
        /// <returns>The patient details.</returns>
        /// <response code="200">Returns the patient.</response>
        /// <response code="404">If the patient with the given ID does not exist.</response>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get a patient by ID", Description = "Retrieve the details of a specific patient.")]
        [ProducesResponseType(typeof(Patient), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Patient>> GetPatientById(int id)
        {
            var patient = await _patientInterface.GetById(id);
            if (patient == null)
                return NotFound($"Patient with ID {id} not found.");
            
            return Ok(patient);
        }
    }
}
