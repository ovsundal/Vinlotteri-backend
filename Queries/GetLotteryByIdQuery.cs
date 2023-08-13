using MediatR;
using Vinlotteri_backend.DTOs;

namespace Vinlotteri_backend.Queries;

public class GetLotteryByIdQuery : IRequest<LotteryDto>
{
    public int Id { get; init; }
}