using System;
using System.Threading.Tasks;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.Controllers.V1.UserController
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Tags("Users")]
    public class UserDeleteController : ControllerBase
    {
        private readonly IUserInterface _userInterface;

        public UserDeleteController(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

       [Authorize]
        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete a user by ID",
            Description = "Deletes the user record from the system based on the provided user ID."
        )]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userInterface.GetById(id);
            if (user == null)
            {
                return NotFound($"User with ID {id} not found");
            }

            await _userInterface.Delete(id);
            return NoContent();
        }
    }
}
