using Assesment_Alejandro_Castrillon_Gomez_bernslee.Interface;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.Controllers.V1.HistoryDatingControllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
        [Tags("HistoryDating")]

    public class HistoryDatingControllerCreate : ControllerBase
    {
        private readonly IHistoryDatingInterface _historyDatingService;

        public HistoryDatingControllerCreate(IHistoryDatingInterface historyDatingService)
        {
            _historyDatingService = historyDatingService;
        }

        /// <summary>
        /// Creates a new History Dating entry.
        /// </summary>
        /// <param name="historyDating">The History Dating object to be created.</param>
        /// <returns>The created History Dating entry.</returns>
        /// <response code="201">Successfully created</response>
        /// <response code="400">Invalid input</response>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [SwaggerOperation(Summary = "Create a new History Dating entry", Description = "Creates a new entry for a history dating record in the system.")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateHistoryDating([FromBody] HistoryDating historyDating)
        {
            if (historyDating == null)
            {
                return BadRequest("HistoryDating object is null.");
            }

            try
            {
                // Llamada al servicio para crear el registro HistoryDating
                var createdHistoryDating = await _historyDatingService.Add(historyDating);

                // Devolvemos la respuesta con el nuevo recurso creado
                return CreatedAtAction(nameof(GetHistoryDatingById), new { id = createdHistoryDating.Id }, createdHistoryDating);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error creating History Dating: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves a History Dating entry by ID.
        /// </summary>
        /// <param name="id">The ID of the History Dating entry.</param>
        /// <returns>The History Dating entry with the specified ID.</returns>
        /// <response code="200">Successfully retrieved</response>
        /// <response code="404">HistoryDating entry not found</response>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get History Dating by ID", Description = "Fetch a specific history dating entry by its ID.")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetHistoryDatingById(int id)
        {
            try
            {
                var historyDating = await _historyDatingService.GetById(id);
                return Ok(historyDating);
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"HistoryDating with ID {id} not found.");
            }
        }
    }
}
