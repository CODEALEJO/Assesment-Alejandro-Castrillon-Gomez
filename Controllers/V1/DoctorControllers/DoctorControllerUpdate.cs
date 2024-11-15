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

    public class DoctorControllerUpdate : DoctorController
    {
        public DoctorControllerUpdate(IDoctorInterface doctorInterfac) : base(doctorInterfac) { }

        /// <summary>
        /// Update an existing doctor by ID.
        /// </summary>
        /// <param name="id">The ID of the doctor to update.</param>
        /// <param name="doctorDto">The updated details for the doctor.</param>
        /// <returns>The updated doctor with a 200 status code.</returns>
        /// <response code="200">Returns the updated doctor.</response>
        /// <response code="400">If the provided data is invalid.</response>
        /// <response code="404">If the doctor with the given ID does not exist.</response>
        /// <response code="500">If an internal server error occurs.</response>
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update an existing doctor", Description = "Updates the details of an existing doctor based on the provided ID.")]
        [ProducesResponseType(typeof(Doctor), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Doctor>> UpdateDoctor(int id, [FromBody] DoctorDto doctorDto)
        {
            try
            {
                if (doctorDto == null)
                    return BadRequest("Doctor details are required.");

                // Verificar si el doctor existe
                var existingDoctor = await _doctorInterface.GetById(id);
                if (existingDoctor == null)
                    return NotFound($"Doctor with ID {id} not found.");

                // Mapear los valores actualizados desde DoctorDto
                existingDoctor.Name = doctorDto.Name;
                existingDoctor.Specialty = doctorDto.Specialty;
                existingDoctor.Email = doctorDto.Email;

                // Llamar al servicio para actualizar el doctor
                var updatedDoctor = await _doctorInterface.Update(existingDoctor);

                return Ok(updatedDoctor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
