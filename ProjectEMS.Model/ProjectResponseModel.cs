using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectEMS.Models
{
    public class ProjectResponseModel
    {
        [Key]
        public int P_id { get; set; }
        public string Pname { get; set; }
        public string Pdetails { get; set; }
        public DateTime PStartDate { get; set; }
        public DateTime PEndDate { get; set; }
    }
}
