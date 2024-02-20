using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProjectEMS.DL
{
    public partial class ProjectTable
    {
        public ProjectTable()
        {
            EmpProjTable = new HashSet<EmpProjTable>();
        }

        public int PId { get; set; }
        public string Pname { get; set; }
        public string Pdetails { get; set; }
        public DateTime PstartDate { get; set; }
        public DateTime PendDate { get; set; }

        public virtual ICollection<EmpProjTable> EmpProjTable { get; set; }
    }
}
