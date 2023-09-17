using Core.ValueObjects;

namespace Core.Entities;

public class Presentation
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }

    /// <summary>
    /// Corpo do trabalho
    /// </summary>
    public string Body { get; private set; }

    /// <summary>
    /// Urls de refêrencia para o trabalho.
    /// </summary>
    public List<Url> References { get; private set; }
    
    public bool IsDeleted { get; private set; }

    /// <summary>
    /// Construtor pra ORM. Não deve ser utilizado em código.
    /// </summary>
    [Obsolete]
    public Presentation()
    {
    }

    public Presentation(string title, string description, List<Student> groupMembers, string body, List<Url> references)
    {
        Title = title;
        Description = description;
        Body = body;
        References = references;
    }
    
    public void SoftDelete() => IsDeleted = true;
}