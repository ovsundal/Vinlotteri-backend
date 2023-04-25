namespace Vinlotteri_backend.DTOs;

public class TicketDto
{
    public int Number { get; set; }
    public string Owner { get; set; }
    public bool HasWon { get; init; }
}