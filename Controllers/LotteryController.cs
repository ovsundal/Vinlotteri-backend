using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Vinlotteri_backend.DTOs;
using Vinlotteri_backend.Services;

namespace Vinlotteri_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class LotteryController : ControllerBase
{
    private readonly ILotteryService _lotteryService;

    public LotteryController(ILotteryService lotteryService)
    {
        _lotteryService = lotteryService;
    }

    [SwaggerOperation(Summary = "Create a new lottery")]
    [HttpGet]
    public async Task<IActionResult> CreateLottery()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var lotteryId = await _lotteryService.CreateLottery();
        
        var lotteryDto = await _lotteryService.GetLotteryById(lotteryId);

        return CreatedAtAction(nameof(GetLottery), new { id = lotteryDto.Id }, lotteryDto);
    }
    
    [SwaggerOperation(Summary = "Get details of a specific lottery by ID")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetLottery(int id)
    {
        var lotteryDto = await _lotteryService.GetLotteryById(id);

        if (lotteryDto == null)
        {
            return NotFound();
        }
        
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
        var success = await _lotteryService.BuyTicket(id, ticket.Number, ticket.Owner);

        if (!success)
        {
            return NotFound();
        }
        
        var lotteryDto = await _lotteryService.GetLotteryById(id);
        if (lotteryDto == null)
        {
            return NotFound();
        }
    
        return Ok(lotteryDto);
    }
    
    [SwaggerOperation(Summary = "Draw a winner for a specific wine in a lottery")]
    [HttpGet("{lotteryId}/{wineId}")]
    public async Task<IActionResult> DrawWinner(int lotteryId, int wineId)
    {
        var success = await _lotteryService.DrawWinner(lotteryId, wineId);

        if (!success)
        {
            return NotFound();
        }
    
        var lotteryDto = await _lotteryService.GetLotteryById(lotteryId);
        if (lotteryDto == null)
        {
            return NotFound();
        }

        return Ok(lotteryDto);
    }
}