using Core.ValueObjects;

namespace Core.Entities;

public class Project
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid PrivateToken { get; private set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string TextBody { get; set; }
    public List<Url> References { get; set; }
    public Group Group { get; set; }
    public bool IsDeleted { get; set; }
    
    public Project()
    {
    }
    
    public Project(string name, string description, string textBody, List<Url> references, Group group)
    {
        Name = name;
        Description = description;
        TextBody = textBody;
        References = references;
        Group = group;
    }
    
    public void AssignPrivateToken(Guid privateToken)
    {
        PrivateToken = privateToken;
    }
    
    public void AddReference(Url url)
    {
        if (References.Contains(url))
            throw new Exception($"A referência {url} já existe.");
        
        References.Add(url);
    }
    
    public void RemoveReference(Url url)
    {
        if (!References.Contains(url))
            throw new Exception($"A referência {url} não existe.");
        
        References.Remove(url);
    }
}