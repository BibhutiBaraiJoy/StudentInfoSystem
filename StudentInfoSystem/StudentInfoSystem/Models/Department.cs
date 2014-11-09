using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentInfoSystem.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [DisplayName("Department_Name")]
        [Required(ErrorMessage = "The DeptName is Needed")]
        [Remote("CheckDeptNameUnikeNess", "Department", ErrorMessage = "The DeptName is allready Exist")]
        public string DepartmentName { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}