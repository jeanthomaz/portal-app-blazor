namespace Core.Entities;

public class Group
{
    public readonly Guid Id;
    public readonly List<Presentation> Presentations;
    public readonly List<Student> GroupMembers;
    public readonly string Subject;
    public readonly Guid PrivateKey;

    /// <summary>
    /// Construtor pra ORM. Não deve ser utilizado em código.
    /// </summary>
    [Obsolete]
    public Group()
    {
    }
    
    public Group(string subject, List<Student> groupMembers, List<Presentation> presentations)
    {
        Id = Guid.NewGuid();
        Subject = subject;
        GroupMembers = groupMembers;
        Presentations = presentations;
        PrivateKey = Guid.NewGuid();
    }
}