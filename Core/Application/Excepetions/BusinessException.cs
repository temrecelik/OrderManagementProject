namespace Application.Excepetions;

public class BusinessException : Exception
{
    public BusinessException(string message) : base(message)
    { }
}