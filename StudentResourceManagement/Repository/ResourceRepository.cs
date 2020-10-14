using StudentResourceManagement.Data;
using StudentResourceManagement.Models;
using StudentResourceManagement.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentResourceManagement.Repository
{
    public class ResourceRepository : IResource
    {
        private readonly ApplicationDbContext _db;

        public ResourceRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public ICollection<Resource> GetResources()
        {
            return _db.Resources.ToList();
        }

        public bool CreateResource(Resource resource)
        {
            _db.Resources.Add(resource);
            return Save();
        }

        public bool UpdateResource(Resource resource)
        {
            _db.Resources.Update(resource);
            return Save();
        }

        public bool DeleteResource(int resourceId)
        {
            var removeResource = _db.Resources.FirstOrDefault(r => r.RID == resourceId);
            _db.Resources.Remove(removeResource);
            return Save();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public Resource GetResource(int rid)
        {
            return _db.Resources.FirstOrDefault(r => r.RID == rid);
        }

        public bool ResourceExist(string name)
        {
            bool value = _db.Resources.Any(a => a.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }
    }
}
