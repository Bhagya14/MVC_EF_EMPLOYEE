using MVC_EF_employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_EF_employee.Controllers
{
    public class LeavesController : Controller
    {
        Mydbcontext db = new Mydbcontext();
        public ActionResult AddLeave()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddLeave(EmployeeLeaves model)
        {
            db.EmployeeLeaves.Add(model);
            db.SaveChanges();
            ViewBag.msg = "Leave Added:" + model.employeeid;
            return View();
        }
        public ActionResult Show()
        {
            List<EmployeeLeaves> list = new List<EmployeeLeaves>();
            return View(list);
        }
        [HttpPost]
        public ActionResult Show(string key)
        {
            var data = db.EmployeeLeaves.Where(c => c.employeeid.ToString().Contains(key)
                                          || c.leavetype.Contains(key)).ToList();
            return View(data);

        }
    }
}