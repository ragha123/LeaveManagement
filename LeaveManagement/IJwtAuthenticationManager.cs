using LeaveManagement.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement
{
    public interface IJwtAuthenticationManager
    {
       string Post(Employee employee, string username, string password);
        public IActionResult RequestLeave(LeaveRequest request);


    }
}
