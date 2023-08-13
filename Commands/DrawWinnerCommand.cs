using MediatR;
using Vinlotteri_backend.DTOs;

namespace Vinlotteri_backend.Commands;

public class DrawWinnerCommand : IRequest<LotteryDto>
{
    public required int LotteryId { get; init; }
    public required int WineId { get; init; }
}