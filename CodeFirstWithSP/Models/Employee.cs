using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstWithSP.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please Enter Name")]
        public string Name { get; set; }    

        [Required(ErrorMessage ="Please Enter City")]
        public string  City { get; set; }    

        [Required(ErrorMessage = "Please Select Department")]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        //if u will not use virtual here then u will not get the details of employee using wher and firstofdefault
    }
}