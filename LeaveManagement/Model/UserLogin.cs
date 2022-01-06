using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Model
{
    public partial class UserLogin
    {
        public string Username { get; set; }
        [Key]
        public string Password { get; set; }
    }
}
