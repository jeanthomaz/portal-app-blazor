using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Api.Model;
using Core.Services;

namespace Api.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService studentService;

        public StudentController(StudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = studentService.GetStudentById(id);

            if (student == null)
            {
                return NotFound();
            }

            
            if (student.Group != null)
            {
                var studentWithGroup = new
                {
                    Id = student.Id,
                    Name = student.Name,
                    
                    Group = new
                    {
                        Id = student.Group.Id
                    }
                };

                return Ok(studentWithGroup);
            }

            return Ok(student);
        }

        [HttpPost]
            public IActionResult CreateStudent([FromForm] StudentModel studentModel)
            {
                if (studentModel == null)
                {
                    return BadRequest("Dados do aluno inválidos");
                }

                if (studentModel.GroupId <= 0)
                {
                    return BadRequest("GroupId inválido");
                }

                var group = studentService.GetGroupById(studentModel.GroupId);

                if (group == null)
                {
                    return BadRequest("Grupo não encontrado");
                }

                var newStudent = new Student(studentModel.Name, studentModel.Role);

                studentService.AddStudentToGroup(newStudent, studentModel.GroupId);

                return Ok(new
                {
                    Id = newStudent.Id,
                    Name = newStudent.Name,
                    Role = newStudent.Role
                });
            }

    }
}
