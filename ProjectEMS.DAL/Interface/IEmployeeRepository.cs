using ProjectEMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEMS.DAL.Interface
{
    public interface IEmployeeRepository
    {
        int InsertEmployeeDetails(EmployeeRequestModel emp_RequestModel);

        int UpdateEmployeeDetails(EmployeeResponseModel emp_RequestModel);
        int DeleteEmployeeDetails(int id);
        EmployeeResponseModel GetEmployeeDetailsByID(int id);
        List<EmployeeResponseModel> GetManagerwithEmployeesDetails();
        List<EmployeeResponseModel> GetEmployeeUnderManager(int id);
        List<EmployeeResponseModel> GetAllEmployeeDetails();
        int InsertEmp_managerDetails(Emp_ManagerRequestModel emp_ManagerRequestModel);  //assign manager to employee
        LoginResponseModel Authenticate(string username, string password);


        
       
        
    }
}
