using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMCoreV2.DataAccess.Models.Customer
{
    public class CustomerApplianceProblemSchedule
    {
        [Key]
        [Required]
        public int CustomerApplianceProblemScheduleId { get; set; }

        [Display(Name = "Desired Schedule Time")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DesiredScheduleTime { get; set; }

        [Display(Name = "Actual Schedule Time")]
        [DataType(DataType.DateTime)]
        public DateTime? ActualScheduleTime { get; set; }

        [Display(Name = "Schedule Cancelled")]
        public bool ScheduleCancelled { get; set; }

        public DateTime? DateUpdated { get; set; }
        public string UpdatedBy { get; set; }

    }
}
