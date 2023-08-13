namespace Vinlotteri_backend.DTOs;

public class WineDto
{
    public int Id { get; init; }
    public decimal Price { get; init; }
    public string Name { get; init; } = null!;
    public string WonBy { get; init; } = null!;
}