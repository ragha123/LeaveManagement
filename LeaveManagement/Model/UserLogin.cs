using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Model
{
    public partial class UserLogin
    {
        public string Username { get; set; }
        [Key]
        public string Password { get; set; }
    }
}
