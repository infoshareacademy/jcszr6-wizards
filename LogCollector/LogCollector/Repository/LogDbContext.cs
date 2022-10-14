using LogCollector.Models;
using Microsoft.EntityFrameworkCore;

namespace LogCollector.Repository;
public class LogDbContext : DbContext
{
    public LogDbContext(DbContextOptions<LogDbContext> options) : base(options) { }
    public DbSet<Log> Logs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Log>()
            .HasKey(l => l.Id);
        modelBuilder.Entity<Log>()
            .Property(l => l.TimeStamp)
            .IsRequired();
        modelBuilder.Entity<Log>()
            .Property(l => l.AppName)
            .IsRequired()
            .HasMaxLength(256);
        modelBuilder.Entity<Log>()
            .Property(l => l.LogLevel)
            .IsRequired()
            .HasMaxLength(64);
        modelBuilder.Entity<Log>()
            .Property(l => l.LogMessage)
            .IsRequired()
            .HasMaxLength(1024);
        modelBuilder.Entity<Log>()
            .Property(l => l.Exception)
            .IsRequired(false)
            .HasMaxLength(4096);
        modelBuilder.Entity<Log>()
            .Property(l => l.Properties)
            .IsRequired(false)
            .HasMaxLength(16384);
    }
}