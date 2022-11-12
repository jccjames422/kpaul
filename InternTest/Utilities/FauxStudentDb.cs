using InternTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternTest.Utilities
{
    public static class FauxStudentDb
    {

        public static int incrementID;

        public static List<StudentModel> students = new List<StudentModel>();

        static FauxStudentDb()
        {
            incrementID = 1;
            students.Add(new StudentModel(incrementID++, "Sam", "Hill", "Math", 19));
            students.Add(new StudentModel(incrementID++, "Jessica", "Hill", "Chemistry", 20));
            students.Add(new StudentModel(incrementID++, "Doug", "Lin", "Math", 20));
            students.Add(new StudentModel(incrementID++, "Meridith", "Butcher", "Computer Science", 29));
            students.Add(new StudentModel(incrementID++, "Bob", "Best", "Chemistry", 19));
            students.Add(new StudentModel(incrementID++, "Linda", "Samson", "English", 21));
            students.Add(new StudentModel(incrementID++, "Sam", "Hill", "Math", 19));
        }
    }
}