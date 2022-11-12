﻿using InternTest.Models;
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
            List<StudentViewModel> students = new List<StudentViewModel>();
            foreach (var item in FauxStudentDb.students)
            {
                students.Add(new StudentViewModel(item));
            }
            return View(students);
        }

        public ActionResult DeleteUser(int id)
        {
            int numberRemoved = FauxStudentDb.students.RemoveAll(student => student.Id == id);
            return Json(new {studentsRemoved = numberRemoved});
        }

        public ActionResult AddStudent()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddStudent([Bind(Include = "first,last,field,age")] StudentModel student)
        {
            if (ModelState.IsValid)
            {
                FauxStudentDb.students.Add(student);
                return RedirectToAction("Index", "Home", new { area = "", });
            }
            return View();
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