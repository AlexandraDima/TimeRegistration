using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TimeRegistration.Models;

namespace TimeRegistration.DAL
{
    public class TimeRegistrationInitializer: System.Data.Entity.DropCreateDatabaseIfModelChanges<TimeRegistrationContext>
    {
        protected override void Seed(TimeRegistrationContext context)
        {
            //List of projects
            var projects = new List<Project>
            {
            new Project{ProjectName="Umbraco",ProjectDescription="This project uses Umbraco integration",ProjectImage="~/Content/Images/Project1.svg", StartingDate=DateTime.Parse("2019-09-01"),EndingDate=DateTime.Parse("2019-12-01")},
            new Project{ProjectName="Drupal",ProjectDescription="This project uses Drupal integration",ProjectImage="~/Content/Images/Project1.svg",StartingDate=DateTime.Parse("2019-09-01"),EndingDate=DateTime.Parse("2019-12-01")},
            new Project{ProjectName="SharePoint",ProjectDescription="This project uses SharePoint integration",ProjectImage="~/Content/Images/Project1.svg", StartingDate=DateTime.Parse("2019-09-01"),EndingDate=DateTime.Parse("2019-12-01")},
            new Project{ProjectName="Ghost",ProjectDescription="This project uses Ghost integration",ProjectImage="~/Content/Images/Project1.svg",StartingDate=DateTime.Parse("2019-09-01"),EndingDate=DateTime.Parse("2019-12-01")}
            };
            projects.ForEach(s => context.Projects.Add(s));
            context.SaveChanges();

            //List of Employees
            var employees = new List<Employee>
            {
            new Employee{FirstName="Alexandra",LastName="Dima"},
            new Employee{FirstName="John",LastName="Mayer"},
            };
            employees.ForEach(s => context.Employees.Add(s));
            context.SaveChanges();

            //List of Hours
       
            var hours = new List<Hour>
            {
            new Hour{ProjectID=1,EmployeeID=1,DateRegistration=DateTime.Parse("2019-09-01"), StartingHour=DateTime.Parse("05:21:50", null), EndingHour=DateTime.Parse("16:21:50", null)},
            new Hour{ProjectID=2,EmployeeID=1,DateRegistration=DateTime.Parse("2019-09-01"), StartingHour=DateTime.Parse("05:21:50", null), EndingHour=DateTime.Parse("16:21:50", null)},
             new Hour{ProjectID=1,EmployeeID=2,DateRegistration=DateTime.Parse("2019-09-01"), StartingHour=DateTime.Parse("05:21:50", null), EndingHour=DateTime.Parse("16:21:50", null)},
            };
            hours.ForEach(s => context.Hours.Add(s));
            context.SaveChanges();
        }
    }
}