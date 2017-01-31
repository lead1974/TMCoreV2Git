using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TMCoreV2.ViewModels;
using TMCoreV2.DataAccess.Models.User;
using TMCoreV2.DataAccess.Models.Customer;
using TMCoreV2.DataAccess.Models.Customer;

namespace TMCoreV2.DataAccess
{
    public class TMDbContext : IdentityDbContext<AuthUser,AuthRole,string>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerApplianceProblem> CustomerApplianceProblems { get; set; }
        public DbSet<CustomerApplianceType> CustomerApplianceTypes { get; set; }
        public DbSet<CustomerApplianceBrand> CustomerApplianceBrands { get; set; }
        public DbSet<CustomerApplianceProblemSchedule> CustomerApplianceProblemSchedules { get; set; }

        public TMDbContext(DbContextOptions<TMDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //To navigate, use a Select:
            // person.Photos
            //var tags = post.PostTags.Select(c => c.Tag);
            //builder.Entity<BlogPostTag>().HasKey(x => new { x.PostId, x.TagId });

            //builder.Entity<CustomerSchedule>()
            //    .HasOne(c => c.Customer)
            //    .WithOne()
            //    .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Cascade);

            //builder.Entity<CustomerApplianceProblem>()
            //  .HasOne(c => c.Customer)
            //  .WithOne()
            //  .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Cascade);

            //builder.Entity<CustomerApplianceProblem>()
            //   .HasOne(c => c.customerApplianceType)
            //   .WithOne()
            //   .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict);

            //builder.Entity<CustomerApplianceProblem>()
            //   .HasOne(c => c.customerApplianceBrand)
            //   .WithOne()
            //   .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
