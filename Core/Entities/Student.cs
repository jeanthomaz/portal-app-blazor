namespace Core.Entities;

public class Student
{
    public int Id { get; private set; }
    public string Name { get; set; }
    public string Role { get; set; }


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