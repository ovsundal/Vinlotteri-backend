﻿using MediatR;
using Vinlotteri_backend.DTOs;
using Vinlotteri_backend.Exceptions;
using Vinlotteri_backend.Queries;
using Vinlotteri_backend.Services;

namespace Vinlotteri_backend.QueryHandlers;

public class GetLotteryByIdHandler : IRequestHandler<GetLotteryByIdQuery, LotteryDto>
{
    private readonly ILotteryService _lotteryService;

    public GetLotteryByIdHandler(ILotteryService lotteryService)
    {
        _lotteryService = lotteryService;
    }

    public async Task<LotteryDto> Handle(GetLotteryByIdQuery request, CancellationToken cancellationToken)
    {
        var lotteryDto = await _lotteryService.GetLotteryById(request.Id);

        if (lotteryDto == null)
        {
            throw new FailedToFindLotteryException();
        }
        
        return lotteryDto;
    }
}