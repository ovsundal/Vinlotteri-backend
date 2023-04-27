using Microsoft.EntityFrameworkCore;
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

    public async Task<int> CreateLottery()
    {
        var lottery = new Lottery
        {
            TicketPrice = 10,
            TotalTickets = 100,
            TicketsSold = 0,
            Wines = StaticWineDataApi.GetRandomWines(5),
            Tickets = new List<Ticket>()
        };

        _context.Lotteries.Add(lottery);
        await _context.SaveChangesAsync();

        return lottery.Id;
    }

    public async Task<LotteryDto?> GetLotteryById(int id)
    {
        var lottery = await _context.Lotteries
            .Include(lottery => lottery.Tickets)
            .Include(lottery => lottery
                .Wines.OrderBy(wine => wine.Price))
            .FirstOrDefaultAsync(lottery => lottery.Id == id);

        if (lottery == null)
        {
            return null;
        }

        var ticketDtos = lottery.Tickets.Select(ticket => new TicketDto
        {
            Number = ticket.Number,
            Owner = ticket.Owner,
            HasWon = ticket.HasWon
        });

        var wineDtos = lottery.Wines.Select(wine => new WineDto
        {
            Id = wine.Id,
            Price = wine.Price,
            Name = wine.Name,
            HasBeenAwarded = wine.HasBeenAwarded
        });
        
        var totalWinePrice = lottery.Wines.Sum(wine => wine.Price);
        var lotteryIncome = lottery.TicketsSold * lottery.TicketPrice;
        
        return new LotteryDto
        {
            Id = lottery.Id,
            AvailableTicketsInfo = $"Available tickets: {LotteryCalculator.CalculateAvailableTickets(lottery.TotalTickets, lottery.TicketsSold)} / 100",
            TicketPriceInfo = $"Price per ticket: {lottery.TicketPrice},-",
            LotteryIncomeInfo = $"Lottery income: {lotteryIncome},-",
            SpentOnPrizesInfo = $"Spent on prizes: {totalWinePrice},-",
            TotalBalanceInfo = $"Total: {LotteryCalculator.CalculateLotteryBalance(lotteryIncome, totalWinePrice)},-",
            Tickets = ticketDtos,
            Wines = wineDtos
        };
    }

    public async Task<bool> BuyTicket(int lotteryId, int ticketNumber, string owner)
    {
        var lottery = await _context.Lotteries.FindAsync(lotteryId);

        if (lottery == null)
        {
            return false;
        }

        var ticket = new Ticket()
        {
            Number = ticketNumber,
            Owner = owner,
            HasWon = false,
            LotteryId = lotteryId
        };

        lottery.AddTicket(ticket);
        lottery.TicketsSold++;

        await _context.SaveChangesAsync();

        return true;
    }
}