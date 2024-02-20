using ProjectEMS.BAL.Interface;
using ProjectEMS.DAL.Interface;
using ProjectEMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEMS.BAL.Implementation
{
    public class EmployeesBO : IEmployees
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeesBO(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        
        public LoginResponseModel Authenticate(string username, string password)
        {
            var login = employeeRepository.Authenticate(username,password);
            return login;

        }


        public int DeleteEmployeeDetails(int id)
        {
            var ReturnVal = employeeRepository.DeleteEmployeeDetails(id);
            return ReturnVal;
        }

        public List<EmployeeResponseModel> GetAllEmployeeDetails()
        {
            var employees = employeeRepository.GetAllEmployeeDetails();
            return employees;
        }

      

        public EmployeeResponseModel GetEmployeeDetailsByID(int id)
        {
            var employee = employeeRepository.GetEmployeeDetailsByID(id);
            return employee;
        }
        public List<EmployeeResponseModel> GetManagerwithEmployeesDetails()
        {
            var mlist = employeeRepository.GetManagerwithEmployeesDetails();
            return mlist;
        }
        public List<EmployeeResponseModel> GetEmployeeUnderManager(int id)
        {
            var employee = employeeRepository.GetEmployeeUnderManager(id);
            return employee;
        }

        public int InsertEmployeeDetails(EmployeeRequestModel employeeRequestModel)
        {
            var isInserted = employeeRepository.InsertEmployeeDetails(employeeRequestModel);
            return isInserted;
        }
        
        public int InsertEmp_managerDetails(Emp_ManagerRequestModel emp_ManagerRequestModel)
        {
            var isInserted = employeeRepository.InsertEmp_managerDetails(emp_ManagerRequestModel);
            return isInserted;
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public int UpdateEmployeeDetails(EmployeeResponseModel employeeRequestModel)
        {
            var isUpdated = employeeRepository.UpdateEmployeeDetails(employeeRequestModel);
            return isUpdated;
        }
    }
}
