using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentInfoSystem.Models;

namespace StudentInfoSystem.Controllers
{
    public class StudentController : Controller
    {
        private StudentInfoDBContext db = new StudentInfoDBContext();

        // GET: /Student/
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.Department);
            return View(students.ToList());
        }
        public ActionResult PdfIndex()
        {
            var stdList = db.Students;
            List<Student> students = new List<Student>();
            foreach (Student student in stdList)
            {
                Student aStudent = new Student()
                {
                    StudentId = student.StudentId,
                    Name = student.Name.ToString(),
                    Roll = student.Roll.ToString(),
                    Department = (Department)student.Department,
                    Email = student.Email.ToString(),
                    PhoneNo = student.PhoneNo.ToString()
                };

                students.Add(aStudent);
            }

            return View(students);
        }
        public ActionResult PDF()
        {

            var stdList = db.Students;
            List<Student> students = new List<Student>();
            foreach (Student student in stdList)
            {
                Student aStudent = new Student()
                {
                    StudentId = student.StudentId,
                    Name = student.Name.ToString(),
                    Roll =student.Roll.ToString(),
                   Department = (Department)student.Department,
                   Email = student.Email.ToString(),
                   PhoneNo = student.PhoneNo.ToString()

                };

                students.Add(aStudent);
            }


            return new RazorPDF.PdfResult(students, "PDF");
        }
        public ActionResult StudentInfo()
        {
            var stdList = db.Students;
            List<Student> students = new List<Student>();
            foreach (Student student in stdList)
            {
                Student aStudent = new Student()
                {
                    StudentId = student.StudentId,
                    Name = student.Name.ToString(),
                    Roll = student.Roll.ToString(),
                    Department = (Department)student.Department,
                    Email = student.Email.ToString(),
                    PhoneNo = student.PhoneNo.ToString()

                };

                students.Add(aStudent);
            }


            return View(students);
        }
        // GET: /Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: /Student/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName");
            return View();
        }

        // POST: /Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="StudentID,Name,Roll,DepartmentId,Email,PhoneNo")] Student student)
        {
            TempData["Std"] = "";
            if (ModelState.IsValid)
            {
                TempData["Std"] = "Student Insert Successfully" + " Studentr Name : " + student.Name;
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", student.DepartmentId);
            return View(student);
        }

        // GET: /Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", student.DepartmentId);
            return View(student);
        }

        // POST: /Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="StudentID,Name,Roll,DepartmentId,Email,PhoneNo")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", student.DepartmentId);
            return View(student);
        }

        // GET: /Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: /Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult CheckEmailUniqueNess(string email)
        {
            var emailNo = db.Students.FirstOrDefault(d => d.Email == (string)email);
            if (emailNo != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult CheckRollUniqueNess(string roll)
        {
            var rollNo = db.Students.FirstOrDefault(d => d.Roll == (string)roll);
            if (rollNo != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult CheckPhoneNoUniqueNess(string phoneno)
        {
            var phoneNo = db.Students.FirstOrDefault(d => d.PhoneNo == (string)phoneno);
            if (phoneNo != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
