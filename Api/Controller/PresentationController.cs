using Api.Models;
using Core.Entities;
using Core.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Core.Services;

namespace Api.Controllers
{
    [Route("api/presentations")]
    [ApiController]
    public class PresentationController : ControllerBase
    {
        private List<Presentation> presentations = new List<Presentation>();
        private readonly StudentService studentService;

        public PresentationController(StudentService studentService)
        {
            this.studentService = studentService;
        }


        [HttpGet("{id}")]
        public IActionResult GetPresentationById(int id)
        {
            var presentation = studentService.GetPresentationById(id);

            if (presentation == null)
            {
                return NotFound("Apresentação não encontrada");
            }

            // Verifica se a apresentação está vinculada a um grupo
            if (presentation.Group != null)
            {
                var presentationWithGroup = new
                {
                    Id = presentation.Id,
                    Title = presentation.Title,
                    Description = presentation.Description,
                    Body = presentation.Body,
                    Group = new
                    {
                        Id = presentation.GroupId
                    }
                };

                return Ok(presentationWithGroup);
            }

            return Ok(presentation);
        }

        [HttpPost]
        public IActionResult CreatePresentation([FromForm] PresentationModel presentationModel)
        {
            if (presentationModel == null)
            {
                return BadRequest("Dados da apresentação inválidos");
            }

            var group = studentService.GetGroupById(presentationModel.GroupId);

            if (group == null)
            {
                return BadRequest("Grupo não encontrado");
            }

            var newPresentation = new Presentation(presentationModel.Title,
                presentationModel.Description,
                group,
                presentationModel.Body,
                new List<Url>());

            studentService.AddPresentation(newPresentation);
            return Ok(newPresentation);
        }
    }
}