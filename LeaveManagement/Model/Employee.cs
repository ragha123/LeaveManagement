using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagement.Model
{
    public partial class Employee
    {
        public Employee()
        {
            Projects = new HashSet<Projects>();
        }


        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public virtual Role Role { get; set; }

        public int CompanyId { get; set; }

        public string Username { get; set; }

        
        public string Password { get; set; }
        public bool IsDeleted { get; set; }


        public virtual Company Company { get; set; }
        public virtual ICollection<Projects> Projects { get; set; }
    }
}
