using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectEMS.Models
{
    public class ProjectRequestModel
    {
        public int P_id { get; set; }
        [Required]
        public string Pname { get; set; }
        public string Pdetails { get; set; }
        [Required]
        public DateTime PStartDate { get; set; }
        [Required]
        public DateTime PEndDate { get; set; }
    }
}
