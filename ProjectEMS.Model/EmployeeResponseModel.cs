using Project.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectEMS.Models
{
    public class EmployeeResponseModel
    {
        [Key]
        public int E_id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public CityEnum City { get; set; }
        public DepartmentEnum Department { get; set; }
        public RoleEnum Role { get; set; }
        public int MobileNo { get; set; }
        public DateTime JoiningDate { get; set; }
        public StatusEnum Status { get; set; }
        public string Password { get; set; }
        public string ConfimPassword { get; set; }
       
    }
}
