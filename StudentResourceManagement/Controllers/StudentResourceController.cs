using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentResourceManagement.Models.DTOs;
using StudentResourceManagement.Repository.IRepository;

namespace StudentResourceManagement.Controllers
{
    [Route("api/v{version:apiVersion}/StudentResource")]
    [ApiController]
    public class StudentResourceController : Controller
    {
        private IStudentResource _resource;

        private readonly IMapper _mapper;

        public StudentResourceController(IStudentResource resource,IMapper mapper)
        {
            _resource = resource;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetStudentResources()
        {
            var objList = _resource.GetStudentResources();
            var objDto = new List<StudentResourceDTO>();
            foreach (var obj in objList)
            {
                objDto.Add(_mapper.Map<StudentResourceDTO>(obj));
            }
            return Ok(objDto);
        }
    }
}
