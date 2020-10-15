using StudentResourceManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentResourceManagement.Repository.IRepository
{
   public interface IStudentResource
    {
        ICollection<StudentResource> GetStudentResources();
    }
}
