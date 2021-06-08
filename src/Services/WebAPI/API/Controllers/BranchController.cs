using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.Application.Requests.Branches.Queries;

namespace WebAPI.API.Controllers
{

    [ApiController]
    [AllowAnonymous]
    [Route("[controller]/[action]")]
    public class BranchController : ApiController
    {
        private readonly ILogger<BranchController> _Logger;

        public BranchController(ILogger<BranchController> logger)
        {
            _Logger = logger;
        }

        /// <summary>
        /// Get all Branches
        /// </summary>
        /// <returns>An IEnumerable of Branch records</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BranchDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            IEnumerable<BranchDTO> result = await Mediator.Send(new GetBranchesQuery());

            if (result.Any())
                return Ok(result);

            return StatusCode(204, "No Branches found.");
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BranchDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetBranch(int id)
        {
            BranchDTO result = await Mediator.Send(new GetBranchQuery(id));

            if (result != null)
                return Ok(result);

            return StatusCode(204, "No Branch found for that ID.");
        }
    }
}
