using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeRegistration.Models
{
    public class Project
    {
        public int ID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }

        public string ProjectImage { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }

        public virtual ICollection<Hour> Hours { get; set; }
        public List<Project> Projects { get; internal set; }
    }
}