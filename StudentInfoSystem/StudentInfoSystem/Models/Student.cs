using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentInfoSystem.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required(ErrorMessage = "The Student Name is Needed")]
        [DisplayName("Student_Name")]
        public string Name { get; set; }
        [DisplayName("Student_Roll")]
        [Required(ErrorMessage = "The Student Roll is Needed")]
        [Remote("CheckRollUniqueNess", "Student", ErrorMessage = "The Roll Number is Exist")]
        public string Roll { get; set; }
        [Required(ErrorMessage = "Please Select department")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        [DisplayName("Student_Email")]
        [EmailAddress]
        [Required(ErrorMessage = "The Student Email is Needed")]
        [Remote("CheckEmailUniqueNess", "Student", ErrorMessage = "The Email Address is Exist")]
        public string Email { get; set; }
        [DisplayName("Student_PhoneNo")]
        [Required(ErrorMessage = "The DeptName is Needed")]
        [Remote("CheckPhoneNoUniqueNess", "Student", ErrorMessage = "The Phone Number is Exist")]

        public string PhoneNo { get; set; }


    }
}