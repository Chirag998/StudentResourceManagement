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
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class ResourceController : Controller
    {
        private IResource _resource;

        private readonly IMapper _mapper;

        public ResourceController(IResource resource, IMapper mapper)
        {
            _resource = resource;
            _mapper = mapper;
        }

        /// <summary>
        /// Get list of resources
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<ResourceDTO>))]
        public IActionResult GetResources()
        {
            var objList = _resource.GetResources();
            var objDto = new List<ResourceDTO>();
            foreach (var obj in objList)
            {
                objDto.Add(_mapper.Map<ResourceDTO>(obj));
            }
            return Ok(objDto);
        }

        /// <summary>
        /// Get single resource
        /// </summary>
        /// <param name="rid">The id of resource</param>
        /// <returns></returns>
        [HttpGet("{rid:int}", Name = "GetResource")]
        [ProducesResponseType(200, Type = typeof(ResourceDTO))]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public IActionResult GetResource(int rid)
        {
            var obj = _resource.GetResource(rid);
            if (obj == null)
            {
                return NotFound();
            }

            var objDto = _mapper.Map<ResourceDTO>(obj);
            return Ok(objDto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ResourceDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateResource([FromBody] ResourceDTO resourceDTO)
        {
            if (resourceDTO == null)
            {
                return BadRequest(ModelState);
            }
            if (_resource.ResourceExist(resourceDTO.Name))
            {
                ModelState.AddModelError("", "Resource already exist");
                return StatusCode(404, ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resourceObj = _mapper.Map<Resource>(resourceDTO);
            if (!_resource.CreateResource(resourceObj))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record{resourceObj.Name}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetResource", new { rid = resourceObj.RID }, resourceObj);
        }

        [HttpPatch("{rid:int}", Name = "UpdateResource")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateResource(int rid, [FromBody] ResourceDTO resourceDTO)
        {
            if (resourceDTO == null || rid != resourceDTO.RID)
            {
                return BadRequest(ModelState);
            }

            var resourceObj = _mapper.Map<Resource>(resourceDTO);
            if (!_resource.UpdateResource(resourceObj))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record{resourceObj.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{rid:int}", Name = "DeleteResource")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteResource(int rid)
        {
            var resourceObj = _resource.GetResource(rid);
            if (!_resource.DeleteResource(rid))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record{resourceObj.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

    }
}
