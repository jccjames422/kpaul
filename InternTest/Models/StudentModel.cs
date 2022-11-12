using InternTest.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InternTest.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Field { get; set; }
        [Required]
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