using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Interface;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Models;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.DTO;
using Microsoft.AspNetCore.Authorization;

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.Controllers.V1.UserController
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Tags("Users")]
    public class UserCreateController : ControllerBase
    {
        private readonly IUserInterface _userInterface;

        public UserCreateController(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [SwaggerOperation(
                Summary = "Create a new user",
                Description = "Creates a new user record in the system with the provided user details."
            )]
        [ProducesResponseType(typeof(User), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateUser([FromBody] UserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("User data cannot be null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                var user = new User
                {
                    FullName = userDto.FullName,
                    Email = userDto.Email,
                    PasswordHash = userDto.PasswordHash // Asumiendo que el hash ya fue generado
                };

                var createdUser = await _userInterface.Add(user);
                return CreatedAtRoute("GetUserById", new { id = createdUser.Id }, createdUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
