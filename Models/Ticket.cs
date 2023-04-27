using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vinlotteri_backend.Models;

public class Ticket
{
    [Key] public int Id { get; init; }
    [Required] public int Number { get; set; }
    [Required] public string Owner { get; set; } = string.Empty;
    [Required] public bool HasWon { get; init; }
    [ForeignKey("Lottery")] public int LotteryId { get; set; }
    public Lottery Lottery { get; set; }
}