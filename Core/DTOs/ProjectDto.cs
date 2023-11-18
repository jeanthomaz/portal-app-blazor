using Core.Entities;
using Core.ValueObjects;

namespace Core.DTOs;

public class ProjectDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string TextBody { get; set; }
    public List<string> References { get; set; }
    public GroupDto Group { get; set; }
    
    public ProjectDto()
    {
    }
    
    public Project ToProject()
    {
        return new(Name, Description, TextBody, References.Select(r => new Url(r)).ToList(), Group.ToGroup());
    }
}