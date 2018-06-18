using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockExchange.Web.Models
{
    public class TradeCreateModel
    {
        public string IssueName { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }
        public string InitFirmName { get; set; }
        public string InitSettlePairName { get; set; }
        public string InitAction { get; set; }
        public string InitMemo { get; set; }
        public string ConfFirmName { get; set; }
    }
}
