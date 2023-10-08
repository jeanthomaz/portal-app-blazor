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

        [HttpGet("{id}")]
        public IActionResult GetGroup(int id)
        {
            var group = _service.GetGroupById(id);

            if (group == null)
            {
                return NotFound("Grupo não encontrado");
            }

            return Ok(group);
        }

        [HttpPost]
        public IActionResult CreateGroup([FromForm] GroupModel groupModel)
        {
            if (groupModel == null || string.IsNullOrWhiteSpace(groupModel.Subject))
            {
                return BadRequest("Nome do grupo inválido");
            }

            var newGroup = new Group(groupModel.Subject);

            _service.AddGroup(newGroup);
            return Ok(newGroup);
        }
    }
}