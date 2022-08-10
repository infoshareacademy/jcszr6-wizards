using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Wizards.Core.Model;
using Wizards.Core.Model.ManyToManyTables;
using Wizards.Repository.DbConfiguration;
using Wizards.Repository.InitialData;

namespace Wizards.Repository
{
    public class WizardsContext : IdentityDbContext<Player, IdentityRole<int>, int>
    {

        private readonly bool _useLazyLoading;
        private readonly IInitialDataInjector _initialDataInjector;

        public WizardsContext()
        {
        }

        public WizardsContext(bool useLazyLoading)
        {
            _useLazyLoading = useLazyLoading;
        }
        public WizardsContext(DbContextOptions<WizardsContext> options, IInitialDataInjector initialDataInjector) : base(options)
        {
            _initialDataInjector = initialDataInjector;
        }

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

            if (_useLazyLoading)
            {
                //optionsBuilder.UseLazyLoadingProxies();
            }

            optionsBuilder
                .UseSqlServer("Server=localhost; Database=WizardsDB; Trusted_Connection=True; MultipleActiveResultSets=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ConfigureEntities();

            _initialDataInjector.InjectGameDataAsync(modelBuilder);
        }
    }

}
