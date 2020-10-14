using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentResourceManagement.Models;
using StudentResourceManagement.Models.DTOs;
using StudentResourceManagement.Repository.IRepository;

namespace StudentResourceManagement.Controllers
{
    [Route("api/v{version:apiVersion}/Student")]
    [ApiVersion("2.0")]
    [ApiController]
    public class StudentV2Controller : Controller
    {
        private IStudent _student;

        private readonly IMapper _mapper;

        public StudentV2Controller(IStudent student, IMapper mapper)
        {
            _student = student;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var objList = _student.GetStudents();

            var objDto = new List<StudentDTO>();
            foreach (var obj in objList)
            {
                objDto.Add(_mapper.Map<StudentDTO>(obj));
            }
            return Ok(objDto);
        }
    }
}
