using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMCoreV2.DataAccess.Models.Customer
{
    public class CustomerApplianceType
    {
        [Key]
        [Required]
        public int CustomerApplianceTypeId { get; set; }

        [Display(Name = "Appliance Type")]
        [Required]
        [DataType(DataType.Text)]
        public string Type { get; set; }

        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<CustomerApplianceBrand> CustomerApplianceBrands { get; set; }
    }
}
