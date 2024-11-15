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

    public class HistoryDatingControllerUpdate : ControllerBase
    {
        private readonly IHistoryDatingInterface _historyDatingService;

        public HistoryDatingControllerUpdate(IHistoryDatingInterface historyDatingService)
        {
            _historyDatingService = historyDatingService;
        }

        /// <summary>
        /// Updates an existing History Dating entry.
        /// </summary>
        /// <param name="id">The ID of the History Dating entry to update.</param>
        /// <param name="historyDating">The updated History Dating data.</param>
        /// <returns>The updated History Dating entry.</returns>
        /// <response code="200">Returns the updated History Dating entry.</response>
        /// <response code="400">Bad request if the data is invalid.</response>
        /// <response code="404">History Dating entry not found.</response>
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update History Dating entry", Description = "Updates an existing History Dating entry based on the provided ID.")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateHistoryDating(int id, [FromBody] HistoryDating historyDating)
        {
            if (historyDating == null)
            {
                return BadRequest("Invalid data. The History Dating data is required.");
            }

            try
            {
                if (id != historyDating.Id)
                {
                    return BadRequest("ID mismatch. The ID in the URL and the data should be the same.");
                }

                await _historyDatingService.Update(historyDating);

                return Ok(historyDating);
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"HistoryDating with ID {id} not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating History Dating entry with ID {id}: {ex.Message}");
            }
        }
    }
}
