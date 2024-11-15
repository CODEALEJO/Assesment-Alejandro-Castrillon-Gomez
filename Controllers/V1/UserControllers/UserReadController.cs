using System;
using System.Collections.Generic;
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
    public class UserReadController : ControllerBase
    {
        private readonly IUserInterface _userInterface;

        public UserReadController(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        /// <summary>
        /// Retrieves all users from the system.
        /// </summary>
        /// <returns>A list of users.</returns>
        /// <response code="200">Returns a list of all users in the system.</response>
        [Authorize]
        [HttpGet]
        [SwaggerOperation(
            Summary = "Get all users",
            Description = "Retrieves a list of all users available in the system."
        )]
        [ProducesResponseType(typeof(IEnumerable<User>), 200)]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userInterface.GetAll();
            return Ok(users);
        }

        [Authorize]
        [HttpGet("{id}", Name = "GetUserById")]
        [SwaggerOperation(
            Summary = "Get user by ID",
            Description = "Retrieves a user based on the provided user ID."
        )]
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userInterface.GetById(id);
            if (user == null)
            {
                return NotFound($"User with ID {id} not found");
            }
            return Ok(user);
        }
    }
}
