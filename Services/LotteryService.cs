using Microsoft.EntityFrameworkCore;
using Vinlotteri_backend.Data;
using Vinlotteri_backend.DTOs;
using Vinlotteri_backend.Exceptions;
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

        var wineDtos = lottery.Wines
            .Select(wine => new WineDto
        {
            Id = wine.Id,
            Price = wine.Price,
            Name = wine.Name,
            WonBy = wine.WonBy
        })
            .OrderBy(wine => wine.Price);
        
        var totalWinePrice = lottery.Wines.Sum(wine => wine.Price);
        var lotteryIncome = LotteryCalculator.CalculateLotteryIncome(lottery.TicketsSold, lottery.TicketPrice);
        
        return new LotteryDto
        {
            Id = lottery.Id,
            AvailableTicketsInfo = $"Available tickets: {LotteryCalculator.CalculateAvailableTickets(lottery.TotalTickets, lottery.TicketsSold)} / 100",
            TicketPriceInfo = $"Price per ticket: {lottery.TicketPrice},-",
            LotteryIncomeInfo = $"Lottery income: {lotteryIncome},-",
            SpentOnPrizesInfo = $"Spent on prizes: {totalWinePrice},-",
            TotalBalanceInfo = $"Total: {LotteryCalculator.CalculateLotteryBalance(lotteryIncome, totalWinePrice)},-",
            Tickets = ticketDtos,
            Wines = wineDtos,
            NextWineToAward = wineDtos.FirstOrDefault(wine => string.IsNullOrWhiteSpace(wine.WonBy))
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

    public async Task<bool> DrawWinner(int lotteryId, int wineId)
    {
        var lottery = await _context.Lotteries    
            .Include(lottery => lottery.Tickets)
            .Include(lottery => lottery
                .Wines.OrderBy(wine => wine.Price))
            .FirstOrDefaultAsync(lottery => lottery.Id == lotteryId);
        
        if (lottery == null)
        {
            return false;
        }

        var wineToAward = lottery.Wines.FirstOrDefault(wine => wine.Id == wineId);
        var availableCandidates = lottery.Tickets
            .Where(ticket => !ticket.HasWon)
            .ToList();

        if (availableCandidates.Count() == 0)
        {
            throw new NoAvailableCandidatesException();
        }

        var randomIndex = new Random().Next(availableCandidates.Count());
        var selectedTicket = availableCandidates[randomIndex];
        selectedTicket.HasWon = true;
        wineToAward.WonBy = selectedTicket.Owner;

        await _context.SaveChangesAsync();

        return true;
    }
}