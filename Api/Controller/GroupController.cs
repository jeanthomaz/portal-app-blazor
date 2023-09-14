using Api.Models;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Api.Service;

namespace Api.Controllers
{
    [Route("api/groups")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private List<Group> groups = new List<Group>();
        private readonly GroupService groupService;

        public GroupController(GroupService groupService)
        {
            this.groupService = groupService;
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateGroup([FromBody] GroupModel groupModel)
        {
            if (groupModel == null)
            {
                return BadRequest("Dados do grupo inválidos");
            }

            var newGroup = new Group(groupModel.Subject, groupModel.GroupMembers, new List<Presentation>(), createdByUserId: "admin");

            groupService.AddGroup(newGroup);
            return Ok(newGroup); 
        }
    }
}