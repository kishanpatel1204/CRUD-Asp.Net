using ProjectEMS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEMS.BAL.Interface
{
    public interface IProject
    {
        int InsertProjectDetails(ProjectRequestModel proj_RequestModel);

        int UpdateProjectDetails(ProjectResponseModel proj_RequestModel);
        int DeleteProjectDetails(int id);
        ProjectResponseModel GetProjectDetailsByID(int id);
        List<ProjectResponseModel> GetAllProjectDetails();
        int InsertEmp_projDetails(Emp_projRequestModel emp_projRequestModel);  //how many employees work in one project
        int UpdateEmp_projDetails(Emp_projRequestModel emp_projRequestModel);   //add new employee in project or removed old employee from project
        List<ProjectResponseModel> GetEmp_projDetailsById(int id);
        List<Emp_projResponseModel> GetAllEmp_ProjDetails();
    }
}
