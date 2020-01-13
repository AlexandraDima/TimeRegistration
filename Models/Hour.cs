using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeRegistration.Models
{
    public class Hour
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime DateRegistration { get; set; }
        public DateTime StartingHour { get; set; }
        public DateTime EndingHour { get; set; }

        public virtual Project Projects { get; set; }
        public virtual Employee Employees { get; set; }
    }
}