using MediatR;
using Vinlotteri_backend.Commands;
using Vinlotteri_backend.DTOs;
using Vinlotteri_backend.Exceptions;
using Vinlotteri_backend.Services;

namespace Vinlotteri_backend.CommandHandlers;

public class DrawWinnerHandler : IRequestHandler<DrawWinnerCommand, LotteryDto?>
{
    private readonly ILotteryService _lotteryService;

    public DrawWinnerHandler(ILotteryService lotteryService)
    {
        _lotteryService = lotteryService;
    }
    
    public async Task<LotteryDto?> Handle(DrawWinnerCommand request, CancellationToken cancellationToken)
    {
        var success = await _lotteryService.DrawWinner(request.LotteryId, request.WineId);

        if (!success)
        {
            throw new FailedToDrawWinnerException();
        }
    
        return await _lotteryService.GetLotteryById(request.LotteryId);
    }
}