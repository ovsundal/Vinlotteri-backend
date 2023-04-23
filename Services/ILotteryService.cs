using Vinlotteri_backend.DTOs;

namespace Vinlotteri_backend.Services;

public interface ILotteryService
{
    Task<CreateLotteryDto> CreateLottery();
}