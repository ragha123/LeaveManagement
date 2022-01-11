using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagement.Model
{
    public class LeaveRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("RequestingEmployeeId")]
        public virtual Employee RequestingEmployee { get; set; }
        public Employee Employee { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public string Comments { get; set; }
        public Status Status { get; set; }
        public Employee Approver { get; set; }
    }
}
