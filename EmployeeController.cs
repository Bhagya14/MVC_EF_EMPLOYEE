using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_EF_employee.Models;

namespace MVC_EF_employee.Controllers
{
    public class EmployeeController : Controller
    {
        Mydbcontext db = new Mydbcontext();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
               
                var count = db.Employees.Count(c => c.employeeid == model.loginid && c.employeepassword == model.Password);
                if (count > 0)
                {
                    Session["loginid"] = model.loginid;
                    return RedirectToAction("search", "Employee");
                }
                else
                {
                    ViewBag.msg = "Invalid ID or Password";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(EmployeeModel model)
        {
            db.Employees.Add(model);
            db.SaveChanges();//will update database
            ViewBag.msg = "Employee Added:" + model.employeeid;
            return View();
        }

        public ActionResult Search()
        {
            List<EmployeeModel> list = new List<EmployeeModel>();
            return View(list);
        }
        [HttpPost]
        public ActionResult Search(string key)
        {
           

            var data = db.Employees.Where(c => c.employeeid.ToString().Contains(key)
                                          || c.employeename.Contains(key)
                                          || c.employeecity.Contains(key)).ToList();
            return View(data);

        }
        public ActionResult Find(int id)
        {
          
            var model = db.Employees.FirstOrDefault(c => c.employeeid == id);
            return View(model);
        }
        public ActionResult Delete(int id)
        {
           
            var model = db.Employees.FirstOrDefault(c => c.employeeid == id);
            db.Employees.Remove(model);
            db.SaveChanges();
            return View("v_employeedeleted");
        }
        public ActionResult Edit(int id)
        {
            
            var model = db.Employees.FirstOrDefault(c => c.employeeid == id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(EmployeeModel model)
        {
            
            var dbmodel = db.Employees.FirstOrDefault(c => c.employeeid == model.employeeid);
            dbmodel.employeecity = model.employeecity;
            dbmodel.employeepassword = model.employeepassword;
            db.SaveChanges();
            return View("v_Updated");
        }
    }
}