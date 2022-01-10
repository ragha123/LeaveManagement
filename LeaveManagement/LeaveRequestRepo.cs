using LeaveManagement.Model;
using LeaveManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement
{
    public class LeaveRequestRepo: ILeaveRequestRepo
    {
        private readonly EmployeeLeaveDBContext _db;

        public LeaveRequestRepo(EmployeeLeaveDBContext db)
        {
            _db = db;
        }
        public ICollection<LeaveRequest> FindAll()
        {
            var LeaveDetails = _db.LeaveRequests
                .ToList();
            return LeaveDetails;
        }

        //public ICollection<LeaveRequest> GetLeaveRequests(int projectid)
        //{
        //    var leaveRequests = FindAll()
        //        .Where(q => q.ProjectId == projectid)
        //        .ToList();
        //    return leaveRequests;
        //}
    }
}
