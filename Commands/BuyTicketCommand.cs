using MediatR;
using Vinlotteri_backend.DTOs;

namespace Vinlotteri_backend.Commands;

public class BuyTicketCommand : IRequest<LotteryDto>
{
    public required int Id { get; init; }
    public required TicketDto Ticket { get; init; } = null!;
}
