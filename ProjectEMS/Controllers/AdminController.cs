using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Common.Enums;
using ProjectEMS.BAL.Interface;
using ProjectEMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProjectEMS.Controllers
{
    
    public class AdminController : Controller
    {
        private readonly IEmployees _Db;
        public AdminController(IEmployees Db)
        {
            _Db = Db;
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Login");
        }
        [HttpGet]
        public IActionResult EmployeesList()
        {
            try
            {
                var emplist = _Db.GetAllEmployeeDetails();
                return View(emplist);
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult EmployeesListForManager(int id)
        {
            var emplist = _Db.GetEmployeeUnderManager(id);
            return View(emplist);
        }  
        [HttpGet]
        public IActionResult ManagerList()
        {
            var managerlist = _Db.GetManagerwithEmployeesDetails();
                return View(managerlist);
        }
        /*
        [HttpGet]
        public IActionResult Details(int id)
        {
            var empdetails = _Db.GetEmployeeDetailsByID(id);
            return View(empdetails);
        }
        */
        [HttpGet]
        public IActionResult Create(EmployeeRequestModel obj)       //for create new user 
        {
           
            return View(obj);
            //_Db.Employees.Add(obj);
            //_Db.SaveChanges();
            //return RedirectToAction("EmployeesList");
        }

        [HttpPost]
        
        public IActionResult AddEmplyoees(EmployeeRequestModel employeRequestModel)
        {

            if (ModelState.IsValid)
            {
                var isCreated = _Db.InsertEmployeeDetails(employeRequestModel);
                return RedirectToAction("EmployeesList");
            }
            return View(employeRequestModel);
        }
        [HttpGet]
        public IActionResult addmanager(Emp_ManagerRequestModel objem)
        {
            List<SelectListItem> managerlists = new List<SelectListItem>();
            List<SelectListItem> emplists = new List<SelectListItem>();
            
            foreach (var namelist in _Db.GetAllEmployeeDetails())
            {
                if(namelist.Role==RoleEnum.Manager)
                {
                    managerlists.Add(new SelectListItem()
                {
                    Value = namelist.E_id.ToString(),
                    Text = namelist.Fname
                });
                }
                else if (namelist.Role == RoleEnum.Employee)
                {
                    emplists.Add(new SelectListItem()
                    {
                        Value = namelist.E_id.ToString(),
                        Text = namelist.Fname
                    });
                }
            }
            ViewBag.listemployee = emplists;
            ViewBag.listmanager = managerlists;
            
            return View(objem);
        }
        [HttpPost]
        public IActionResult AddManager(Emp_ManagerRequestModel emp_ManagerRequestModel)
        {
            
            if (ModelState.IsValid)
            {
                var addmanager = _Db.InsertEmp_managerDetails(emp_ManagerRequestModel);
                return RedirectToAction("EmployeesList");
            }
            return View(emp_ManagerRequestModel);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

            var employee = _Db.GetEmployeeDetailsByID(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpPost]
       
        public IActionResult Edit(EmployeeResponseModel employeRequestModel)
        {

            if (ModelState.IsValid)
            {
                var isUpdated = _Db.UpdateEmployeeDetails(employeRequestModel);
                return RedirectToAction(nameof(EmployeesList));
            }
            return View(_Db);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = _Db.GetEmployeeDetailsByID(id);
            
            if (_Db == null)
            {
                return NotFound();
            }
             return View(employee);
        }

       
        [HttpPost,ActionName("Delete")]
        
        public IActionResult DeleteConfirmed(int id)
        {
            var deleteEmployee = _Db.DeleteEmployeeDetails(id);
            return RedirectToAction(nameof(EmployeesList));
        }

        
       
      
    }
 }

