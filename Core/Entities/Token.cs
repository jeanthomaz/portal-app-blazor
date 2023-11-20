namespace Core.Entities;

public class Token
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid? ProjectId { get; set; }
    
    public Token()
    {
    }
}