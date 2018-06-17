using Common.IoC.Autofac;
using Common.IoC.Common;
using System.Web.Http;

namespace StockExchange.Web.Controllers
{
    public class BaseController : ApiController
    {
        protected IDependencyResolver DependencyResolver
        {
            get
            {
                return AutofacService.Instance.Resolve<IDependencyResolver>();
            }
        }
    }
}