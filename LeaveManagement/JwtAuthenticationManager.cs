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
        private readonly IOptions<JwtAuthenticationModel> _jwtAuthentication;
        private readonly EmployeeLeaveDBContext _context;

        public JwtAuthenticationManager(IOptions<JwtAuthenticationModel> jwtAuthentication, EmployeeLeaveDBContext context)
        {
            this._jwtAuthentication = jwtAuthentication;
            _context = context;
        }

        public  string Post(UserLogin _userData, string username, string password)
        {

            if (_userData != null && _userData.Username != null && _userData.Password != null)
            {
                
                var user = _context.Registrationtab.FirstOrDefault(x => x.Username == username && x.Password == password);

               // var user = await GetUser(_userData.Username, _userData.Password);
                if (user != null)
                {
                    var claims = new[] {
                    new Claim(ClaimTypes.Name,user.Username)
                   };

                    var token = new JwtSecurityToken(_jwtAuthentication.Value.ValidIssuer,
                            _jwtAuthentication.Value.ValidAudience,
                                                       claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: _jwtAuthentication.Value.SigningCredentials);

                    return new JwtSecurityTokenHandler().WriteToken(token);
                }
                return null;
            }
            else
            {
                return null;
            }
            
        }
        public IActionResult RequestLeave(LeaveRequest request)
        {
            var Employee = _context.Employee.FirstOrDefault(x => x.EmpId == request.RequestingEmployeeId);
            if (Employee != null)
            {
                _context.LeaveRequests.Add(request);
                _context.Database.OpenConnection();
                _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.LeaveRequests ON");
                _context.SaveChanges();
                _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.LeaveRequests OFF");
            }
            return null;
            
        }
    }
}

