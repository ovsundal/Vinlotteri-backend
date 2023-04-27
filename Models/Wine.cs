using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vinlotteri_backend.Models;

public class Wine
{
    [Key] public int Id { get; init; }
    [Required] public decimal Price { get; init; }
    [Required] public string Name { get; init; }
    [Required] public string WonBy { get; set; }
    [ForeignKey("Lottery")] public int LotteryId { get; set; }
    public Lottery Lottery { get; set; }
}