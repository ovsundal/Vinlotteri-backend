namespace Vinlotteri_backend.Services;

public static class LotteryCalculator
{
    public static int CalculateAvailableTickets(int totalTickets, int ticketsSold) => totalTickets - ticketsSold;
    public static decimal CalculateLotteryBalance(decimal ticketSoldIncome, decimal prizeCost) => ticketSoldIncome - prizeCost;
}