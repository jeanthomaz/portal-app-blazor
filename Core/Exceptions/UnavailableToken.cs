namespace Core.Exceptions;

public class UnavailableTokenException : Exception
{
    public UnavailableTokenException(string message) : base(message)
    {
    }
}