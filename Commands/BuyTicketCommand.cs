using MediatR;
using Vinlotteri_backend.DTOs;

namespace Vinlotteri_backend.Commands;

public class BuyTicketCommand : IRequest<LotteryDto>
{
    public int Id { get; init; }
    public TicketDto Ticket { get; init; } = null!;
}
