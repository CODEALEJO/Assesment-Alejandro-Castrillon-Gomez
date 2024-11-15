using System.Threading.Tasks;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.DTO;
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

    public class DoctorControllerCreate : DoctorController
    {
        public DoctorControllerCreate(IDoctorInterface doctorInterfac) : base(doctorInterfac) { }

        /// <summary>
        /// Create a new doctor.
        /// </summary>
        /// <param name="doctorDto">The details of the doctor to create.</param>
        /// <returns>The created doctor with a 201 status code.</returns>
        /// <response code="201">Returns the created doctor.</response>
        /// <response code="400">If the provided data is invalid.</response>
        /// <response code="500">If an internal server error occurs.</response>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [SwaggerOperation(Summary = "Create a new doctor", Description = "Creates a new doctor using the provided details.")]
        [ProducesResponseType(typeof(Doctor), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Doctor>> CreateDoctor([FromBody] DoctorDto doctorDto)
        {
            try
            {
                if (doctorDto == null)
                    return BadRequest("Doctor details are required.");

                // Map the DoctorDto to a Doctor model
                var doctor = new Doctor
                {
                    Name = doctorDto.Name,
                    Specialty = doctorDto.Specialty,
                    Email = doctorDto.Email
                };

                // Call the service to create the doctor
                var createdDoctor = await _doctorInterface.Add(doctor);

                return CreatedAtAction(nameof(CreateDoctor), new { id = createdDoctor.Id }, createdDoctor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
