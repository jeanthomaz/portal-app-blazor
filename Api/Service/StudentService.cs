using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;

namespace Api.Service
{
    public class StudentService
    {
        private static List<Student> students = new List<Student>();

        public List<Student> GetAllStudents()
        {
            return students;
        }

        public Student GetStudentById(int id)
        {
            return students.FirstOrDefault(student => student.Id == id);
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }
    }
}