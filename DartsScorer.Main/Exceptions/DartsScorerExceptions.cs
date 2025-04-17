namespace DartsScorer.Main.Exceptions;

/// <summary>
/// Base exception class for the DartsScorer application
/// </summary>
public abstract class DartsScorerException : Exception
{
    protected DartsScorerException(string message) : base(message)
    {
    }
    
    protected DartsScorerException(string message, Exception innerException) : base(message, innerException)
    {
    }
}

/// <summary>
/// Exception thrown when a match operation fails
/// </summary>
public class MatchOperationException : DartsScorerException
{
    public MatchOperationException(string message) : base(message)
    {
    }
    
    public MatchOperationException(string message, Exception innerException) : base(message, innerException)
    {
    }
}

/// <summary>
/// Exception thrown when a player operation fails
/// </summary>
public class PlayerOperationException : DartsScorerException
{
    public PlayerOperationException(string message) : base(message)
    {
    }
    
    public PlayerOperationException(string message, Exception innerException) : base(message, innerException)
    {
    }
}

/// <summary>
/// Exception thrown when a throw is invalid
/// </summary>
public class InvalidThrowException : DartsScorerException
{
    public InvalidThrowException(string message) : base(message)
    {
    }
    
    public InvalidThrowException(string message, Exception innerException) : base(message, innerException)
    {
    }
}