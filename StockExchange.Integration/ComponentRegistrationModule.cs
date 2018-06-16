using Autofac;
using Common.Abstractions.Repository;
using Common.DataAccess;
using Common.DataAccess.DataSources;
using Common.IoC.Autofac;
using StockExchange.Contracts.Repositories;
using StockExchange.Data;
using StockExchange.Data.Repositories;

namespace StockExchange.Integration
{
    public class ComponentRegistrationModule : AutofacModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            this.ConfigureEntityFrameworkDataAccess(builder);
            this.RegisterRepositories(builder);
        }

        private void ConfigureEntityFrameworkDataAccess(ContainerBuilder builder)
        {
            builder.RegisterType<StockExchangeContext>();

            //// **** Register EFDS for each source type ****
            builder.Register((x, y) => new EntityFrameworkDataSource(x.Resolve<StockExchangeContext>()))
                .Keyed<IDataSource>(DataSourceType.StockExchangeEF);

            builder.Register((x, y) => new GenericRepository(x.ResolveKeyed<IDataSource>(DataSourceType.StockExchangeEF)))
                .Keyed<GenericRepository>(DataSourceType.StockExchangeEF);

            builder.Register((x, y) => new GenericRepository(x.ResolveKeyed<IDataSource>(DataSourceType.StockExchangeEF)))
                .Keyed<IGenericRepository>(DataSourceType.StockExchangeEF)
                .As<IGenericRepository>();

            builder.Register((x, y) => new GenericRepository(x.ResolveKeyed<IDataSource>(DataSourceType.StockExchangeEF)))
                .Keyed<IAsyncGenericRepository>(DataSourceType.StockExchangeEF)
                .As<IAsyncGenericRepository>();
        }

        private void RegisterRepositories(ContainerBuilder builder)
        {
            builder.Register((x, y) => new FirmRepository(x.ResolveKeyed<IAsyncGenericRepository>(DataSourceType.StockExchangeEF)))
                .As<IFirmRepository>();
        }
    }
}
