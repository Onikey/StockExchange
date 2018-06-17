﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockExchange.Core;
using StockExchange.Data;

namespace StockExchange.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmsController : ControllerBase
    {
        private readonly StockExchangeContext _context;

        public FirmsController(StockExchangeContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("current")]
        public async Task<IActionResult> CurrentFirm()
        {
            return Ok(await _context.Firms.SingleAsync(x => x.Id == 1290));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Firms.ToListAsync());
        }
    }
}