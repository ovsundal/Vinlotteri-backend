namespace Vinlotteri_backend.Models;

public class Ticket
{
    public int Id { get; init; }
    public int Number { get; init; }
    public string Owner { get; init; } = string.Empty;
    public bool HasWon { get; init; }
}