using Microsoft.AspNetCore.Mvc;
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

    [HttpGet]
    public async Task<IActionResult> CreateLottery()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var lotteryDto = await _lotteryService.CreateLottery();

        return CreatedAtAction(nameof(GetLottery), new { id = lotteryDto.Id }, lotteryDto);
    }
    
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
    
    [HttpPut("{id}")]
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
}