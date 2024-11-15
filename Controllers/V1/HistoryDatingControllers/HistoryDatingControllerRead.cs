using Assesment_Alejandro_Castrillon_Gomez_bernslee.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.Controllers.V1.HistoryDatingControllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Tags("HistoryDating")]

    public class HistoryDatingControllerRead : ControllerBase
    {
        private readonly IHistoryDatingInterface _historyDatingService;

        public HistoryDatingControllerRead(IHistoryDatingInterface historyDatingService)
        {
            _historyDatingService = historyDatingService;
        }

        /// <summary>
        /// Retrieves all History Dating entries.
        /// </summary>
        /// <returns>A list of all History Dating entries.</returns>
        /// <response code="200">Returns a list of History Dating entries</response>
        [Authorize(Roles = "Admin, Doctor")]
        [HttpGet("all")]
        [SwaggerOperation(Summary = "Get all History Dating entries", Description = "Retrieves a list of all History Dating entries.")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAllHistoryDatings()
        {
            try
            {
                var allHistoryDatings = await _historyDatingService.GetAll();

                if (allHistoryDatings == null || !allHistoryDatings.Any())
                {
                    return NotFound("No History Dating entries found.");
                }

                return Ok(allHistoryDatings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving all History Dating entries: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves filtered History Dating entries by patient, date, and reason.
        /// </summary>
        /// <returns>A list of filtered History Dating entries based on provided parameters.</returns>
        /// <response code="200">Returns filtered History Dating entries</response>
        [Authorize(Roles = "Admin, Doctor")]
        [HttpGet("filter")]
        [SwaggerOperation(Summary = "Get filtered History Dating entries", Description = "Retrieves a list of History Dating entries filtered by patient, date, and reason.")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetFilteredHistoryDatings(int? patientId, DateTime? date, string reason)
        {
            try
            {
                var filteredHistoryDatings = await _historyDatingService.GetFiltered(patientId, date, reason);

                if (filteredHistoryDatings == null || !filteredHistoryDatings.Any())
                {
                    return NotFound("No History Dating entries found for the given filters.");
                }

                return Ok(filteredHistoryDatings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving filtered History Dating entries: {ex.Message}");
            }
        }
    }
}
