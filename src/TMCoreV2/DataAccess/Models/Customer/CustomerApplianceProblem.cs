using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMCoreV2.DataAccess.Models.Customer;

namespace TMCoreV2.DataAccess.Models.Customer
{
    public class CustomerApplianceProblem
    {
        [Key]
        [Required]
        public int CustomerApplianceProblemId { get; set; }

        [Display(Name = "Appliance Problem")]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 5,
            ErrorMessage = "First Name must be between 5 and 5000 characters long")]
        public string Problem { get; set; }

        [Display(Name = "Model Number")]
        [Required]
        [DataType(DataType.Text)]
        public string ModelNumber { get; set; }

        [Display(Name = "Model Serial")]
        [Required]
        [DataType(DataType.Text)]
        public string ModelSerial { get; set; }

        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        [Display(Name = "Approved To Work")]
        public bool ApprovedToWork { get; set; }

        [Display(Name = "Issue Resolved")]
        public bool IssueResolevd { get; set; }

        [Display(Name = "Date Issue Resolved")]
        public DateTime? DateResolved { get; set; }
        [Display(Name = "Issue Resolved By")]
        public string IssueResolvedBy { get; set; }


        //public int CustomerId { get; set; }
        //[ForeignKey("CustomerId")]
        //public virtual Customer Customer { get; set; }

        public int CustomerApplianceTypeId { get; set; }
        [ForeignKey("CustomerApplianceTypeId")]
        public virtual CustomerApplianceType customerApplianceType { get; set; }

        public int CustomerApplianceBrandId { get; set; }
        [ForeignKey("CustomerApplianceBrandId")]
        public virtual CustomerApplianceBrand customerApplianceBrand { get; set; }

        public virtual ICollection<CustomerApplianceProblemSchedule> CustomerApplianceProblemSchedules { get; set; }
    }
}
