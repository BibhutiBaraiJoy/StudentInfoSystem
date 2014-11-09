using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentInfoSystem.Models
{
    public class StudentInfoDBContext:DbContext
    {
        public StudentInfoDBContext(): base("Bibhuti")
        {
            
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student>Students { get; set; }
    }
}