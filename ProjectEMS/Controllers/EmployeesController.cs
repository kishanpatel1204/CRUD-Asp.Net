using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectEMS.BAL.Interface;
using ProjectEMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEMS.Controllers
{
    
    public class EmployeesController : Controller
    {
        private readonly IEmployees _Db;
        private readonly IProject _PDb;
        public EmployeesController(IEmployees Db,IProject PDb)
        {
            _Db = Db;
            _PDb = PDb;
        }
        
       [HttpGet]
        public IActionResult index()
        {
            var id =(int)HttpContext.Session.GetInt32("id");
            var final = _Db.GetEmployeeDetailsByID(id);
            return View(final);
        }
      

    }
}
