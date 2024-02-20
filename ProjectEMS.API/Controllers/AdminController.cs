using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectEMS.BAL.Interface;
using ProjectEMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEMS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly IEmployees _employees;
        private readonly IProject _PDb;

        public AdminController(IEmployees employees, IProject PDb)
        {
            this._employees = employees;
            this._PDb = PDb;
        }
        [HttpGet]
        [Route("GetAllEmployees")]
        public IActionResult Get()
        {
            try
            {
                var empdata = _employees.GetAllEmployeeDetails();
                return Ok(empdata);

            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal Server Error"); 
            }
        }
        [HttpGet]
        [Route("Manageremployeelistapi")]
        public IActionResult EmployeesList()
        {
            try
            {
                var id = (int)HttpContext.Session.GetInt32("id");
                var emplist = _employees.GetEmployeeUnderManager(id);

                return View(emplist);
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        [HttpGet]
        [Route("Projectapi")]
        public IActionResult projectList()
        {
            var projlist = _PDb.GetAllProjectDetails();
            return Ok(projlist);

        }
        [HttpGet]
        [Route("GetEmployeesById/{e_id}")]
        public IActionResult GetById(string e_id)
        {
            try
            {
                int id = Convert.ToInt32(e_id);
                var employeedata = _employees.GetEmployeeDetailsByID(id);
                return Ok(employeedata);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpPost]
        [Route("InsertEmployee")]
        public IActionResult InsertEmployee(EmployeeRequestModel employeeRequestModel)
        {
            try
            {
                var employeedata = _employees.InsertEmployeeDetails(employeeRequestModel);
                return Ok(employeedata);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpPost]
        [Route("Addmanagerapi")]
        public IActionResult AddManager(Emp_ManagerRequestModel emp_ManagerRequestModel)
        {

            try
            {
                var addmanager = _employees.InsertEmp_managerDetails(emp_ManagerRequestModel);
                return Ok(addmanager);
            }
            catch (Exception ex) {
                return StatusCode(500, "Internal Server Error");
            } 
        }
        [HttpPost]
        [Route("Insertprojectapi")]
        public IActionResult Create(ProjectRequestModel projectRequestModel)
        {
            
                var isCreated = _PDb.InsertProjectDetails(projectRequestModel);
                return Ok(isCreated);          
            
        }
        [HttpGet]
        [Route("Geteditapi")]
        public IActionResult Edit(int id)
        {

            var employee = _employees.GetEmployeeDetailsByID(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPut]
        [Route("Editapi")]
        public IActionResult Edit(EmployeeResponseModel employeRequestModel)
        {

            if (ModelState.IsValid)
            {
                var isUpdated = _employees.UpdateEmployeeDetails(employeRequestModel);
                return Ok();
            }
            return Ok(_employees);
        }
        [HttpPut]
        [Route("Editprojectapi")]
        public IActionResult Edit(ProjectResponseModel projectRequestmodel)
        {

            if (ModelState.IsValid)
            {

                var isUpdated = _PDb.UpdateProjectDetails(projectRequestmodel);
                return Ok(isUpdated);
            }
            return Ok();
        }
        [HttpDelete]
        [Route("Deleteapi")]
        public IActionResult DeleteConfirmed(int id)
        {
            var deleteEmployee = _employees.DeleteEmployeeDetails(id);
            return Ok();
        }
        [HttpDelete]
        [Route("Deleteprojectapi")]
        public IActionResult DeleteProject(int id)
        {
            var deleteProject = _PDb.DeleteProjectDetails(id);
            return Ok();
        }

        [HttpPost]
        [Route("Projectgivenapi")]
        public IActionResult ProjectGiven(Emp_projRequestModel emp_ProjRequestModel)
        {
            if (ModelState.IsValid)
            {
                var project = _PDb.InsertEmp_projDetails(emp_ProjRequestModel);
                return Ok(project);
            }
            return Ok(emp_ProjRequestModel);
        }


    }
}
