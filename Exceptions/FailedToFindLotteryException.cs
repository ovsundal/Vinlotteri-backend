namespace Vinlotteri_backend.Exceptions;

public class FailedToFindLotteryException : Exception
{
    public FailedToFindLotteryException() : base("Could not find the lottery")
    {
    }
}