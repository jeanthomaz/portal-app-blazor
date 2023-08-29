using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using APIPortal.DTOs;

namespace MinhaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PresentationController : ControllerBase
    {
        private static List<PresentationDTO> _presentations = new List<PresentationDTO>();

        [HttpGet]
        public IActionResult GetAllPresentations()
        {
            return Ok(_presentations);
        }

        [HttpGet("{id}")]
        public IActionResult GetPresentationById(Guid id)
        {
            var presentation = _presentations.Find(p => p.Id == id);
            if (presentation == null)
                return NotFound();

            return Ok(presentation);
        }

        [HttpPost]
        public IActionResult CreatePresentation([FromBody] PresentationDTO presentationDTO)
        {
            presentationDTO.Id = Guid.NewGuid();
            _presentations.Add(presentationDTO);

            return CreatedAtAction(nameof(GetPresentationById), new { id = presentationDTO.Id }, presentationDTO);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePresentation(Guid id, [FromBody] PresentationDTO presentationDTO)
        {
            var existingPresentation = _presentations.Find(p => p.Id == id);
            if (existingPresentation == null)
                return NotFound();

            existingPresentation.Title = presentationDTO.Title;
            existingPresentation.Description = presentationDTO.Description;
            existingPresentation.Body = presentationDTO.Body;
            existingPresentation.References = presentationDTO.References;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePresentation(Guid id)
        {
            var presentationToRemove = _presentations.Find(p => p.Id == id);
            if (presentationToRemove == null)
                return NotFound();

            _presentations.Remove(presentationToRemove);

            return NoContent();
        }
    }
}
