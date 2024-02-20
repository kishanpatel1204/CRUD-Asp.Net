using System;
using System.Collections.Generic;


// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProjectEMS.DL
{
    public partial class EmployeesTable
    {
        public EmployeesTable()
        {
            EmpProjTable = new HashSet<EmpProjTable>();
        }

        public int EId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public int City { get; set; }
        public int Department { get; set; }
        public int Role { get; set; }
        public int MobileNo { get; set; }
        public DateTime JoinningDate { get; set; }
        public int Status { get; set; }
        public string Password { get; set; }

        public virtual ICollection<EmpProjTable> EmpProjTable { get; set; }
        
        

    }
}
