namespace Core.Entities;

public class Student
{
    public int Id { get; private set; }
    
    public string Name { get; private set; }

    public string Role { get; private set; }
    public int GroupId { get; set; } 

    public Group Group { get; set; }

    [Obsolete]
    public Student()
    {
    }

    public Student(string name, string role)
    {
        Name = name;
        Role = role;
    }
}