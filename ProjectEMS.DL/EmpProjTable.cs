using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProjectEMS.DL
{
    public partial class EmpProjTable
    {
        public int EmpProId { get; set; }
        public int EId { get; set; }
        public int PId { get; set; }

        public virtual EmployeesTable E { get; set; }
        public virtual ProjectTable P { get; set; }
    }
}
