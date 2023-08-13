namespace Vinlotteri_backend.DTOs;

public class TicketDto
{
    public int Number { get; init; }
    public string Owner { get; init; } = null!;
    public bool HasWon { get; init; }
}