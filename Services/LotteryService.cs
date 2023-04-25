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
            SpentOnPrizesInfo = $"Spent on prizes: TO BE IMPLEMENTED",
            TotalBalanceInfo = $"Total: TO BE IMPLEMENTED"
        };
    }

    public async Task<GetLotteryDto?> GetLotteryById(int id)
    {
        var lottery = await _context.Lotteries
            .Include(lottery => lottery.Tickets)
            .FirstOrDefaultAsync(lottery => lottery.Id == id);

        if (lottery == null)
        {
            return null;
        }

        var tickets = lottery.Tickets.Select(ticket => new TicketDto
        {
            Number = ticket.Number,
            Owner = ticket.Owner,
            HasWon = ticket.HasWon
        });

        return new GetLotteryDto
        {
            Id = lottery.Id,
            AvailableTicketsInfo = $"Available tickets: {lottery.TotalTickets - lottery.TicketsSold} / 100",
            TicketPriceInfo = $"Price per ticket: {lottery.TicketPrice},-",
            LotteryIncomeInfo = $"Lottery income: {lottery.TicketsSold * lottery.TicketPrice},-",
            SpentOnPrizesInfo = $"Spent on prizes: TO BE IMPLEMENTED",
            TotalBalanceInfo = $"Total: TO BE IMPLEMENTED",
            Tickets = tickets
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