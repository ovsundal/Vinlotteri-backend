using Vinlotteri_backend.DTOs;

namespace Vinlotteri_backend.Services;

public interface ILotteryService
{
    Task<int> CreateLottery();
    Task<LotteryDto?> GetLotteryById(int id);
    Task<bool> BuyTicket(int lotteryId, int ticketNumber, string owner);
}