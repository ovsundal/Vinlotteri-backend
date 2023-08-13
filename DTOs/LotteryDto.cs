namespace Vinlotteri_backend.DTOs;

public class LotteryDto
{
    public int Id { get; init; }
    public string AvailableTicketsInfo { get; init; } = null!;
    public string TicketPriceInfo { get; init; } = null!;
    public string LotteryIncomeInfo { get; init; } = null!;
    public string SpentOnPrizesInfo { get; init; } = null!;
    public string TotalBalanceInfo { get; init; } = null!;
    public IEnumerable<TicketDto> Tickets { get; init; } = null!;
    public IEnumerable<WineDto> Wines { get; init; } = null!;
    public WineDto? NextWineToAward { get; init; }
}