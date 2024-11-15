using System.Collections.Generic;
using System.Threading.Tasks;
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
    public class PatientControllerRead : ControllerBase
    {
        private readonly IPatientInterface _patientInterface;

        public PatientControllerRead(IPatientInterface patientInterface)
        {
            _patientInterface = patientInterface;
        }

        /// <summary>
        /// Get all patients.
        /// </summary>
        /// <returns>A list of all patients.</returns>
        /// <response code="200">Returns the list of patients.</response>
        /// <response code="500">If an internal server error occurs.</response>
        [Authorize(Roles = "Admin, Doctor")]
        [HttpGet]
        [SwaggerOperation(Summary = "Get all patients", Description = "Retrieves a list of all patients.")]
        [ProducesResponseType(typeof(IEnumerable<Patient>), 200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<Patient>>> GetAllPatients()
        {
            try
            {
                var patients = await _patientInterface.GetAll();
                return Ok(patients);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
