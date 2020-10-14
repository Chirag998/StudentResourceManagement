using StudentResourceManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentResourceManagement.Repository.IRepository
{
    public interface IStudent
    {
        ICollection<Student> GetStudents();
        Student GetStudent(int id);
        bool StudentExist(string name);
        bool CreateStudent(Student student);
        bool UpdateStudent(Student student);
        bool DeleteStudent(int studentId);
        bool Save();
    }
}
