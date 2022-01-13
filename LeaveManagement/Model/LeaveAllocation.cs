using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime;


namespace LeaveManagement.Model
{
    public class LeaveAllocation
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Employee Employee { get; set; }
        public int EmployeeId { get; set; }
         
    }
}
