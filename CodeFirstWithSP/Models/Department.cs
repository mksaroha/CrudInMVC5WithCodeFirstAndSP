using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirstWithSP.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
    }