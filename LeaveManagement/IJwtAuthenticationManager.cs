using LeaveManagement.DTO_models;
using LeaveManagement.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace LeaveManagement
{
    public interface IJwtAuthenticationManager
    {
       string Post(Employee employee, string username, string password);
        public IActionResult RequestLeave(LeaveRequestInfo request);

        /// <summary>
        /// Gets LeaveRequest Detials
        /// </summary>
        /// <param name="Id">Manager ID</param>
        /// <returns>LeaveRequest Details</returns>
        IEnumerable<ManagerViewResponse> GetLeaveDetails(int managerId);


    }
}
