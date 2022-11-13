using InternTest.Models;
using InternTest.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InternTest.Controllers
{
    public class StudentController : Controller
    {
         public ActionResult Create()
        {
            return View("Edit");
        }

        public ActionResult Edit(StudentModel student)
        {
            return View(student);
        }


        [HttpPost]
        public ActionResult Update([Bind(Include = "firstName,lastName,field,age")] StudentModel student)
        {
            if (ModelState.IsValid)
            {
                student.Id = FauxStudentDb.incrementID++;
                FauxStudentDb.students.Add(student);
                return RedirectToAction("Index", "Home");
            }

            return View("Edit");
        }

        [HttpPost]
        public ActionResult Destroy(int id)
        {
            int numberRemoved = FauxStudentDb.students.RemoveAll(student => student.Id == id);
            return Json(new { studentsRemoved = numberRemoved });
        }
    }
}