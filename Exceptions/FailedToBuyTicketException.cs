namespace Vinlotteri_backend.Exceptions;

public class FailedToBuyTicketException : Exception
{
        public FailedToBuyTicketException() : base("Failed to buy ticket")
    {
    }
} 