using StudentResourceManagement.Data;
using StudentResourceManagement.Models;
using StudentResourceManagement.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentResourceManagement.Repository
{
    public class StudentRepository : IStudent
    {
        private ApplicationDbContext _db;

        public StudentRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool CreateStudent(Student student)
        {
            _db.Students.Add(student);
            return Save();
        }

        public bool UpdateStudent(Student student)
        {
            _db.Students.Update(student);
            return Save();
        }

        public bool DeleteStudent(int studentId)
        {
            var removeStudent = _db.Students.FirstOrDefault(s => s.SID == studentId);
            _db.Students.Remove(removeStudent);
            return Save();
        }

        public Student GetStudent(int id)
        {
            return _db.Students.FirstOrDefault(s => s.SID == id);
        }

        public ICollection<Student> GetStudents()
        {
            return _db.Students.ToList();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool StudentExist(string name)
        {
            bool value = _db.Students.Any(a => a.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

    }
}
