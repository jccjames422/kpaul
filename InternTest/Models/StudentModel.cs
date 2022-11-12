using InternTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternTest.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Field { get; set; }
        public int Age { get; set; }

        public StudentModel() { }

        public StudentModel(int id, string firstName, string lastName, string field, int age)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Field = field;
            Age = age;
        }

        public StudentModel(StudentViewModel student)
        {
            this.Id = student.Id;
            this.FirstName = student.FirstName;
            this.LastName = student.LastName;
            this.Field = student.Field;
            this.Age = student.Age;
        }

        public override bool Equals(object obj)
        {
            StudentModel student = (StudentModel)obj;
            return this.Id.Equals(student.Id);
        }
    }
}