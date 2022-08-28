using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvc.Models
{
    public class mvcemployeemodel
    {
        public int EmployeelID { get; set; }
        [Required(ErrorMessage ="This Field is Required")]
        public string Name { get; set; }
        public Nullable<int> Position { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<int> Salary { get; set; }
    }
}