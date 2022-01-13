using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagement.Model
{
    public partial class Projects
    { 
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int EmpId { get; set; }

        public virtual Employee Emp { get; set; }
    }
}
