using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentResourceManagement.Models
{
    public class StudentResource
    {
        public int SID { get; set; }
        public Student Student { get; set; }
        public int RID { get; set; }
        public Resource Resource { get; set; }
        public DateTime AssignedOn { get; set; }
    }
}
