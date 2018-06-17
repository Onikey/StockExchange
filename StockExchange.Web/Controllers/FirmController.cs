using StockExchange.Contracts.Repositories;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StockExchange.Web.Controllers
{
    [RoutePrefix("api/firm")]
    public class FirmController : BaseController
    {
        private IFirmRepository FirmRepository
        {
            get
            {
                return this.DependencyResolver.Resolve<IFirmRepository>();
            }
        }

        public HttpResponseMessage Get()
        {
            try
            {
                using (var repository = this.FirmRepository)
                {
                    var result = repository.GetAll().ToList();

                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
            }
            catch (Exception ex)
            {
             
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetById(decimal id)
        {
            try
            {
                using (var repository = this.FirmRepository)
                {
                    var result = repository.GetById(id);

                    if (result == null) return Request.CreateResponse(HttpStatusCode.NoContent);

                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

    }
}
