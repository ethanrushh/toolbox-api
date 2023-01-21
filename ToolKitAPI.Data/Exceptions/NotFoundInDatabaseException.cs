namespace ToolKitAPI.Core.Exceptions;

public class NotFoundInDatabaseException : Exception
{
    public NotFoundInDatabaseException() {}
    
    public NotFoundInDatabaseException(string message) : base(message) { }
    
    public NotFoundInDatabaseException(string message, Exception innerException) : base(message, innerException) { }
}
