using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Model
{
    public partial class Company
    {
        public Company()
        {
            Employee = new HashSet<Employee>();
        }

        [Key]
        public int CompanyId { get; set; }
        public string Companyname { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
