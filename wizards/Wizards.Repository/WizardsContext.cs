using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizards.Core;
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

           //modelBuilder.Entity<Pl>
        }
    }

}
