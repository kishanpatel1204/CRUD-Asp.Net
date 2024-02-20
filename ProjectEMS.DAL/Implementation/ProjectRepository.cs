using ProjectEMS.DAL.Interface;
using ProjectEMS.DL;
using ProjectEMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEMS.DAL.Implementation
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly RiseProjectContext _Db;
        public ProjectRepository(RiseProjectContext Db)
        {
            _Db = Db;
        }
        public int DeleteProjectDetails(int id)
        {
            ProjectTable project = new ProjectTable();
            project.PId = id;
            _Db.ProjectTable.Remove(project);
            var isDeleted = _Db.SaveChanges();
            return isDeleted;
        }

        public List<Emp_projResponseModel> GetAllEmp_ProjDetails()
        {
            var empproj = _Db.EmpProjTable.ToList();

            List<Emp_projResponseModel> empprojResponseModel = new List<Emp_projResponseModel>();
            foreach(var ep in empproj)
            {
                Emp_projResponseModel epResponseModel = new Emp_projResponseModel();
                epResponseModel.EmpPro_id = ep.EmpProId;
                epResponseModel.E_id = ep.EId;
                epResponseModel.P_id = ep.PId;

                empprojResponseModel.Add(epResponseModel);

            }

            return empprojResponseModel;
        }

        public List<ProjectResponseModel> GetAllProjectDetails()
        {
            var project = _Db.ProjectTable.ToList();


            List<ProjectResponseModel> projectResponseModels = new List<ProjectResponseModel>();
            foreach (var proj in project)
            {
                ProjectResponseModel projResponseModel = new ProjectResponseModel();
                projResponseModel.P_id=proj.PId;
                projResponseModel.Pname = proj.Pname;
                projResponseModel.Pdetails = proj.Pdetails;
                projResponseModel.PStartDate = proj.PstartDate;
                projResponseModel.PEndDate = proj.PendDate;



                projectResponseModels.Add(projResponseModel);

            }


            return projectResponseModels;
        }

        public List<ProjectResponseModel> GetEmp_projDetailsById(int id)
        {
            var project = _Db.EmpProjTable.Where(x => x.EId == id).Select(y => y.PId).ToList();
            List<ProjectResponseModel> projectResponseModels = new List<ProjectResponseModel>();
           foreach(var proj in project)
            {
                ProjectResponseModel projectResponseModel = new ProjectResponseModel();
                projectResponseModel = GetProjectDetailsByID((int)proj);
                projectResponseModels.Add(projectResponseModel);
            }

            return projectResponseModels;
        }

        public ProjectResponseModel GetProjectDetailsByID(int id)
        {
            ProjectResponseModel projResponseModel = new ProjectResponseModel();
            
            var project = _Db.ProjectTable.Where(x => x.PId == id).FirstOrDefault();

            projResponseModel.P_id = project.PId;
            projResponseModel.Pname = project.Pname;
            projResponseModel.Pdetails = project.Pdetails;
            projResponseModel.PStartDate = project.PstartDate;
            projResponseModel.PEndDate=project.PendDate;

            return projResponseModel;
        }

        public int InsertEmp_projDetails(Emp_projRequestModel emp_projRequestModel)
        {
            EmpProjTable empprojtable = new EmpProjTable();
           
            empprojtable.EId = emp_projRequestModel.E_id;
            empprojtable.PId = emp_projRequestModel.P_id;




            _Db.EmpProjTable.Add(empprojtable);
            var isInsert = _Db.SaveChanges();
            return isInsert;

        }

        public int InsertProjectDetails(ProjectRequestModel proj_RequestModel)
        {
            ProjectTable project = new ProjectTable();

            project.Pname = proj_RequestModel.Pname;
            project.Pdetails = proj_RequestModel.Pdetails;
            project.PstartDate = proj_RequestModel.PStartDate;
            project.PendDate = proj_RequestModel.PEndDate;

            _Db.ProjectTable.Add(project);
            var isInserted = _Db.SaveChanges();

            return isInserted;
        }

        public int UpdateEmp_projDetails(Emp_projRequestModel emp_projRequestModel)
        {
            throw new NotImplementedException();
        }

        public int UpdateProjectDetails(ProjectResponseModel proj_RequestModel)
        {
            ProjectTable project = new ProjectTable();
            project.PId = proj_RequestModel.P_id;
            project.Pname = proj_RequestModel.Pname;
            project.Pdetails = proj_RequestModel.Pdetails;
            project.PstartDate = proj_RequestModel.PStartDate;
            project.PendDate = proj_RequestModel.PEndDate;

            _Db.ProjectTable.Attach(project);
            _Db.ProjectTable.Update(project);
            var isUpdated = _Db.SaveChanges();
            return isUpdated;
        }
    }
}

