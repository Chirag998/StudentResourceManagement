using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentResourceManagement.Models.DTOs
{
    public class StudentDTO
    {
        public int SID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }

        public bool IsActive { get; set; }
    }
}
