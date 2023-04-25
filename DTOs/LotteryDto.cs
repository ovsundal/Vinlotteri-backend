namespace Vinlotteri_backend.DTOs;

public class LotteryDto
{
    public int Id { get; init; }
    public string AvailableTicketsInfo { get; init; }
    public string TicketPriceInfo { get; init; }
    public string LotteryIncomeInfo { get; init; }
    public string SpentOnPrizesInfo { get; init; }
    public string TotalBalanceInfo { get; init; }
    public IEnumerable<TicketDto> Tickets { get; init; }
    public IEnumerable<WineDto> Wines { get; init; }
}