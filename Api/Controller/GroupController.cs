using Api.Models;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller
{
    [Route("api/groups")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IService _service;

        public GroupController(IService service)
        {
            _service = service;
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateGroup([FromBody] GroupModel groupModel)
        {
            if (groupModel == null)
            {
                return BadRequest("Dados do grupo inválidos");
            }

            var newGroup = new Group(groupModel.Subject, groupModel.GroupMembers, new List<Presentation>());

            _service.AddGroup(newGroup);
            return Ok(newGroup); 
        }
    }
}