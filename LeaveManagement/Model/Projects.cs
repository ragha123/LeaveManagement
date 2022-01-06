using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Model
{
    public partial class Projects
    {
        [Key]
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? EmpId { get; set; }

        public virtual Employee Emp { get; set; }
    }
}
