// using Api.Models;
// using Api.Service;
// using Core.Entities;
// using Core.ValueObjects;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using System.Collections.Generic;
//
// namespace Api.Controllers
// {
//     [Route("api/presentations")]
//     [ApiController]
//     public class PresentationController : ControllerBase
//     {
//         private List<Presentation> presentations = new List<Presentation>();
//         private readonly PresentationService presentationService; 
//
//         public PresentationController(PresentationService presentationService)
//         {
//             this.presentationService = presentationService;
//         }
//
//         //[Authorize(Roles = "Admin")]
//         [HttpPost]
//         public IActionResult CreatePresentation([FromBody] PresentationModel presentationModel)
//         {
//             if (presentationModel == null)
//             {
//                 return BadRequest("Dados da apresentação inválidos");
//             }
//
//             var newPresentation = new Presentation(presentationModel.Title, presentationModel.Description, new List<Student>(), presentationModel.Body, new List<Url>());
//
//             presentationService.AddPresentation(newPresentation);
//             return Ok(newPresentation); 
//         }
//     }
// }