using MediatR;
using Vinlotteri_backend.DTOs;

namespace Vinlotteri_backend.Commands;

public class CreateLotteryCommand : IRequest<LotteryDto>
{
    public int Id { get; init; }
}