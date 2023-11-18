using Core.Entities;

namespace Core.DTOs;

public class GroupDto
{
    public List<StudentDto> GroupMembers { get; set; }

    public GroupDto()
    {
    }

    public GroupDto(Group group)
    {
        GroupMembers = group.GroupMembers
            .Select(gm => new StudentDto() { Name = gm.Name, Role = gm.Role })
            .ToList();
    }

    public Group ToGroup()
    {
        var groupMembers = GroupMembers.Select(gm => gm.ToStudent()).ToList();

        return new() { GroupMembers = groupMembers };
    }
}