using InternTest.Models;
using InternTest.Utilities;
using System.Linq;
using System.Web.Mvc;

namespace InternTest.Controllers
{
    public class StudentController : Controller
    {
         public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "firstName,lastName,field,age")] StudentModel student)
        {
            if (ModelState.IsValid)
            {
                student.Id = FauxStudentDb.incrementID++;
                FauxStudentDb.students.Add(student);
                return RedirectToAction("Index", "Home");
            }

            return View("Edit");
        }

        public ActionResult Edit(int id)
        {
            var student = FauxStudentDb.students.Where(s => s.Id == id).First();
            return View(student);
        }

        [HttpPost]
        public ActionResult Update([Bind(Include = "id,firstName,lastName,field,age")] StudentModel student)
        {
            if (ModelState.IsValid)
            {
                FauxStudentDb.students.Remove(student); // remove the old record
                FauxStudentDb.students.Add(student); // add the updated record
                FauxStudentDb.students = FauxStudentDb.students.OrderBy(s => s.Id).ToList(); // sort the list by Id to preserve the order
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