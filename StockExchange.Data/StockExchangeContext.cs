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

                entity.HasKey(x => x.Name);

                entity.Property(x => x.Id).HasColumnName("id");
                entity.Property(x => x.FullName).HasColumnName("full_name");
                entity.Property(x => x.Name).HasColumnName("name");
                entity.HasMany(x => x.SettlePairs)
                    .WithOne(x => x.Firm)
                    .HasForeignKey(x => x.FirmName)
                    .HasPrincipalKey(x => x.Name);
                entity.HasMany(x => x.TradesAsInit)
                    .WithOne(x => x.InitFirm)
                    .HasForeignKey(x => x.InitFirmName)
                    .HasPrincipalKey(x => x.Name);
                entity.HasMany(x => x.TradesAsConf)
                    .WithOne(x => x.ConfFirm)
                    .HasForeignKey(x => x.ConfFirmName)
                    .HasPrincipalKey(x => x.Name);
            });

            modelBuilder.Entity<SettlePair>(entity =>
            {
                entity.ToTable("SettlPair", "dbo");
                entity.HasKey(x => x.Name);

                entity.Property(x => x.Id).HasColumnName("id");
                entity.Property(x => x.Name).HasColumnName("settl_pair");
                entity.Property(x => x.DepoNum).HasColumnName("depo_num");
                entity.Property(x => x.FirmName).HasColumnName("firm_name");
                entity.HasMany(x => x.Assets);
            });

            modelBuilder.Entity<Asset>(entity =>
            {
                entity.ToTable("Asset", "dbo");

                entity.HasKey(x => x.AcctNum);

                entity.Property(x => x.Id).HasColumnName("id");
                entity.Property(x => x.AcctNum).HasColumnName("acct_num");
                entity.Property(x => x.Free).HasColumnName("free");
            });

            modelBuilder.Entity<Issue>(entity =>
            {
                entity.ToTable("Issue", "dbo");

                entity.HasKey(x => x.Name);

                entity.Property(x => x.Id).HasColumnName("id");
                entity.Property(x => x.Name).HasColumnName("name");
                entity.Property(x => x.FullName).HasColumnName("full_name");
            });

            modelBuilder.Entity<Trade>(entity =>
            {
                entity.ToTable("WebTrade", "dbo");
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Id).HasColumnName("id");
                entity.Property(x => x.Qty).HasColumnName("qty");
                entity.Property(x => x.Price).HasColumnName("price");
                entity.Property(x => x.Status).HasColumnName("status");
                entity.Property(x => x.IssueName).HasColumnName("issue_name");
                entity.Property(x => x.TradeMoment).HasColumnName("trade_moment");
                entity.Property(x => x.AffirmMoment).HasColumnName("affirm_moment");
                entity.Property(x => x.InitFirmName).HasColumnName("init_firm");
                entity.Property(x => x.InitSettlePairName).HasColumnName("init_pair");
                entity.Property(x => x.InitAction).HasColumnName("init_action");
                entity.Property(x => x.InitMemo).HasColumnName("init_memo");
                entity.Property(x => x.ConfFirmName).HasColumnName("conf_firm");
                entity.Property(x => x.ConfSettlePairName).HasColumnName("conf_pair");
                entity.Property(x => x.ConfAction).HasColumnName("conf_action");
                entity.Property(x => x.ConfMemo).HasColumnName("conf_memo");
            });
        }


        public virtual DbSet<Asset> Assets { get; set; }
        public virtual DbSet<Firm> Firms { get; set; }
        public virtual DbSet<Issue> Issues { get; set; }
        public virtual DbSet<SettlePair> SettlePairs { get; set; }
        public virtual DbSet<Trade> Trades { get; set; }
    }

}
