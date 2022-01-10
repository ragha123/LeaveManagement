using LeaveManagement.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement
{
    public class JwtAuthenticationManager: IJwtAuthenticationManager
    {
        private readonly IOptions<JwtAuthenticationModel> jwtAuthentication;
        private readonly EmployeeLeaveDBContext _context;

        public JwtAuthenticationManager(IOptions<JwtAuthenticationModel> jwtAuthentication, EmployeeLeaveDBContext context)
        {
            this.jwtAuthentication = jwtAuthentication;
            _context = context;
        }

        public  string Post(UserLogin userData, string username, string password)
        {

            if (userData != null && userData.Username != null && userData.Password != null)
            {
                var user = _context.Registrationtab.FirstOrDefault(x => x.Username == username && x.Password == password);

                if (user != null)
                {
                    var claims = new[] {
                    new Claim(ClaimTypes.Name,user.Username)
                   };

                    var token = new JwtSecurityToken(jwtAuthentication.Value.ValidIssuer,
                                                     jwtAuthentication.Value.ValidAudience,
                                                     claims,
                                                     expires: DateTime.UtcNow.AddMinutes(5),
                                                     signingCredentials: jwtAuthentication.Value.SigningCredentials);

                    return new JwtSecurityTokenHandler().WriteToken(token);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

        }

    }
}

