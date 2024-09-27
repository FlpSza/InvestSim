    namespace InvestmentSimulator.Context;
    using Microsoft.EntityFrameworkCore;
    using InvestmentSimulator.Models;

public class InvestmentSimulatorContext : DbContext
{
    public InvestmentSimulatorContext(DbContextOptions<InvestmentSimulatorContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Asset> Assets { get; set; }
}
