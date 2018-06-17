using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Common.IoC.Autofac;
using Common.IoC.Common;

namespace StockExchange.Web
{
    public class ComponentRegistrationModule : AutofacModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(AutofacService.Instance)
            .As<IDependencyResolver>()
            .SingleInstance();

            builder.RegisterControllers(typeof(WebApiApplication).Assembly);
            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);
        }
    }
}