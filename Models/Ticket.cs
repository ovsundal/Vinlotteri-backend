using System.ComponentModel.DataAnnotations;

namespace Vinlotteri_backend.Models;

public class Ticket
{
    [Key] public int Id { get; init; }
    [Required] public int Number { get; init; }
    [Required] public string Owner { get; init; } = string.Empty;
    [Required] public bool HasWon { get; init; }
}