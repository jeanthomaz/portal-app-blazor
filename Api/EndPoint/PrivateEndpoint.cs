using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Api.Service;

namespace Api.Memoria
{
    [Route("api")]
    [ApiController]
    public class ApiHandler : ControllerBase
    {
        private readonly StudentService studentService;
        private readonly GroupService groupService;
        private readonly PresentationService presentationService;

        public ApiHandler(
            StudentService studentService,
            GroupService groupService,
            PresentationService presentationService)
        {
            this.studentService = studentService;
            this.groupService = groupService;
            this.presentationService = presentationService;
        }

        //[Authorize(Policy = "AdminPolicy")]
        [HttpGet("students")]
        public IActionResult ListStudents()
        {
            var students = studentService.GetAllStudents();
            return Ok(students);
        }

        //[Authorize(Policy = "AdminPolicy")]
        [HttpGet("groups")]
        public IActionResult ListGroups()
        {
            var groups = groupService.GetAllGroups();
            return Ok(groups);
        }

        //[Authorize(Policy = "AdminPolicy")]
        [HttpGet("presentations")]
        public IActionResult ListPresentations()
        {
            var presentations = presentationService.GetAllPresentations();
            return Ok(presentations);
        }
    }
}