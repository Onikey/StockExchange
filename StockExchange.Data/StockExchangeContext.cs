using StockExchange.Domain;
using System.Configuration;
using System.Data.Entity;

namespace StockExchange.Data
{
    public class StockExchangeContext : DbContext
    {
        public StockExchangeContext()
            : base(nameOrConnectionString: ConnectionStringName) { }

        public static string ConnectionStringName
        {
            get
            {
                if (ConfigurationManager.ConnectionStrings["StockExchangeDb"] != null)
                {
                    return ConfigurationManager.ConnectionStrings["StockExchangeDb"].ToString();
                }

                return "DefaultConnection";
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2").HasPrecision(0));

            //modelBuilder.Types().Where(t => t.GetInterfaces().Contains(typeof(IHaveTrackingState))).Configure(x => x.Ignore("TrackingState"));

            var firmMapping = modelBuilder.Entity<Firm>()
                .ToTable("Firm", "dbo")
                .HasKey(x => x.Id );
           

            firmMapping.Property(x => x.Id).HasColumnName("id");
            firmMapping.Property(x => x.FullName).HasColumnName("full_name");
            firmMapping.Property(x => x.Name).HasColumnName("name");
            firmMapping.HasMany(x => x.SettlePairs);
            
            


            var settlePairMapping = modelBuilder.Entity<SettlePair>()
                .ToTable("SettlPair", "dbo")
                .HasKey(x => x.Id);

            settlePairMapping.Property(x => x.Id).HasColumnName("id");
            settlePairMapping.Property(x => x.Name).HasColumnName("settl_pair");
            settlePairMapping.Property(x => x.DepoNum).HasColumnName("depo_num");
            settlePairMapping.HasMany(x => x.Assets);

            var assetMapping = modelBuilder.Entity<Asset>()
                .ToTable("Asset", "dbo")
                .HasKey(x => x.Id);

            assetMapping.Property(x=>x.Id).HasColumnName("id");
            assetMapping.Property(x=>x.AcctNum).HasColumnName("acct_num");
            assetMapping.Property(x=>x.Free).HasColumnName("free");


            var issueMapping = modelBuilder.Entity<Issue>()
                 .ToTable("Issue", "dbo")
                 .HasKey(x => x.Id);

            issueMapping.Property(x => x.Id).HasColumnName("id");
            issueMapping.Property(x => x.Name).HasColumnName("name");
            issueMapping.Property(x => x.FullName).HasColumnName("full_name");
                        

        }
    }
}
