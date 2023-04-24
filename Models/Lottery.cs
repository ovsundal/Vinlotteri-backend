using System.ComponentModel.DataAnnotations;

namespace Vinlotteri_backend.Models;

public class Lottery
{
    [Key] public int Id { get; init; }
    [Required] public decimal TicketPrice { get; init; }
    [Required] public int TotalTickets { get; init; }
    [Required] public int TicketsSold { get; set; }
    [Required] public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    [Required] public ICollection<Wine> Wines { get; set; } = new List<Wine>();
    
    public async Task AddTicket(Ticket ticket)
    {
        // Check if ticket already exists
        if (Tickets.Any(t => t.Number == ticket.Number))
        {
            throw new Exception("Ticket already registered");
        }

        Tickets.Add(ticket);
    }
}