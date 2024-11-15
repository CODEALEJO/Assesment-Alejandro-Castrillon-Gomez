using Assesment_Alejandro_Castrillon_Gomez_bernslee.Interface;
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

    public class HistoryDatingControllerDelete : ControllerBase
    {
        private readonly IHistoryDatingInterface _historyDatingService;

        public HistoryDatingControllerDelete(IHistoryDatingInterface historyDatingService)
        {
            _historyDatingService = historyDatingService;
        }

        /// <summary>
        /// Deletes a History Dating entry by ID.
        /// </summary>
        /// <param name="id">The ID of the History Dating entry to be deleted.</param>
        /// <returns>Result of the deletion operation.</returns>
        /// <response code="204">Successfully deleted</response>
        /// <response code="404">HistoryDating entry not found</response>
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete History Dating entry by ID", Description = "Deletes a specific history dating entry based on the provided ID.")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteHistoryDating(int id)
        {
            try
            {
           
                await _historyDatingService.Delete(id);

              
                return NoContent();
            }
            catch (KeyNotFoundException)
            {

                return NotFound($"HistoryDating with ID {id} not found.");
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Error deleting History Dating: {ex.Message}");
            }
        }
    }
}
