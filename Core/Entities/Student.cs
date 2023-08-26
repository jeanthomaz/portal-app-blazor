namespace Core.Entities;

public class Student
{
    public readonly Guid Id;
    
    /// <summary>
    /// Nome completo
    /// </summary>
    public readonly string Name;

    /// <summary>
    /// Papel no trabalho. Ex: "Desenvolvedor", "Analista", etc.
    /// </summary>
    public readonly string Role;


    /// <summary>
    /// Construtor pra ORM. Não deve ser utilizado em código.
    /// </summary>
    [Obsolete]
    public Student()
    {
    }

    public Student(string name, string role)
    {
        Id = Guid.NewGuid();
        Name = name;
        Role = role;
    }
}