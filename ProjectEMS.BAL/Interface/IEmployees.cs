using ProjectEMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEMS.BAL.Interface
{
    public interface IEmployees
    {
        int InsertEmployeeDetails(EmployeeRequestModel employeeRequestModel);

        int UpdateEmployeeDetails(EmployeeResponseModel employeeRequestModel); 
        int DeleteEmployeeDetails(int id);
        EmployeeResponseModel GetEmployeeDetailsByID(int id);
        List<EmployeeResponseModel> GetManagerwithEmployeesDetails();
        List<EmployeeResponseModel> GetEmployeeUnderManager(int id);
        List<EmployeeResponseModel> GetAllEmployeeDetails();
        int InsertEmp_managerDetails(Emp_ManagerRequestModel emp_ManagerRequestModel);
        LoginResponseModel Authenticate(string username, string password);
       
    }
}
