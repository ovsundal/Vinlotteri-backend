namespace Vinlotteri_backend.Exceptions;

public class NoAvailableCandidatesException : Exception
{
    public NoAvailableCandidatesException() : base("No available candidates found.")
    {
    }
}