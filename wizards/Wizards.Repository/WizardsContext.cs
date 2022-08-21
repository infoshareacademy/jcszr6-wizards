using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Wizards.Core.Model;
using Wizards.Core.Model.Properties;
using Wizards.Repository.DbConfiguration;

namespace Wizards.Repository;

public class WizardsContext : IdentityDbContext<Player, IdentityRole<int>, int>
{

    private readonly bool _useLazyLoading;

    public WizardsContext() { }
    public WizardsContext(DbContextOptions<WizardsContext> options) : base(options) { }
    public WizardsContext(bool useLazyLoading) { _useLazyLoading = useLazyLoading; }

    public DbSet<Player> Players { get; set; }
    public DbSet<Hero> Heroes { get; set; }
    public DbSet<HeroAttributes> HeroAttributes { get; set; }
    public DbSet<Statistics> Statistics { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<ItemAttributes> ItemAttributes { get; set; }
    public DbSet<HeroItem> HeroItems { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder
            .UseSqlServer("Server=localhost; Database=WizardsDB; Trusted_Connection=True; MultipleActiveResultSets=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureEntities();

        modelBuilder.DataSeed();
    }
}