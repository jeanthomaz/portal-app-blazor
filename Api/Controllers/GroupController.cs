using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using APIPortal.DTOs;

namespace MinhaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly SimulatedGroupRepository _groupRepository;

        public GroupController()
        {
            _groupRepository = new SimulatedGroupRepository();
        }

        [HttpGet]
        public IActionResult GetAllGroups()
        {
            var groups = _groupRepository.GetAllGroups();
            return Ok(groups);
        }

        [HttpGet("{id}")]
        public IActionResult GetGroupById(Guid id)
        {
            var group = _groupRepository.GetGroupById(id);
            if (group == null)
                return NotFound();

            return Ok(group);
        }

        [HttpPost]
        public IActionResult CreateGroup([FromBody] GroupDTO groupDTO)
        {
            _groupRepository.AddGroup(groupDTO);
            return CreatedAtAction(nameof(GetGroupById), new { id = groupDTO.Id }, groupDTO);
        }
    }
}

