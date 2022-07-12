using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CodeFirstWithSP.Models;

namespace CodeFirstWithSP.Controllers
{
    public class EmployeeController : Controller
    {
        AppContext context = new AppContext();
        // GET: Employee
        public ActionResult Index()
        {
            //var employees = context.Employees.Include(x => x.Department).ToList();

            //This procedure will not compatable with existing Employee model you have create another Employee model 
            //for remove dependency
            //var employees=context.Employees.SqlQuery("Exec USP_GetEmployees");
            //or
            var employees = context.Employees.SqlQuery("Select * from Employees");
            return View(employees);
        }

        public ActionResult Create(bool isSuccess = false)
        {
            ViewBag.Message = isSuccess;
            ViewBag.DepartmentList = context.Departments.ToList();
            return View();
        }
        
        [HttpPost]
        public ActionResult AddEmployee(Employee emp)
        {
            if(ModelState.IsValid)
            {
                //context.Employees.SqlQuery("Exec USP_AddEmployee"); //this code also not work with existing employee model
                context.Employees.Add(emp);
                context.SaveChanges();
                //TempData["EmployeeMessage"] = "Employee Added Successfully";
                ModelState.Clear();
                return RedirectToAction("Create", new { isSuccess = true });
            }
            return View("Create");  
        }

        public ActionResult Edit(int id)
        {
			//var employee= _context.Students.SqlQuery("Exec Get_Employee @id", new SqlParameter("@id", Id)).FirstOrDefault();
            var employee = context.Employees.Where(x => x.Id == id).FirstOrDefault();
            ViewBag.DepartmentList = context.Departments.ToList();
            return View(employee);
        }

        public ActionResult Update(Employee emp)
        {
            if (ModelState.IsValid)
            {
                var employee = context.Employees.Where(x => x.Id == emp.Id).FirstOrDefault();
                employee.Name = emp.Name;
                employee.City = emp.City;
                employee.DepartmentId = emp.DepartmentId;
                context.SaveChanges();
                //TempData["EmployeeMessage"] = "Employee Added Successfully";
                return RedirectToAction("Index");
            }
            return View("Edit");
        }

        public ActionResult Details(int id)
        {
            Employee employee = context.Employees.Where(x=>x.Id==id).FirstOrDefault();
            return View(employee);
        }

        public ActionResult DeleteEmployee(int id)
        {
            var employee = context.Employees.Where(x => x.Id == id).FirstOrDefault();
            context.Employees.Remove(employee);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}




