using MediatR;
using Vinlotteri_backend.Commands;
using Vinlotteri_backend.DTOs;
using Vinlotteri_backend.Exceptions;
using Vinlotteri_backend.Services;

namespace Vinlotteri_backend.CommandHandlers;

public class CreateLotteryHandler : IRequestHandler<CreateLotteryCommand, LotteryDto?>
{
    private readonly ILotteryService _lotteryService;

    public CreateLotteryHandler(ILotteryService lotteryService)
    {
        _lotteryService = lotteryService;
    }
    
    public async Task<LotteryDto?> Handle(CreateLotteryCommand request, CancellationToken cancellationToken)
    {
        var lotteryId = await _lotteryService.CreateLottery();
        var lotteryDto = await _lotteryService.GetLotteryById(lotteryId);

        if (lotteryDto == null)
        {
            throw new FailedToFindLotteryException();
        }
    
        return lotteryDto;
    }
}
