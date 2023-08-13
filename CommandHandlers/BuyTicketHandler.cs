using MediatR;
using Vinlotteri_backend.Commands;
using Vinlotteri_backend.DTOs;
using Vinlotteri_backend.Exceptions;
using Vinlotteri_backend.Services;

namespace Vinlotteri_backend.CommandHandlers;

public class BuyTicketHandler : IRequestHandler<BuyTicketCommand, LotteryDto?>
{
    private readonly ILotteryService _lotteryService;

    public BuyTicketHandler(ILotteryService lotteryService)
    {
        _lotteryService = lotteryService;
    }
    
    public async Task<LotteryDto?> Handle(BuyTicketCommand request, CancellationToken cancellationToken)
    {
        var success = await _lotteryService.BuyTicket(request.Id, request.Ticket.Number, request.Ticket.Owner);

        if (!success)
        {
            throw new FailedToBuyTicketException();
        }
        
        var lotteryDto = await _lotteryService.GetLotteryById(request.Id);

        if (lotteryDto == null)
        {
            throw new FailedToFindLotteryException();
        }
    
        return lotteryDto;
    }
}