﻿using Vinlotteri_backend.DTOs;

namespace Vinlotteri_backend.Services;

public interface ILotteryService
{
    Task<LotteryDto> CreateLottery();
    Task<LotteryDto?> GetLotteryById(int id);
}