namespace Blog.Api.Exceptions;

public class ErrorException : Exception
{
    public int _statusCode { get; }
    public ErrorException(int statusCode, string errorMessage) : base(errorMessage)
    {
        _statusCode = statusCode;
    }
}