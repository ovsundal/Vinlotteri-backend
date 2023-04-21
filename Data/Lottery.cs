namespace Vinlotteri_backend.Data;

public class Lottery
{
    public int Id { get; init; }
    public decimal TicketPrice { get; init; }
    public int TotalTickets { get; init; }
    public int TicketsSold { get; init; }
}