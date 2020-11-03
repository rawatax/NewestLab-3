using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }
        public string Notes { get; set; }
        public int TeacherId { get; set; }

        public int TshirtId { get; set; }

        public Student(int studentId, string firstName, string lastName, int age, string notes, int teacherId, int tshirtId)
        {
            this.StudentId = studentId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Notes = notes;
            this.TeacherId = teacherId;
            this.TshirtId = tshirtId;
        }

    }
}