﻿using TMCoreV2.DataAccess.Models.User;
using TMCoreV2.DataAccess.Models.Customer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMCoreV2.DataAccess.Repos
{
    public class CustomerRepository : ICustomerRepository
    {
        private TMDbContext _context;
        private ILogger<CustomerRepository> _logger;
        private readonly UserManager<AuthUser> _userManager;

        public CustomerRepository(TMDbContext context, 
            UserManager<AuthUser> userManager,
            ILogger<CustomerRepository> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        public void Add(Customer newCustomer)
        {
            _context.Add(newCustomer);
        }
        public void Delete(Customer customer)
        {
            _context.Remove(customer);
        }

        public IEnumerable<Customer> GetAll()
        {
            try
            {
                return _context.Customers.OrderByDescending(t => t.DateCreated);
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get customers from database", ex);
                return null;
            }
        }

        public IEnumerable<Customer> GetAllWithApplianceProblems()
        {
            try
            {
                return _context.Customers
                .Include(c => c.CustomerApplianceProblems)
                .OrderByDescending(p => p.DateCreated)
                .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get Customers with their Schedule time from database", ex);
                return null;
            }
        }

        public Customer FindById(int Id)
        {
            return _context.Customers.Include(c => c.CustomerApplianceProblems)
                           .Where(p => p.CustomerId == Id)
                           .FirstOrDefault();
        }

        public Customer FindByName(string customerName)
        {
            return _context.Customers.Include(p => p.CustomerApplianceProblems)
                           .Where(p => p.FirstName.Contains(customerName) || p.LastName.Contains(customerName))
                           .FirstOrDefault();
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
