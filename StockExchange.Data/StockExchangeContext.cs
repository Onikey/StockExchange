using Common.Abstractions.Entities;
using StockExchange.Domain;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Linq;

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
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2").HasPrecision(0));

            modelBuilder.Types().Where(t => t.GetInterfaces().Contains(typeof(IHaveTrackingState))).Configure(x => x.Ignore("TrackingState"));

            var firmMapping = modelBuilder.Entity<Firm>()
                .ToTable("Firm", "dbo")
                .HasKey(x => x.Id);

            firmMapping.Property(x => x.FullName).HasColumnName("full_name");
        }
    }
}
