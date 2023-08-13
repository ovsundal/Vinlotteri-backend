namespace Vinlotteri_backend.Exceptions;

public class FailedToDrawWinnerException : Exception
{
    public FailedToDrawWinnerException() : base("Failed to draw a winner")
    {
    }
}