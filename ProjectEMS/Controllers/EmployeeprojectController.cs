using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectEMS.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEMS.Controllers
{
    
    public class EmployeeprojectController : Controller
    {
        private RiseProjectContext db = new RiseProjectContext();
        public IActionResult Index()
        {
            var empproj = db.EmpProjTable.Include(e => e.E).Include(e => e.P);
            return View(empproj.ToList());
        }
        public IActionResult Details(int? id)
        {
            EmpProjTable empProjTable = db.EmpProjTable.Find(id);
            if (empProjTable == null)
            {
                return View("");
            }
            return View(empProjTable);


        }
        public IActionResult Create()
        {
            ViewBag.EId = new SelectList(db.EmployeesTable, "EId", "Fname");
            ViewBag.PId = new SelectList(db.ProjectTable, "PId", "Pname");
            return View();
        }
    }
}
