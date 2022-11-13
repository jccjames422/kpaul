using InternTest.Models;
using InternTest.Utilities;
using InternTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InternTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var viewModel = new StudentViewModel {
                Students = FauxStudentDb.students,
            }; 
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult DeleteStudent(int id)
        {
            int numberRemoved = FauxStudentDb.students.RemoveAll(student => student.Id == id);
            return Json(new {studentsRemoved = numberRemoved});
        }

        public ActionResult AddStudent()
        {
            return View("AddStudent");
        }


        [HttpPost]
        public ActionResult AddStudent([Bind(Include = "firstName,lastName,field,age")] StudentModel student)
        {
            if (ModelState.IsValid)
            {
                student.Id = FauxStudentDb.incrementID++;
                FauxStudentDb.students.Add(student);
                return RedirectToAction("Index", "Home", new { area = "", });
            } else
            {
                return View("AddStudent");
            }
        }

        //public ActionResult EditUser(string first, string last, string field, int age)
        //{
        //    StudentModel student = new StudentModel(first, last, field, age);
        //    for (int i = FauxStudentDb.students.Count() - 1; i >= 0; i--)
        //    {
        //        if (FauxStudentDb.students[i].Equals(student))
        //        {
        //            FauxStudentDb.students[i].FirstName = first;
        //            FauxStudentDb.students[i].LastName = last;
        //            FauxStudentDb.students[i].Field = field;
        //            FauxStudentDb.students[i].Age = age;
        //        }
        //    }
        //    return Index();
        //}


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}