using Project.Common;
using Project.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectEMS.Models
{
    public class EmployeeRequestModel
    {
        public int E_id { get; set; }
        [Required]
        [Display(Name = "Employee First Name")]
        public string Fname { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string Lname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required(ErrorMessage ="Please select your City")]
        public CityEnum City { get; set; }
        [Required]
        public DepartmentEnum Department { get; set; }
        [Required]
        public RoleEnum Role { get; set; }
        [Required]
        public int MobileNo { get; set; }
        [Required]
        public DateTime JoiningDate { get; set; }
        [Required]
        public StatusEnum Status { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$",
            ErrorMessage = "Password should be minimum of 8 characters of which one alphabet ,one number one special characters is required")]

        public String Password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        public string ConfimPassword { get; set; }
    }
}
