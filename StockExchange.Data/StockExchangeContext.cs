using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StockExchange.Core;

namespace StockExchange.Data
{
    public class StockExchangeContext : DbContext
    {
        public StockExchangeContext(DbContextOptions<StockExchangeContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Firm>(entity =>
            {
                entity.ToTable("Firm", "dbo");

                entity.HasKey(x => x.Id);

                entity.Property(x => x.Id).HasColumnName("id");
                entity.Property(x => x.FullName).HasColumnName("full_name");
                entity.Property(x => x.Name).HasColumnName("name");
                entity.HasMany(x => x.SettlePairs);
            });

            modelBuilder.Entity<SettlePair>(entity =>
            {
                entity.ToTable("SettlPair", "dbo");
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Id).HasColumnName("id");
                entity.Property(x => x.Name).HasColumnName("settl_pair");
                entity.Property(x => x.DepoNum).HasColumnName("depo_num");
                entity.HasMany(x => x.Assets);
            });

            modelBuilder.Entity<Asset>(entity =>
            {
                entity.ToTable("Asset", "dbo");

                entity.HasKey(x => x.Id);

                entity.Property(x => x.Id).HasColumnName("id");
                entity.Property(x => x.AcctNum).HasColumnName("acct_num");
                entity.Property(x => x.Free).HasColumnName("free");
            });

            modelBuilder.Entity<Issue>(entity =>
            {
                entity.ToTable("Issue", "dbo");

                entity.HasKey(x => x.Id);

                entity.Property(x => x.Id).HasColumnName("id");
                entity.Property(x => x.Name).HasColumnName("name");
                entity.Property(x => x.FullName).HasColumnName("full_name");
            });

            //modelBuilder.Entity<Trade>(entity =>
            //{
            //    entity.ToTable("TradeWeb", "dbo");
            //});
        }


        public virtual DbSet<Asset> Assets { get; set; }
        public virtual DbSet<Firm> Firms { get; set; }
        public virtual DbSet<Issue> Issues { get; set; }
        public virtual DbSet<SettlePair> SettlePairs { get; set; }
        //public virtual DbSet<Trade> Trades { get; set; }
    }

}
