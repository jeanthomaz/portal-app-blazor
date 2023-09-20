// using Core.Entities;
// using Microsoft.AspNetCore.Mvc;
// using Api.Model;
// using Api.Service;
//
// namespace Api.Controllers
// {
//     [Route("api/students")]
//     [ApiController]
//     public class StudentController : ControllerBase
//     {
//         private readonly StudentService studentService;
//
//         public StudentController(StudentService studentService)
//         {
//             this.studentService = studentService;
//         }
//
//         [HttpGet("{id}")]
//         public IActionResult GetStudentById(int id)
//         {
//             var student = studentService.GetStudentById(id);
//
//             if (student == null)
//             {
//                 return NotFound(); // Retorna 404 Not Found se o aluno não for encontrado.
//             }
//
//             return Ok(student); // Retorna 200 OK com os detalhes do aluno se ele for encontrado.
//         }
//
//         [HttpPost]
//         public IActionResult CreateStudent([FromForm] StudentModel studentModel)
//         {
//             if (studentModel == null)
//             {
//                 return BadRequest("Dados do aluno inválidos");
//             }
//
//             var newStudent = new Student(studentModel.Name, studentModel.Role);
//
//             studentService.AddStudent(newStudent);
//
//             // Retorna um objeto com os detalhes do novo estudante com status HTTP 200.
//             return Ok(new
//             {
//                 Id = newStudent.Id,
//                 Name = newStudent.Name,
//                 Role = newStudent.Role
//             });
//         }
//
//     }
// }