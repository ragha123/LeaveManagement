using LeaveManagement.DTO_models;
using LeaveManagement.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveManagementController : Controller
    {
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;

        public LeaveManagementController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }


        /// <summary>
        /// To generate Token.
        /// </summary>
        /// <param name="userCred">The details of the UserCredential to create an token.</param>
        /// <returns>The Token.</returns>
        /// <response code="201">Successfully created Token.</response>
        /// <response code="400">Request has missing/invalid values.</response>
        [HttpPost("authenticate")]
        [ProducesResponseType(typeof(OkObjectResult), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status403Forbidden)]
        public  IActionResult Post([FromBody] Employee employee)
        {
            var token = jwtAuthenticationManager.Post( employee,employee.Username,employee.Password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }

        /// <summary>
        /// create a leave Request
        /// </summary>
        /// <param name="request">The details of the Leave to be created.</param>
        /// <response code="201">created Leave Request.</response>
        /// <response code="400">Request has the values which is essensial.</response>
        /// <response code="401">Access token is missing or invalid.</response>
        /// <response code="403">Action not permitted for specified API key.</response>
        [Authorize]
        [HttpPost("leaveRequest")]
        [ProducesResponseType(typeof(OkResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status403Forbidden)]
        public IActionResult RequestLeave([FromBody][Required] LeaveRequestInfo request)
        {
            try
            {
                jwtAuthenticationManager.RequestLeave(request);
            }
            catch
            {
                return this.BadRequest();
            }
            return this.Ok();
        }

        /// <summary>
        /// Retrieves list of Leave Details.
        /// </summary>
        /// <param name="managerId">Manager ID</param>
        /// <returns>A collection of LeaveRequest.</returns>
        /// <response code="200">Successfully retrieved list of leave request.</response>
        /// <response code="404">No manager found for given managerId.</response>
        /// <response code="403">Action not permitted for specified API key.</response>
        /// <response code="401">Access token is missing or invalid.</response>
        [Authorize(Roles = "Manager")]
        [HttpGet("leaverequest/{managerId}")]
        [ProducesResponseType(typeof(IEnumerable<ManagerViewResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        public IActionResult GetLeaveDetailsAsync([FromRoute][Required] int managerId)
        {
            try
            {
                
                var details = jwtAuthenticationManager.GetLeaveDetails(managerId);

                if (details == null) return NotFound();

                return Ok(details);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

    }
}