using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectEMS.BAL.Interface;
using ProjectEMS.DL;
using ProjectEMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEMS.Controllers
{
    
    public class LoginController : Controller
    {
        private readonly IEmployees _Db;
        public LoginController(IEmployees Db)
        {
            _Db = Db;
        }
        public IActionResult LogIn()
        {
            LoginRequestModel objlogin = new LoginRequestModel();

            return View(objlogin);
        }

        [HttpPost]
        public IActionResult LogIn(LoginRequestModel loginRequestModel)
        {
            var username = loginRequestModel.Email;
            var password = loginRequestModel.Password;
            var log = _Db.Authenticate(username, password);
            if (log.Role == 1)                                   
            {
                HttpContext.Session.SetInt32("id", log.E_id);
                return RedirectToAction("EmployeesList", "Admin");
            }
            if (log.Role == 2)
            {
                HttpContext.Session.SetInt32("id", log.E_id);
                return RedirectToAction("EmployeesList", "Manager");
            }
            if (log.Role == 3)
            {
                HttpContext.Session.SetInt32("id", log.E_id);
                return RedirectToAction("index", "Employees");
               
            }
            return View();
        }
    }

}
