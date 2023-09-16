namespace Core.Entities;

public class Student
{
    public int Id { get; private set; }
    
    /// <summary>
    /// Nome completo
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Papel no trabalho. Ex: "Desenvolvedor", "Analista", etc.
    /// </summary>
    public string Role { get; private set; }


    /// <summary>
    /// Construtor pra ORM. Não deve ser utilizado em código.
    /// </summary>
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