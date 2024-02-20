using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectEMS.Models
{
    public class Emp_ManagerRequestModel
    {
        [Key]
        public int EM_id { get; set; }
        public int M_id { get; set; }
        public int E_id { get; set; }
    }
}
