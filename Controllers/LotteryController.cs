using Microsoft.AspNetCore.Mvc;
using Vinlotteri_backend.Data;
using Vinlotteri_backend.Services;

namespace Vinlotteri_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class LotteryController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ILotteryService _lotteryService;

    public LotteryController(ApplicationDbContext context, ILotteryService lotteryService)
    {
        _context = context;
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
        var lottery = await _context.Lotteries.FindAsync(id);

        if (lottery == null)
        {
            return NotFound();
        }

        return Ok(lottery);
    }
}