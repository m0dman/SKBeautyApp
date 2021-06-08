using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.Application.Requests.Treatments.Queries;

namespace WebAPI.API.Controllers
{

    [ApiController]
    [AllowAnonymous]
    [Route("[controller]/[action]")]
    public class TreatmentController : ApiController
    {
        private readonly ILogger<TreatmentController> _Logger;

        public TreatmentController(ILogger<TreatmentController> logger)
        {
            _Logger = logger;
        }

        /// <summary>
        /// Get all Branches
        /// </summary>
        /// <returns>An IEnumerable of Branch records</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TreatmentDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            IEnumerable<TreatmentDTO> result = await Mediator.Send(new GetTreatmentsQuery());

            if (result.Any())
                return Ok(result);

            return StatusCode(204, "No Treatments found.");
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TreatmentDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetTreatment(int id)
        {
            TreatmentDTO result = await Mediator.Send(new GetTreatmentQuery(id));

            if (result != null)
                return Ok(result);

            return StatusCode(204, "No Treatment found for that ID.");
        }

        [HttpGet("{branchID}")]
        [ProducesResponseType(typeof(IEnumerable<TreatmentDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetTreatmentsByBranchID(int branchID)
        {
            IEnumerable<TreatmentDTO> result = await Mediator.Send(new GetTreatmentByBranchIDQuery(branchID));

            if (result != null)
                return Ok(result);

            return StatusCode(204, "No Treatments found for that Branch ID.");
        }
    }
}
