using TMCoreV2.DataAccess.Models.Customer;
using TMCoreV2.Services;
using TMCoreV2.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMCoreV2.DataAccess.Models.Customer;
using System.ComponentModel.DataAnnotations;

namespace TMCoreV2.ViewModels.CustomerViewModels
{
    public class CustomerIndex
    {
        public IEnumerable<Customer> Customers { get; set; }
    }
    public class CustomerViewModel
    {
        [Display(Name = "First Name")]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 2,
            ErrorMessage = "First Name must be between 2 and 100 characters long")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 2,
           ErrorMessage = "Last Name must be between 2 and 100 characters long")]
        public string LastName { get; set; }

        public string CustomerName {
            get { return string.Format("{0} {1}", FirstName, LastName); }
            set { string.Format("{0} {1}", FirstName, LastName); }
        }

        [Display(Name = "Phone Number")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Addess")]
        [Required]
        [DataType(DataType.Text)]
        public string Addess { get; set; }

        [Display(Name = "City")]
        [Required]
        [DataType(DataType.Text)]
        public string City { get; set; }

        [Display(Name = "State")]
        [Required]
        [DataType(DataType.Text)]
        public string State { get; set; }

        [Display(Name = "Postal Code")]
        [Required]
        [DataType(DataType.Text)]
        public string PostalCode { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public ICollection<CustomerApplianceProblem> CustomerApplianceProblems { get; set; }
    }
}
