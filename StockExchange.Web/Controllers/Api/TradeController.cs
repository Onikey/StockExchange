using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockExchange.Core;
using StockExchange.Data;
using StockExchange.Web.Models;

namespace StockExchange.Web.Controllers.Api
{
    [ApiController]
    public class TradeController : ControllerBase
    {
        private readonly StockExchangeContext _context;

        public TradeController(StockExchangeContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("api/trade")]
        public IActionResult Post([FromBody] TradeCreateModel tradeModel)
        {
            var newTrade = Trade.Create(
                issue: _context.Issues.Single(x => x.Name == tradeModel.IssueName),
                confFirm: _context.Firms.Single(x => x.Name == tradeModel.ConfFirmName),
                initAction: tradeModel.InitAction,
                initFirm: _context.Firms.Single(x => x.Name == tradeModel.InitFirmName),
                initMemo: tradeModel.InitMemo,
                initSettlePair: _context.SettlePairs.Single(x => x.Name == tradeModel.InitSettlePairName),
                price: tradeModel.Price,
                qty: tradeModel.Qty);

            _context.Trades.Add(newTrade);

            _context.SaveChanges();

            return Created(string.Empty, null);
        }

        [HttpGet]
        [Route("api/trades")]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}