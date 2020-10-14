using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentResourceManagement.Models
{
    public class Resource
    {
        [Key]
        public int RID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public ICollection<StudentResource> StudentResources { get; set; }
    }
}
