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
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private IStudent _student;

        private readonly IMapper _mapper;

        public StudentController(IStudent student, IMapper mapper)
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

        [HttpGet("{id:int}",Name="GetStudent")]
        public IActionResult GetStudent(int id)
        {
            var obj = _student.GetStudent(id);
            if (obj == null)
            {
                return NotFound();
            }

            var objDto = _mapper.Map<StudentDTO>(obj);
            return Ok(objDto);
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] StudentDTO studentDTO)
        {
            if (studentDTO == null)
            {
                return BadRequest(ModelState);
            }
            if (_student.StudentExist(studentDTO.Name))
            {
                ModelState.AddModelError("", "Student already exist");
                return StatusCode(404, ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studentObj = _mapper.Map<Student>(studentDTO);
            if (!_student.CreateStudent(studentObj))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record{studentDTO.Name}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetStudent",new { id=studentObj.SID},studentObj);


        }

        [HttpPatch("{sid:int}", Name = "UpdateStudent")]
        public IActionResult UpdateStudent(int sid, [FromBody] StudentDTO studentDTO)
        {
            if (studentDTO == null || sid != studentDTO.SID)
            {
                return BadRequest(ModelState);
            }

            var studentObj = _mapper.Map<Student>(studentDTO);
            if (!_student.UpdateStudent(studentObj))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record{studentObj.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{sid:int}", Name = "DeleteStudent")]
        public IActionResult DeleteStudent(int sid)
        {
            var studentObj = _student.GetStudent(sid);
            if (!_student.DeleteStudent(sid))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record{studentObj.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


    }
}
