using System.ComponentModel.DataAnnotations;

namespace Vinlotteri_backend.Data;

public class Lottery
{
    [Key] public int Id { get; init; }
    [Required] public decimal TicketPrice { get; init; }
    [Required] public int TotalTickets { get; init; }
    [Required] public int TicketsSold { get; init; }
    public ICollection<Ticket> Tickets { get; set; }
}