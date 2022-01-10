using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagement.Model
{
    public partial class UserLogin
    {
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
        [Key]
        public int EmployeeId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
