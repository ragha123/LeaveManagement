using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagement.Model
{
    public class LeaveRequest
    {
        public int Id { get; set; }
        public virtual Employee RequestingEmployee { get; set; }
        public int Employee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Comments { get; set; }
        public Status Status { get; set; }
        public int Approver { get; set; }
    }
}
