using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TMCoreV2.DataAccess.Models.Customer;
using TMCoreV2.ViewModels.CustomerViewModels;
using TMCoreV2.DataAccess.Repos;

namespace TMCoreV2.Controllers
{
    [Route("customer")]
    public class CustomerController : Controller
    {
        private CustomerRepository _CustomerRepository;

        public CustomerController(CustomerRepository CustomerRepository)
        {
            _CustomerRepository = CustomerRepository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
