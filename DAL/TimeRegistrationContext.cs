using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeRegistration.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TimeRegistration.DAL
{
    public class TimeRegistrationContext:DbContext
    {
        public TimeRegistrationContext() : base("TimeRegistrationContext")
        {
            //Disable Lazy-Loading will help us accessing the Json data
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Hour> Hours { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

       
    }
}