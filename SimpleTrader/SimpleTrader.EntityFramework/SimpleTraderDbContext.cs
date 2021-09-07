using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;
using System;

namespace SimpleTrader.EntityFramework
{
    public class SimpleTraderDbContext : DbContext
    {
        public SimpleTraderDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AssetTransaction> AssetTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetTransaction>().OwnsOne(a => a.Stock);  /// this makes the Stock object to be embedded in the AssetTransaction table
            base.OnModelCreating(modelBuilder);
        }
        
    }
}
