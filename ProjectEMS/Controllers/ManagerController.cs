using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Common.Enums;
using ProjectEMS.BAL.Interface;
using ProjectEMS.DL;
using ProjectEMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEMS.Controllers
{
    public class ManagerController : Controller
    {
        private readonly IEmployees _Db;
        private readonly IProject _PDb;
        public ManagerController(IEmployees Db, IProject PDb)
        {
            _Db = Db;
            _PDb = PDb;

        }
       
        [HttpGet]
        public IActionResult EmployeesList()
        {
            try
            {
                var id = (int)HttpContext.Session.GetInt32("id");
                var emplist = _Db.GetEmployeeUnderManager(id);

                return View(emplist);
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult projectList()
        {
            
            
                var projlist = _PDb.GetAllProjectDetails();
                return View(projlist);
           
        }
        /*
        [HttpGet]
        public IActionResult Details(int id)
        {
            var project = _PDb.GetProjectDetailsByID(id);
            return View(project);
        }
        */
        // GET: ManagerController/Create
        [HttpGet]
        public IActionResult create(ProjectRequestModel obj)       //for create new user 
        {

            return View(obj);
         
        }
        [HttpPost]
       
        public IActionResult Create(ProjectRequestModel projectRequestModel)
        {
            if (ModelState.IsValid)
            {
                var isCreated = _PDb.InsertProjectDetails(projectRequestModel);
                return RedirectToAction("ProjectList");
            }
            return View(projectRequestModel);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var project = _PDb.GetProjectDetailsByID(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }
        [HttpPost]
        
        public IActionResult Edit(ProjectResponseModel projectRequestmodel)
        {

            if (ModelState.IsValid)
            {
                
                var isUpdated = _PDb.UpdateProjectDetails(projectRequestmodel);
                return RedirectToAction(nameof(projectList));
            }
            return View(_Db);
        }
        [HttpGet]
        public IActionResult DeleteProject(int id)
        {
            var project = _PDb.GetProjectDetailsByID(id);

            
                if (_PDb == null)
                {
                    return NotFound();
                }

                return View(project);
            
            }
       


        [HttpPost, ActionName("DeleteProject")]
        
        public IActionResult DeleteConfirmed(int id)
        {
            var deleteProject = _PDb.DeleteProjectDetails(id);
            return RedirectToAction(nameof(projectList));
        }
        
        [HttpGet]
        public IActionResult projectgiven(Emp_projRequestModel emp_ProjRequestModel)
        {
            List<SelectListItem> projectlists = new List<SelectListItem>();

            foreach (var projectlist in _PDb.GetAllProjectDetails())
            {
                projectlists.Add(new SelectListItem()
                {
                    Value = projectlist.P_id.ToString(),
                    Text = projectlist.Pname
                });
            }
            ViewBag.listproject = projectlists;

            
            List<SelectListItem> employeelists = new List<SelectListItem>();
            foreach (var employeelist in _Db.GetAllEmployeeDetails())
            {
                if (employeelist.Role == RoleEnum.Employee)
                {
                    employeelists.Add(new SelectListItem()
                    {
                        Value = employeelist.E_id.ToString(),
                        Text = employeelist.Fname
                    });
                }
                
            }
            ViewBag.listemployees = employeelists;

            return View(emp_ProjRequestModel);
        }
         [HttpPost]
         public IActionResult ProjectGiven(Emp_projRequestModel emp_ProjRequestModel)
        {
            if (ModelState.IsValid)
            {
                var project = _PDb.InsertEmp_projDetails(emp_ProjRequestModel);
                return RedirectToAction("projectList");
            }
            return View(emp_ProjRequestModel);
        }

    }
}
