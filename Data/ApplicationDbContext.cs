using Microsoft.EntityFrameworkCore;

namespace Vinlotteri_backend.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Lottery> Lotteries { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Wine> Wines { get; set; }
}