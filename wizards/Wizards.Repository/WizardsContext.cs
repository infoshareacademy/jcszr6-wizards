using Microsoft.EntityFrameworkCore;
using Wizards.Core.Model;
using Wizards.Core.Model.ManyToManyTables;

namespace Wizards.Repository
{
    public class WizardsContext : DbContext
    {

        private readonly bool _useLazyLoading;

        public WizardsContext()
        {
        }

        public WizardsContext(bool useLazyLoading)
        {
            _useLazyLoading = useLazyLoading;
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

            modelBuilder.Entity<Player>()
                .Property(p => p.Id);
            modelBuilder.Entity<Player>()
                .Property(p => p.UserName)
                .HasMaxLength(maxLength: 30)
                .IsRequired();
            modelBuilder.Entity<Player>()
                .HasIndex(p => p.UserName)
                .IsUnique();
            modelBuilder.Entity<Player>()
                .Property(p => p.Password)
                .HasMaxLength(50);
            modelBuilder.Entity<Player>()
                .Property(p => p.Email)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Player>()
                .HasIndex(p => p.Email)
                .IsUnique();
            modelBuilder.Entity<Player>()
                .Property(p => p.DateOfBirth)
                .HasColumnType("date")
                .IsRequired();
            modelBuilder.Entity<Player>()
                .HasMany(p => p.Heroes)
                .WithOne(h => h.Player)
                .HasForeignKey(h => h.PlayerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Hero>()
                .Property(h => h.Id);
            modelBuilder.Entity<Hero>()
                .Property(h => h.NickName)
                .HasMaxLength(maxLength: 20)
                .IsRequired();
            modelBuilder.Entity<Hero>()
                .HasIndex(h => h.NickName)
                .IsUnique();
            modelBuilder.Entity<Hero>()
                .Property(h => h.Profession)
                .IsRequired();
            modelBuilder.Entity<Hero>()
                .Property(h => h.AvatarImageNumber)
                .IsRequired();
            modelBuilder.Entity<Hero>()
                .Property(h => h.Gold)
                .IsRequired()
                .HasDefaultValue(0);
            modelBuilder.Entity<Hero>()
                .HasOne(h => h.Attributes)
                .WithOne(ha => ha.Hero)
                .HasForeignKey<Hero>(ha => ha.AttributesId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Hero>()
                .HasOne(h => h.Statistics)
                .WithOne(s => s.Hero)
                .HasForeignKey<Hero>(s => s.StatisticsId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HeroAttributes>()
                .HasKey(ha => ha.Id);
            modelBuilder.Entity<HeroAttributes>()
                .Property(ha => ha.DailyRewardEnergy)
                .IsRequired();
            modelBuilder.Entity<HeroAttributes>()
                .Property(ha => ha.Damage)
                .IsRequired();
            modelBuilder.Entity<HeroAttributes>()
                .Property(ha => ha.Precision)
                .IsRequired();
            modelBuilder.Entity<HeroAttributes>()
                .Property(ha => ha.Specialization)
                .IsRequired();
            modelBuilder.Entity<HeroAttributes>()
                .Property(ha => ha.MaxHealth)
                .IsRequired();
            modelBuilder.Entity<HeroAttributes>()
                .Property(ha => ha.CurrentHealth)
                .IsRequired();
            modelBuilder.Entity<HeroAttributes>()
                .Property(ha => ha.Reflex)
                .IsRequired();
            modelBuilder.Entity<HeroAttributes>()
                .Property(ha => ha.Defense)
                .IsRequired();

            modelBuilder.Entity<Statistics>()
                .HasKey(s => s.Id);
            modelBuilder.Entity<Statistics>()
                .Property(s => s.RankPoints)
                .IsRequired()
                .HasDefaultValue(0);
            modelBuilder.Entity<Statistics>()
                .Property(s => s.TotalMatchPlayed)
                .IsRequired()
                .HasDefaultValue(0);
            modelBuilder.Entity<Statistics>()
                .Property(s => s.TotalMatchWin)
                .IsRequired()
                .HasDefaultValue(0);
            modelBuilder.Entity<Statistics>()
                .Property(s => s.TotalMatchLoose)
                .IsRequired()
                .HasDefaultValue(0);


            modelBuilder.Entity<Item>()
                .Property(i => i.Id);
            modelBuilder.Entity<Item>()
                .Property(i => i.Name)
                .HasMaxLength(maxLength: 20)
                .IsRequired();
            modelBuilder.Entity<Item>()
                .Property(i => i.Type);
            modelBuilder.Entity<Item>()
                .Property(i => i.Restriction);
            modelBuilder.Entity<Item>()
                .Property(i => i.BuyPrice)
                .IsRequired();
            modelBuilder.Entity<Item>()
                .Property(i => i.SellPrice)
                .IsRequired();
            modelBuilder.Entity<Item>()
                .HasOne(i => i.Attributes)
                .WithOne(ia => ia.Item)
                .HasForeignKey<Item>(i => i.AttributesId);


            modelBuilder.Entity<ItemAttributes>()
                .Property(ia => ia.Id);
            modelBuilder.Entity<ItemAttributes>()
                .Property(ia => ia.Damage)
                .IsRequired();
            modelBuilder.Entity<ItemAttributes>()
                .Property(ia => ia.Precision)
                .IsRequired();
            modelBuilder.Entity<ItemAttributes>()
                .Property(ia => ia.Specialization)
                .IsRequired();
            modelBuilder.Entity<ItemAttributes>()
                .Property(ia => ia.MaxHealth)
                .IsRequired();
            modelBuilder.Entity<ItemAttributes>()
                .Property(ia => ia.CurrentHealth)
                .IsRequired();
            modelBuilder.Entity<ItemAttributes>()
                .Property(ia => ia.Reflex)
                .IsRequired();
            modelBuilder.Entity<ItemAttributes>()
                .Property(ia => ia.Defense)
                .IsRequired();


            modelBuilder.Entity<HeroItem>()
                .HasKey(hi => new { hi.HeroId, hi.ItemId });
            modelBuilder.Entity<Hero>()
                .HasMany(h => h.Inventory)
                .WithOne(hi => hi.Hero)
                .HasForeignKey(hi => hi.HeroId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Item>()
                .HasMany(i => i.Heroes)
                .WithOne(hi => hi.Item)
                .HasForeignKey(hi => hi.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<HeroItem>()
                .Property(hi => hi.ItemEndurance)
                .IsRequired()
                .HasDefaultValue(100.00d);
            modelBuilder.Entity<HeroItem>()
                .Property(hi => hi.InUse)
                .IsRequired()
                .HasDefaultValue(false);
        }
    }

}
