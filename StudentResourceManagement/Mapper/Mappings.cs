using AutoMapper;
using StudentResourceManagement.Models;
using StudentResourceManagement.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentResourceManagement.Mapper
{
    public class Mappings:Profile
    {
        public Mappings()
        {
            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<Resource, ResourceDTO>().ReverseMap();
        }
    }
}
