﻿using Microsoft.EntityFrameworkCore;
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

        return new CreateLotteryDto
        {
            Id = lottery.Id,
            AvailableTicketsInfo = $"Available tickets: 100 / 100",
            TicketPriceInfo = $"Price per ticket: {lottery.TicketPrice},-",
            LotteryIncomeInfo = $"Lottery income: {0},-",
            SpentOnPrizesInfo = $"Spent on prizes: TO BE IMPLEMENTED",
            TotalBalanceInfo = $"Total: TO BE IMPLEMENTED",
            Tickets = new List<TicketDto>(),
            Wines = lottery.Wines.Select(wine => new WineDto
            {
                Id = wine.Id,
                Price = wine.Price,
                Name = wine.Name,
                HasBeenAwarded = wine.HasBeenAwarded
            })
        };
    }

    public async Task<GetLotteryDto?> GetLotteryById(int id)
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

        return new GetLotteryDto
        {
            Id = lottery.Id,
            AvailableTicketsInfo = $"Available tickets: {lottery.TotalTickets - lottery.TicketsSold} / 100",
            TicketPriceInfo = $"Price per ticket: {lottery.TicketPrice},-",
            LotteryIncomeInfo = $"Lottery income: {lottery.TicketsSold * lottery.TicketPrice},-",
            SpentOnPrizesInfo = $"Spent on prizes: TO BE IMPLEMENTED",
            TotalBalanceInfo = $"Total: TO BE IMPLEMENTED",
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