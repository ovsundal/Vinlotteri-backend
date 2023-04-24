using System.ComponentModel.DataAnnotations;

namespace Vinlotteri_backend.Models;

public class Wine
{
    [Key] public int Id { get; init; }
    [Required] public decimal Price { get; init; }
    [Required] public string Name { get; init; }
}