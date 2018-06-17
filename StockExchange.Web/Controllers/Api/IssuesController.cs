using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockExchange.Data;
using System.Threading.Tasks;

namespace StockExchange.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuesController : ControllerBase
    {
        private readonly StockExchangeContext _context;

        public IssuesController(StockExchangeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Issues.ToListAsync());
        }
    }
}