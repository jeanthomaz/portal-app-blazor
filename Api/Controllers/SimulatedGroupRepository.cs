using System;
using System.Collections.Generic;
using APIPortal.DTOs;


namespace MinhaApi.Controllers
{
    public class SimulatedGroupRepository
    {
        private List<GroupDTO> _groups = new List<GroupDTO>();

        public IEnumerable<GroupDTO> GetAllGroups()
        {
            return _groups;
        }

        public GroupDTO GetGroupById(Guid id)
        {
            return _groups.Find(group => group.Id == id);
        }

        public void AddGroup(GroupDTO group)
        {
            group.Id = Guid.NewGuid();
            _groups.Add(group);
        }

        public void UpdateGroup(GroupDTO updatedGroup)
        {
            var existingGroup = _groups.Find(group => group.Id == updatedGroup.Id);
            if (existingGroup != null)
            {
                existingGroup.Subject = updatedGroup.Subject;
                existingGroup.GroupMembers = updatedGroup.GroupMembers;
                existingGroup.Presentations = updatedGroup.Presentations;
            }
        }

        public void DeleteGroup(Guid id)
        {
            var groupToRemove = _groups.Find(group => group.Id == id);
            if (groupToRemove != null)
            {
                _groups.Remove(groupToRemove);
            }
        }
    }
}
