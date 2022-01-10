using LeaveManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Repository
{
    public interface ILeaveRequestRepo : IRepositoryBase<LeaveRequest>
    {
       // ICollection<LeaveRequest> GetLeaveRequests(int projectid);
    }
}
