using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Vinlotteri_backend.Commands;
using Vinlotteri_backend.DTOs;
using Vinlotteri_backend.Queries;

namespace Vinlotteri_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class LotteryController : ControllerBase
{
    private readonly IMediator _mediator;

    public LotteryController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [SwaggerOperation(Summary = "Create a new lottery")]
    [HttpGet]
    public async Task<IActionResult> CreateLottery()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var command = new CreateLotteryCommand();
        var lotteryDto = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetLotteryById), new { id = lotteryDto.Id }, lotteryDto);
    }
    
    [SwaggerOperation(Summary = "Get details of a specific lottery by ID")]
    [HttpGet("{id}")]
    
    public async Task<IActionResult> GetLotteryById(int id)
    {
        var query = new GetLotteryByIdQuery
        {
            Id = id
        };
        var lotteryDto = await _mediator.Send(query);

        return Ok(lotteryDto);
    }
    
    [SwaggerOperation(Summary = "Purchase a ticket for a specific lottery")]
    [HttpPost("{id}")]
    public async Task<IActionResult> BuyTicket(int id, [FromBody] TicketDto ticket)
    {
        if (string.IsNullOrWhiteSpace(ticket.Owner))
        {
            throw new ArgumentException("Ticket owner cannot be empty");
        }

        var command = new BuyTicketCommand
        {
            Id = id,
            Ticket = ticket
        };
        var lotteryDto = await _mediator.Send(command);
    
        return Ok(lotteryDto);
    }
    
    [SwaggerOperation(Summary = "Draw a winner for a specific wine in a lottery")]
    [HttpGet("{lotteryId}/{wineId}")]
    public async Task<IActionResult> DrawWinner(int lotteryId, int wineId)
    {
        var command = new DrawWinnerCommand
        {
            LotteryId = lotteryId,
            WineId = wineId
        };
        var lotteryDto = await _mediator.Send(command);

        return Ok(lotteryDto);
    }
}