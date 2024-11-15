using System.Collections.Generic;
using System.Threading.Tasks;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Interface;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.Controllers.V1.DoctorControllers
{
    [ApiController]
    [Route("api/v1/doctors")]
    [Tags("Doctor")]

    public class DoctorControllerRead : DoctorController
    {
        public DoctorControllerRead(IDoctorInterface doctorInterfac) : base(doctorInterfac) { }

        /// <summary>
        /// Get all doctors.
        /// </summary>
        /// <returns>A list of all doctors.</returns>
        /// <response code="200">Returns a list of doctors.</response>
        /// <response code="500">If an internal server error occurs.</response>
        [Authorize(Roles = "Admin, Doctor")]
        [HttpGet]
        [SwaggerOperation(Summary = "Get all doctors", Description = "Fetches the list of all doctors.")]
        [ProducesResponseType(typeof(IEnumerable<Doctor>), 200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetAllDoctors()
        {
            try
            {
                var doctors = await _doctorInterface.GetAll();
                return Ok(doctors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get a doctor by ID.
        /// </summary>
        /// <param name="id">The ID of the doctor to retrieve.</param>
        /// <returns>The doctor details.</returns>
        /// <response code="200">Returns the doctor.</response>
        /// <response code="404">If the doctor with the given ID does not exist.</response>
        /// <response code="500">If an internal server error occurs.</response>
        [Authorize(Roles = "Admin, Doctor")]
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get a doctor by ID", Description = "Fetches the details of a doctor based on the provided ID.")]
        [ProducesResponseType(typeof(Doctor), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Doctor>> GetDoctorById(int id)
        {
            try
            {
                var doctor = await _doctorInterface.GetById(id);
                if (doctor == null)
                    return NotFound($"Doctor with ID {id} not found.");

                return Ok(doctor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
