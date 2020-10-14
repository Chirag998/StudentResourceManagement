using StudentResourceManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentResourceManagement.Repository.IRepository
{
   public interface IResource
    {
        ICollection<Resource> GetResources();
        Resource GetResource(int rid);
        bool ResourceExist(string name);
        bool CreateResource(Resource resource);
        bool UpdateResource(Resource resource);
        bool DeleteResource(int resourceId);
        bool Save();
    }
}
