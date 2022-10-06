using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Wizards.Core.Model.UserModels;
using Wizards.Core.Model.UserModels.Properties;
using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.Properties;
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
    public DbSet<Skill> Skills { get; set; }
    public DbSet<HeroSkill> HeroSkills { get; set; }
    public DbSet<Enemy> Enemies { get; set; }
    public DbSet<EnemyAttributes> EnemiesAttributes { get; set; }
    public DbSet<EnemySkill> EnemiesSkills { get; set; }
    public DbSet<BehaviorPattern> BehaviorPatterns { get; set; }
    
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

        //modelBuilder.DataSeed();
    }
}