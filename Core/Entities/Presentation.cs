using Core.ValueObjects;

namespace Core.Entities;

public class Presentation
{
    public readonly Guid Id;
    public readonly string Title;
    public readonly string Description;

    /// <summary>
    /// Corpo do trabalho
    /// </summary>
    public readonly string Body;

    /// <summary>
    /// Urls de refêrencia para o trabalho.
    /// </summary>
    public readonly List<Url> References;

    /// <summary>
    /// Construtor pra ORM. Não deve ser utilizado em código.
    /// </summary>
    [Obsolete]
    public Presentation()
    {
    }

    public Presentation(string title, string description, List<Student> groupMembers, string body, List<Url> references)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        Body = body;
        References = references;
    }
}