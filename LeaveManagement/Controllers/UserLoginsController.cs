using LeaveManagement.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserLoginsController : Controller
    {
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;

        public UserLoginsController(IJwtAuthenticationManager jwtAuthenticationManager)
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
        [ProducesResponseType(typeof(JwtAuthenticationModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status403Forbidden)]
        public  IActionResult Post([FromBody] UserLogin userCred)
        {
            var token = jwtAuthenticationManager.Post(userCred, userCred.Username,userCred.Password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
}