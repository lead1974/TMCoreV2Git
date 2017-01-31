using TMCoreV2.DataAccess.Models.Customer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMCoreV2.DataAccess;
using TMCoreV2.DataAccess.Models.Customer;
using TMCoreV2.DataAccess.Models.User;
using TMCoreV2.DataAccess.Repos;
using TMCoreV2.Services;

namespace TMCoreV2.DataAccess
{
    public class TMCoreSeedData
    {
        private readonly UserManager<AuthUser> _userManager;
        private readonly SignInManager<AuthUser> _signInManager;
        private readonly RoleManager<AuthRole> _roleManager;
        private TMDbContext _tmContext;
        private readonly ILogger _logger;

        private ICustomerRepository _customerRepo;
        private GlobalService _globalService;

        public TMCoreSeedData(
            TMDbContext tmContext,
            ICustomerRepository customerRepo,
            UserManager<AuthUser> userManager,
            SignInManager<AuthUser> signInManager,
            RoleManager<AuthRole> roleManager,
            GlobalService globalService,
            ILoggerFactory loggerFactory)
        {
            _tmContext = tmContext;
            _customerRepo = customerRepo;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _globalService = globalService;
            _logger = loggerFactory.CreateLogger<TMCoreSeedData>();
        }

        public async Task EnsureSeedData()
        {
            await SeedAdminUsers();
            await SeedCustomerAndAppliances();
        }
        private async Task SeedAdminUsers()
        {
            var user = new AuthUser
            {
                UserName = "balda@balda.com",
                NormalizedUserName = "balda@balda.com",
                Email = "balda@balda.com",
                NormalizedEmail = "balda@balda.com",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var roleStore = new RoleStore<AuthRole>(_tmContext);

            if (!_tmContext.Roles.Any(r => r.Name == RoleName.CanManageSite))
            {
                await roleStore.CreateAsync(new AuthRole { Name = RoleName.CanManageSite, NormalizedName = RoleName.CanManageSite, Description="Site Administrator" });
            }

            if (!_tmContext.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<AuthUser>();
                var hashed = password.HashPassword(user, "balda1234");
                user.PasswordHash = hashed;
                await _userManager.CreateAsync(user);
                await _userManager.AddToRoleAsync(user, RoleName.CanManageSite);
            }

            await _tmContext.SaveChangesAsync();
        }

        private async Task SeedCustomerAndAppliances()
        {
            if (!_tmContext.CustomerApplianceTypes.Any())
            {
                var customerApplianceType1 = new CustomerApplianceType()
                {
                    Type = "Air Conditioner",
                    CreatedBy = "SYSTEM",
                    DateCreated = DateTime.UtcNow,
                    CustomerApplianceBrands = new List<CustomerApplianceBrand>()
                     {
                         new CustomerApplianceBrand() { Brand= "American Standard", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow},
                         new CustomerApplianceBrand() { Brand= "Carrier", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow},
                         new CustomerApplianceBrand() { Brand= "Crosley", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow},
                         new CustomerApplianceBrand() { Brand= "Danby", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow},
                         new CustomerApplianceBrand() { Brand= "Delonghi", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow},
                         new CustomerApplianceBrand() { Brand= "Modern-Aire", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow},
                         new CustomerApplianceBrand() { Brand= "Sterling", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow},
                         new CustomerApplianceBrand() { Brand= "Tappan", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow },
                         new CustomerApplianceBrand() { Brand= "Other", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow }
                     }
                };
                _tmContext.CustomerApplianceTypes.Add(customerApplianceType1);
                _tmContext.CustomerApplianceBrands.AddRange(customerApplianceType1.CustomerApplianceBrands);

                var customerApplianceType2 = new CustomerApplianceType()
                {
                    Type = "BBQ",
                    CreatedBy = "SYSTEM",
                    DateCreated = DateTime.UtcNow,
                    CustomerApplianceBrands = new List<CustomerApplianceBrand>()
                     {
                         new CustomerApplianceBrand() { Brand= "Bertazzoni", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow},
                         new CustomerApplianceBrand() { Brand= "Bosh", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow},
                         new CustomerApplianceBrand() { Brand= "Brown", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow},
                         new CustomerApplianceBrand() { Brand= "Chambers", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow},
                         new CustomerApplianceBrand() { Brand= "Dacor", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow},
                         new CustomerApplianceBrand() { Brand= "Danby", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow},
                         new CustomerApplianceBrand() { Brand= "Delonghi", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow},
                         new CustomerApplianceBrand() { Brand= "Dynasty", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow },
                         new CustomerApplianceBrand() { Brand= "Dynasty", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow },
                         new CustomerApplianceBrand() { Brand= "Frigidaire", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow },
                         new CustomerApplianceBrand() { Brand= "KitchenAid", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow },
                         new CustomerApplianceBrand() { Brand= "Samsung", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow },
                         new CustomerApplianceBrand() { Brand= "Viking", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow },
                         new CustomerApplianceBrand() { Brand= "Wold", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow },
                         new CustomerApplianceBrand() { Brand= "Zephyr", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow },
                         new CustomerApplianceBrand() { Brand= "Other", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow }
                     }
                };
                _tmContext.CustomerApplianceTypes.Add(customerApplianceType2);
                _tmContext.CustomerApplianceBrands.AddRange(customerApplianceType2.CustomerApplianceBrands);

                var customerApplianceType3 = new CustomerApplianceType()
                {
                    Type = "Cooktop",
                    CreatedBy = "SYSTEM",
                    DateCreated = DateTime.UtcNow,
                    CustomerApplianceBrands = new List<CustomerApplianceBrand>()
                     {
                         new CustomerApplianceBrand() { Brand= "Avanti", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow},
                         new CustomerApplianceBrand() { Brand= "Bertazzoni", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow},
                         new CustomerApplianceBrand() { Brand= "Bosch", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow},
                         new CustomerApplianceBrand() { Brand= "Brown", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow},
                         new CustomerApplianceBrand() { Brand= "Caloric", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow},
                         new CustomerApplianceBrand() { Brand= "Chambers", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow},
                         new CustomerApplianceBrand() { Brand= "Dacor", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow},
                         new CustomerApplianceBrand() { Brand= "DCS", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow},
                         new CustomerApplianceBrand() { Brand= "Delonghi", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow},
                         new CustomerApplianceBrand() { Brand= "Dynasty", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow },
                         new CustomerApplianceBrand() { Brand= "Electrolux", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow },
                         new CustomerApplianceBrand() { Brand= "Frigidaire", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow },
                         new CustomerApplianceBrand() { Brand= "KitchenAid", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow },
                         new CustomerApplianceBrand() { Brand= "Samsung", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow },
                         new CustomerApplianceBrand() { Brand= "Viking", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow },
                         new CustomerApplianceBrand() { Brand= "Wold", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow },
                         new CustomerApplianceBrand() { Brand= "Zephyr", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow },
                         new CustomerApplianceBrand() { Brand= "Other", CreatedBy="SYSTEM", DateCreated=DateTime.UtcNow }
                     }
                };
                _tmContext.CustomerApplianceTypes.Add(customerApplianceType3);
                _tmContext.CustomerApplianceBrands.AddRange(customerApplianceType3.CustomerApplianceBrands);
                await _tmContext.SaveChangesAsync();
            }

            if (!_tmContext.Customers.Any())
            {
                var tcustomer = new Customer()
                {
                    DateCreated = DateTime.UtcNow,
                    FirstName = "Timur",
                    LastName = "Alayev",
                    Email = "tim@yahoo.com",
                    PhoneNumber = "7145293374",
                    CreatedBy = "tim@yahoo.com",
                    City = "La Habra",
                    PostalCode = "92788",
                    State = "CA",
                    Addess = "1241 Robin Way",

                    CustomerApplianceProblems = new List<CustomerApplianceProblem>()
                    {
                        new CustomerApplianceProblem() {
                            CustomerApplianceTypeId=1,
                            CustomerApplianceBrandId=1,
                            DateCreated=DateTime.UtcNow,
                            Problem="Gas leaking",
                            ModelNumber="123123123SDfR",
                            ModelSerial="sdfsldkjfSDF",
                            CreatedBy="SYSTEM",
                                CustomerApplianceProblemSchedules = new List<CustomerApplianceProblemSchedule>()
                                {
                                    new CustomerApplianceProblemSchedule() { DesiredScheduleTime=DateTime.UtcNow.AddDays(1), ActualScheduleTime=DateTime.UtcNow.AddDays(2), ScheduleCancelled=true },
                                    new CustomerApplianceProblemSchedule() { DesiredScheduleTime=DateTime.UtcNow.AddDays(2), ActualScheduleTime=DateTime.UtcNow.AddDays(2) }
                                },
                        },
                        new CustomerApplianceProblem() {
                            CustomerApplianceTypeId=2,
                            CustomerApplianceBrandId=3,
                            DateCreated=DateTime.UtcNow,
                            Problem="Water leaking",
                            ModelNumber="2344422333123SDfR",
                            ModelSerial="aaasddffSDF",
                            CreatedBy="SYSTEM",
                                CustomerApplianceProblemSchedules = new List<CustomerApplianceProblemSchedule>()
                                {
                                    new CustomerApplianceProblemSchedule() { DesiredScheduleTime=DateTime.UtcNow.AddDays(1), ActualScheduleTime=DateTime.UtcNow.AddDays(1)}
                                },
                        },
                        new CustomerApplianceProblem() {
                            CustomerApplianceTypeId=3,
                            CustomerApplianceBrandId=2,
                            DateCreated=DateTime.UtcNow,
                            Problem="Stop working",
                            ModelNumber="12asd3123SDfR",
                            ModelSerial="ddddddaaakjfSDF",
                            CreatedBy="SYSTEM",
                                CustomerApplianceProblemSchedules = new List<CustomerApplianceProblemSchedule>()
                                {
                                    new CustomerApplianceProblemSchedule() { DesiredScheduleTime=DateTime.UtcNow.AddDays(3), ActualScheduleTime=DateTime.UtcNow.AddDays(3)}
                                },
                        }
                    }
                };

                _tmContext.Customers.Add(tcustomer);
                _tmContext.CustomerApplianceProblems.AddRange(tcustomer.CustomerApplianceProblems);

                var acustomer = new Customer()
                {
                    DateCreated = DateTime.UtcNow,
                    FirstName = "Andrey",
                    LastName = "GoodEvening",
                    Email = "andrey@gmail.com",
                    PhoneNumber = "7143453374",
                    CreatedBy = "andrey@gmail.com",
                    City = "Garden Grove",
                    PostalCode = "93744",
                    State = "CA",
                    Addess = "14455 Yankee Way",

                    CustomerApplianceProblems = new List<CustomerApplianceProblem>()
                    {
                        new CustomerApplianceProblem() {
                            CustomerApplianceTypeId=1,
                            CustomerApplianceBrandId=1,
                            DateCreated=DateTime.UtcNow,
                            Problem="Terrible noise",
                            ModelNumber="123123123SDfR",
                            ModelSerial="sdfsldkjfSDF",
                            CreatedBy="SYSTEM",
                                CustomerApplianceProblemSchedules = new List<CustomerApplianceProblemSchedule>()
                                {
                                    new CustomerApplianceProblemSchedule() { DesiredScheduleTime=DateTime.UtcNow.AddDays(1), ActualScheduleTime=DateTime.UtcNow.AddDays(1)}
                                },
                        },
                        new CustomerApplianceProblem() {
                            CustomerApplianceTypeId=2,
                            CustomerApplianceBrandId=3,
                            DateCreated=DateTime.UtcNow,
                            Problem="No idea, need you to check",
                            ModelNumber="2344422333123SDfR",
                            ModelSerial="aaasddffSDF",
                            CreatedBy="SYSTEM",
                                CustomerApplianceProblemSchedules = new List<CustomerApplianceProblemSchedule>()
                                {
                                    new CustomerApplianceProblemSchedule() { DesiredScheduleTime=DateTime.UtcNow.AddDays(4), ActualScheduleTime=DateTime.UtcNow.AddDays(4)}
                                },
                        },
                        new CustomerApplianceProblem() {
                            CustomerApplianceTypeId=3,
                            CustomerApplianceBrandId=2,
                            DateCreated=DateTime.UtcNow,
                            Problem="Need to replace filter",
                            ModelNumber="12asd3123SDfR",
                            ModelSerial="ddddddaaakjfSDF",
                            CreatedBy="SYSTEM",
                                CustomerApplianceProblemSchedules = new List<CustomerApplianceProblemSchedule>()
                                {
                                    new CustomerApplianceProblemSchedule() { DesiredScheduleTime=DateTime.UtcNow.AddDays(1), ActualScheduleTime=DateTime.UtcNow.AddDays(2), ScheduleCancelled=true },
                                    new CustomerApplianceProblemSchedule() { DesiredScheduleTime=DateTime.UtcNow.AddDays(2), ActualScheduleTime=DateTime.UtcNow.AddDays(2) }
                                },
                        }
                    }
                };

                _tmContext.Customers.Add(acustomer);
                _tmContext.CustomerApplianceProblems.AddRange(acustomer.CustomerApplianceProblems);

                var bcustomer = new Customer()
                {
                    DateCreated = DateTime.UtcNow,
                    FirstName = "Michael",
                    LastName = "Smith",
                    Email = "msmith@yahoo.com",
                    PhoneNumber = "7145223374",
                    CreatedBy = "msmith@gmail.com",
                    City = "Fullerton",
                    PostalCode = "92783",
                    State = "CA",
                    Addess = "2344 Russki Way",

                    CustomerApplianceProblems = new List<CustomerApplianceProblem>()
                    {
                        new CustomerApplianceProblem() {
                            CustomerApplianceTypeId=1,
                            CustomerApplianceBrandId=1,
                            DateCreated=DateTime.UtcNow,
                            Problem="Terrible noise",
                            ModelNumber="asdg23SDfR",
                            ModelSerial="AAAAAfSDF",
                            CreatedBy="SYSTEM",
                                CustomerApplianceProblemSchedules = new List<CustomerApplianceProblemSchedule>()
                                {
                                    new CustomerApplianceProblemSchedule() { DesiredScheduleTime=DateTime.UtcNow.AddDays(1), ActualScheduleTime=DateTime.UtcNow.AddDays(2), ScheduleCancelled=true },
                                    new CustomerApplianceProblemSchedule() { DesiredScheduleTime=DateTime.UtcNow.AddDays(2), ActualScheduleTime=DateTime.UtcNow.AddDays(2) }
                                },
                        },
                        new CustomerApplianceProblem() {
                            CustomerApplianceTypeId=2,
                            CustomerApplianceBrandId=3,
                            DateCreated=DateTime.UtcNow,
                            Problem="Water leaking",
                            ModelNumber="RRRRRRR123SDfR",
                            ModelSerial="EEEEEEEdffSDF",
                            CreatedBy="SYSTEM",
                                CustomerApplianceProblemSchedules = new List<CustomerApplianceProblemSchedule>()
                                {
                                    new CustomerApplianceProblemSchedule() { DesiredScheduleTime=DateTime.UtcNow.AddDays(1), ActualScheduleTime=DateTime.UtcNow.AddDays(1)}
                                },
                        },
                        new CustomerApplianceProblem() {
                            CustomerApplianceTypeId=3,
                            CustomerApplianceBrandId=2,
                            DateCreated=DateTime.UtcNow,
                            Problem="Shaking",
                            ModelNumber="EERRTTYYYY3SDfR",
                            ModelSerial="WERRTYakjfSDF",
                            CreatedBy="SYSTEM",
                                CustomerApplianceProblemSchedules = new List<CustomerApplianceProblemSchedule>()
                                {
                                    new CustomerApplianceProblemSchedule() { DesiredScheduleTime=DateTime.UtcNow.AddDays(3), ActualScheduleTime=DateTime.UtcNow.AddDays(3)}
                                },
                        }
                    }
                };

                _tmContext.Customers.Add(bcustomer);
                _tmContext.CustomerApplianceProblems.AddRange(bcustomer.CustomerApplianceProblems);

                await _tmContext.SaveChangesAsync();

            }
        }
    }
}
