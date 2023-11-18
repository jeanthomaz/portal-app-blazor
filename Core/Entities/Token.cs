namespace Core.Entities;

public class Token
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid? ProjectId { get; }
    
    public Token()
    {
    }
}