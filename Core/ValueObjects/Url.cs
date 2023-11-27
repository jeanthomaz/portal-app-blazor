namespace Core.ValueObjects;

public class Url
{
    public int Id { get; private set; }
    public string Address { get; private set;}
    public Url()
    {
    }
    
    public Url(string url)
    {
        if (!IsValid())
            throw new ArgumentException("URL inválida");

        Address = url;
    }
    
    public override string ToString()
    {
        return Address;
    }

    private bool IsValid()
    {
        // TODO: Implementar regras de validação de URL
        return true;
    }
}