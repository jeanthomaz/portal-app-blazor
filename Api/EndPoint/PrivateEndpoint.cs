using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Memoria
{
    [Route("api")]
    [ApiController]
    public class ApiHandler : ControllerBase
    {
        private readonly IService _service;

        public ApiHandler(IService service)
        {
            _service = service;
        }

        //[Authorize(Policy = "AdminPolicy")]
        [HttpGet("students")]
        public IActionResult ListStudents()
        {
            var students = _service.ListAllStudents();
            return Ok(students);
        }

        //[Authorize(Policy = "AdminPolicy")]
        [HttpGet("groups")]
        public IActionResult ListGroups()
        {
            var groups = _service.ListAllGroups();
            return Ok(groups);
        }

        //[Authorize(Policy = "AdminPolicy")]
        [HttpGet("presentations")]
        public IActionResult ListPresentations()
        {
            var presentations = _service.ListAllPresentations();
            return Ok(presentations);
        }
    }
}