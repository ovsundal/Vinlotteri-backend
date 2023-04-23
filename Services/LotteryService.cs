using Vinlotteri_backend.Data;
using Vinlotteri_backend.DTOs;
using Vinlotteri_backend.Models;

namespace Vinlotteri_backend.Services;

public class LotteryService : ILotteryService
{
    private readonly ApplicationDbContext _context;

    public LotteryService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CreateLotteryDto> CreateLottery()
    {
        // business rules for lottery here
        var lottery = new Lottery
        {
            TicketPrice = 10,
            TotalTickets = 100,
            TicketsSold = 0,
        };
        
        _context.Lotteries.Add(lottery);
        await _context.SaveChangesAsync();

        return new CreateLotteryDto
        {
            Id = lottery.Id,
            AvailableTicketsInfo = $"Available tickets: 100 / 100",
            TicketPriceInfo = $"Price per ticket: {lottery.TicketPrice},-",
            LotteryIncomeInfo = $"Lottery income: {0},-",
            SpentOnPrizesInfo = $"Spent on prices: TO BE IMPLEMENTED",
            TotalBalanceInfo = $"Total: TO BE IMPLEMENTED"
        };
    }
}