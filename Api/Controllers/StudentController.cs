using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using APIPortal.DTOs;

namespace MinhaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {

        //Armazenamento provisório
        private static List<StudentDTO> _students = new List<StudentDTO>();

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            return Ok(_students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(Guid id)
        {
            var student = _students.Find(s => s.Id == id);
            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] StudentDTO studentDTO)
        {
            studentDTO.Id = Guid.NewGuid();
            _students.Add(studentDTO);

            return CreatedAtAction(nameof(GetStudentById), new { id = studentDTO.Id }, studentDTO);
        }
    }
}






