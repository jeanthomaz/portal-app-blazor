using Core.Entities;

namespace Core.DTOs;

public class StudentDto
{
    public string Name { get; set; }
    public string Role { get; set; }
    
    public Student ToStudent()
    {
        return new(Name, Role);
    }
}