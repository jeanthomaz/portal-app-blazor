namespace Core.ValueObjects;

public class Url
{
    private readonly string _url;

    public Url(string url)
    {
        if (!IsValid())
            throw new ArgumentException("URL inválida");

        _url = url;
    }

    public override string ToString()
    {
        return _url;
    }

    private bool IsValid()
    {
        // TODO: Implementar regras de validação de URL
        return true;
    }
}