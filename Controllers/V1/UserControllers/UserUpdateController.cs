using System;
using System.Threading.Tasks;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Interface;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.Controllers.V1.UserController
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Tags("Users")]
    public class UserUpdateController : ControllerBase
    {
        private readonly IUserInterface _userInterface;

        public UserUpdateController(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        [SwaggerOperation(
                Summary = "Update an existing user",
                Description = "Updates the details of an existing user based on the provided user ID and updated data."
            )]
        [ProducesResponseType(typeof(User), 200)]  // Successful update response
        [ProducesResponseType(400)]  // Invalid data
        [ProducesResponseType(404)]  // User not found
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User data cannot be null");
            }

            var existingUser = await _userInterface.GetById(id);
            if (existingUser == null)
            {
                return NotFound($"User with ID {id} not found");
            }


            existingUser.FullName = user.FullName;
            existingUser.Email = user.Email;

            await _userInterface.Update(existingUser);

            return Ok(existingUser);
        }
    }
}
