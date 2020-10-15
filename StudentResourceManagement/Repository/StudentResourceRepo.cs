using Microsoft.EntityFrameworkCore;
using StudentResourceManagement.Data;
using StudentResourceManagement.Models;
using StudentResourceManagement.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentResourceManagement.Repository
{
    public class StudentResourceRepo : IStudentResource
    {
        private ApplicationDbContext _db;

        public StudentResourceRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public ICollection<StudentResource> GetStudentResources()
        {

            return _db.StudentResources.Include(s => s.Student).Include(r => r.Resource).ToList();
        }
    }
}
