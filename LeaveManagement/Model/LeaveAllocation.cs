using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime;


namespace LeaveManagement.Model
{
    public class LeaveAllocation
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }

        [ForeignKey("EmpId")]
        public virtual Employee Employee { get; set; }
        public int EmployeeId { get; set; }
         
    }
}
