using LeaveManagement.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult RequestLeave([FromBody][Required] LeaveRequest request)
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

    }
}