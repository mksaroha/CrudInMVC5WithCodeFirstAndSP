using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CodeFirstWithSP.Models
{
    public class AppContext:DbContext
    {
        public AppContext():base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Single Entity like Student
            // modelBuilder.Entity<Student>().MapToStoredProcedures();
            //MultipleEntity like Student,Course etc...
            modelBuilder.Types().Configure(t => t.MapToStoredProcedures());
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}