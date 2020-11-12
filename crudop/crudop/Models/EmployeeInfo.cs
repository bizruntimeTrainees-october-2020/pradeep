using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace crudop.Models
{
    public class EmployeeInfo
    {
        public int id { get; set; }
        [Required(ErrorMessage ="enter name")]
        [Display(Name ="employee name")]
        public string name{ get; set; }
        [Required(ErrorMessage ="enter designation")]
        [Display (Name="desg")]
        public string desg { get; set; }
        
    }
}
