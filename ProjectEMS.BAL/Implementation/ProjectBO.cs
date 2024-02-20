using ProjectEMS.BAL.Interface;
using ProjectEMS.DAL.Interface;
using ProjectEMS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEMS.BAL.Implementation
{
    public class ProjectBO : IProject
    {
        private readonly IProjectRepository projectRepository;
        public ProjectBO(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }
        public int DeleteProjectDetails(int id)
        {
            var ReturnVal = projectRepository.DeleteProjectDetails(id);
            return ReturnVal;
        }

        public List<Emp_projResponseModel> GetAllEmp_ProjDetails()
        {
            var empproj = projectRepository.GetAllEmp_ProjDetails();
            return empproj;
        }

        public List<ProjectResponseModel> GetAllProjectDetails()
        {
            var project = projectRepository.GetAllProjectDetails();
            return project;
        }

        public List<ProjectResponseModel> GetEmp_projDetailsById(int id)
        {
            var empprojid = projectRepository.GetEmp_projDetailsById(id);
            return empprojid;
        }

        public ProjectResponseModel GetProjectDetailsByID(int id)
        {
            var projectid = projectRepository.GetProjectDetailsByID(id);
            return projectid;
        }

        public int InsertEmp_projDetails(Emp_projRequestModel emp_projRequestModel)
        {
            var isInsertedep = projectRepository.InsertEmp_projDetails(emp_projRequestModel);
            return isInsertedep;
        }

        public int InsertProjectDetails(ProjectRequestModel proj_RequestModel)
        {
            var isInserted = projectRepository.InsertProjectDetails(proj_RequestModel);
            return isInserted;
        }

        public int UpdateEmp_projDetails(Emp_projRequestModel emp_projRequestModel)
        {
            var isUpdatedep = projectRepository.UpdateEmp_projDetails(emp_projRequestModel);
            return isUpdatedep;
        }

        public int UpdateProjectDetails(ProjectResponseModel proj_RequestModel)
        {
            var isUpdated = projectRepository.UpdateProjectDetails(proj_RequestModel);
            return isUpdated;
        }
    }
}
