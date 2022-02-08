using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.DTO_models
{
    public class ManagerViewResponse
    {

        /// <summary>
        /// Employee ID
        /// </summary>
        public int Employee { get; set; }

        /// <summary>
        /// Leave Start Date
        /// </summary>
        [Required]
        public DateTime StartDate { get; set; }

        /// <summary>
        ///Leave End Date
        /// </summary>
        [Required]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Leave Comment
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// Approver ID
        /// </summary>
        [Required]
        public int Approver { get; set; }
    }
}
