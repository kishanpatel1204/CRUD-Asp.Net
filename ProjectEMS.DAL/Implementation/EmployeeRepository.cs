using Project.Common.Enums;
using ProjectEMS.DAL.Interface;
using ProjectEMS.DL;
using ProjectEMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEMS.DAL.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly RiseProjectContext _Db;
        public EmployeeRepository(RiseProjectContext Db)
        {
            _Db = Db;
        }



        public int DeleteEmployeeDetails(int id)
        {
            EmployeesTable employees = new EmployeesTable();

            var EMPM= _Db.EmployeeManagerTable.ToList();
            var EMPM2 = _Db.EmpProjTable.ToList();
            
            foreach(var emp in EMPM)
            {
                foreach(var proj in EMPM2)
                {
                    if (proj.EId == id)
                    {
                        _Db.EmpProjTable.Remove(proj);
                    }
                }

                if (emp.EId == id || emp.MId == id)
                {
                _Db.EmployeeManagerTable.Remove(emp);

                }
            }
                 employees.EId = id; 
                 _Db.EmployeesTable.Remove(employees);
                 var isDeleted = _Db.SaveChanges();
                 return isDeleted;
        }
        

        public List<EmployeeResponseModel> GetAllEmployeeDetails()
        {
            var employees = _Db.EmployeesTable.ToList();
            List<EmployeeResponseModel> employeeResponseModels = new List<EmployeeResponseModel>();
            foreach (var employee in employees)
            {
                EmployeeResponseModel empResponseModel = new EmployeeResponseModel();
                empResponseModel.E_id = employee.EId;
                empResponseModel.Fname = employee.Fname;
                empResponseModel.Lname = employee.Lname;
                empResponseModel.Email = employee.Email;
                empResponseModel.City = (CityEnum)employee.City;
                empResponseModel.Department = (DepartmentEnum)employee.Department;
                empResponseModel.Role = (RoleEnum)employee.Role;
                empResponseModel.MobileNo = employee.MobileNo;
                empResponseModel.JoiningDate = employee.JoinningDate;
                empResponseModel.Status = (StatusEnum)employee.Status;
                empResponseModel.Password = employee.Password;

                employeeResponseModels.Add(empResponseModel);
            }
            return employeeResponseModels;
        }
        public List<EmployeeResponseModel> GetManagerwithEmployeesDetails()
        {
            var managerlist = _Db.EmployeesTable.Where(x => x.Role == 2).Select(y => y.EId).ToList();

            List<EmployeeResponseModel> employeeResponseModels = new List<EmployeeResponseModel>();
            foreach (var x in managerlist)
            {
                //var kl = _Db.EmployeeManagerTable.Where(y => y.MId == x).Select(p => p.EId).ToList();
                //List<Emp_ManageResponseModel> emp_ManageResponseModels = new List<Emp_ManageResponseModel>();
                //foreach(var t in kl)
                //{
                //    EmployeeResponseModel employeeResponseModell = new EmployeeResponseModel();
                //    employeeResponseModell = GetEmployeeDetailsByID((int)t);
                //    employeeResponseModels.Add(employeeResponseModell);
                //}
                EmployeeResponseModel employeeResponseModel = new EmployeeResponseModel();
               
                employeeResponseModel = GetEmployeeDetailsByID((int)x);
                employeeResponseModels.Add(employeeResponseModel);
            }
            return employeeResponseModels;

            //    var employee = _Db.EmployeeManagerTable.Where(x => x.MId ==2).Select(y => y.EId).ToList();
          
            //List<EmployeeResponseModel> employeeResponseModels = new List<EmployeeResponseModel>();
        }
      public List<EmployeeResponseModel> GetEmployeeUnderManager(int id)
        {
            var employee = _Db.EmployeeManagerTable.Where(x => x.MId == id).Select(y => y.EId).ToList();
            List<EmployeeResponseModel> employeeResponseModels = new List<EmployeeResponseModel>();
            foreach (var x in employee)
            {
                EmployeeResponseModel employeeResponseModel = new EmployeeResponseModel();
                employeeResponseModel = GetEmployeeDetailsByID((int)x);
                employeeResponseModels.Add(employeeResponseModel);
            }
            return employeeResponseModels;
        }
        
        public EmployeeResponseModel GetEmployeeDetailsByID(int id)
        {
            EmployeeResponseModel empResponseModel = new EmployeeResponseModel();

            var employee = _Db.EmployeesTable.Where(x => x.EId == id).FirstOrDefault();
          
            empResponseModel.E_id = employee.EId;
            empResponseModel.Fname = employee.Fname;
            empResponseModel.Lname = employee.Lname;
            empResponseModel.Email = employee.Email;
            empResponseModel.City = (CityEnum)employee.City;
            empResponseModel.Department = (DepartmentEnum)employee.Department;
            empResponseModel.Role = (RoleEnum)employee.Role;
            empResponseModel.MobileNo = employee.MobileNo;
            empResponseModel.JoiningDate = employee.JoinningDate;
            empResponseModel.Status = (StatusEnum)employee.Status;
            empResponseModel.Password = employee.Password;

            return empResponseModel;
        }
       

        public LoginResponseModel Authenticate(string username , string passsword)
        {
           

            var login = _Db.EmployeesTable.Where(x => x.Email == username && x.Password == passsword).Select(y => new LoginResponseModel{E_id=y.EId,Role=y.Role }).FirstOrDefault();
               
            return login;
        }
       
        public int InsertEmployeeDetails(EmployeeRequestModel emp_RequestModel)
        {
            EmployeesTable employees = new EmployeesTable();
            //employees.EId = emp_RequestModel.E_id;
            employees.Fname = emp_RequestModel.Fname;
            employees.Lname = emp_RequestModel.Lname;
            employees.Email = emp_RequestModel.Email;
            employees.City = (int)emp_RequestModel.City;
            employees.Department = (int)emp_RequestModel.Department;
            employees.Role = (int)emp_RequestModel.Role;
            employees.MobileNo = emp_RequestModel.MobileNo;
            employees.JoinningDate = emp_RequestModel.JoiningDate;
            employees.Status = (int)emp_RequestModel.Status;
            employees.Password = emp_RequestModel.Password;

            _Db.EmployeesTable.Add(employees);
            var isIntesrted = _Db.SaveChanges();

            return isIntesrted;

        }


        public int InsertEmp_managerDetails(Emp_ManagerRequestModel emp_ManagerRequestModel)
        {
            EmployeeManagerTable empmanger = new EmployeeManagerTable();

            //var managerid = _Db.EmployeesTable.Where(x => x.Role == id).FirstOrDefault();
            //var employeeid = _Db.EmployeesTable.Where(y => y.Role == idd).FirstOrDefault();
            empmanger.MId = emp_ManagerRequestModel.M_id;
            empmanger.EId = emp_ManagerRequestModel.E_id;        
            _Db.EmployeeManagerTable.Add(empmanger);
            var isInsert = _Db.SaveChanges();
            return isInsert;

        }

        public int UpdateEmployeeDetails(EmployeeResponseModel emp_RequestModel)
        {
            EmployeesTable employees = new EmployeesTable();

            employees.EId = emp_RequestModel.E_id;
            employees.Fname = emp_RequestModel.Fname;
            employees.Lname = emp_RequestModel.Lname;
            employees.Email = emp_RequestModel.Email;
            employees.City = (int)emp_RequestModel.City;
            employees.Department = (int)emp_RequestModel.Department;
            employees.Role = (int)emp_RequestModel.Role;
            employees.MobileNo = emp_RequestModel.MobileNo;
            employees.JoinningDate = emp_RequestModel.JoiningDate;
            employees.Status = (int)emp_RequestModel.Status;
            employees.Password = emp_RequestModel.Password;


            _Db.EmployeesTable.Attach(employees);
            _Db.EmployeesTable.Update(employees);
            var isUpdated = _Db.SaveChanges();

            return isUpdated;
        }

      
    } 
}


