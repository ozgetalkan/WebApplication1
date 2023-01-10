using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View(Repository.AllEmpoyees);
        }

        // HTTP GET VERSION
        public IActionResult Create()
        {
            return View();
        }

        // HTTP POST VERSION  
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Repository.Create(employee);
            return View("Thanks", employee);
            }
            else
                return View();
        }
        public IActionResult Update(string empname)
        {
            Employee employee = Repository.AllEmpoyees.Where(e => e.Name == empname).FirstOrDefault();
            return View(employee);
        }
        [HttpPost]
        public IActionResult Update(Employee employee, string empname)
        {
            if (ModelState.IsValid)
            {
            Employee e = Repository.AllEmpoyees.FirstOrDefault(b =>b.Name == empname);
            e.Age = employee.Age;
            e.Salary = employee.Salary;
            e.Department = employee.Department;
            e.Sex = employee.Sex;
            e.Name = employee.Name;

            return RedirectToAction("Index");
            }
            else
                return View();
        }
        [HttpPost]
        public IActionResult Delete(string empname)
        {
            Employee employee = Repository.AllEmpoyees.Where(e => e.Name == empname).FirstOrDefault();
            Repository.Delete(employee);
            return RedirectToAction("Index");
        }
    }
}
