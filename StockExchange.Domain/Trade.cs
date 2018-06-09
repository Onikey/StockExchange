using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Domain
{
    class Trade
    {
        private Trade() { }

        public int Id { get; private set; }

        public Issue Issue { get; set; }

        public double Price { get; set; }

        public int Qty { get; set; }

        public double Volume => Price * Qty;

        public DateTime TradeMoment { get; set; }

        public DateTime? AffirmMoment { get; set; }

        public Firm InitFirm { get; set; }

        public SettlePair InitSettlePair { get; set; }

        public string InitAction { get; set; }

        public string InitMemo { get; set; }

        public Firm ConfFirm { get; set; }

        public SettlePair ConfSettlePair { get; set; }

        public string ConfAction { get; set; }

        public string ConfMemo { get; set; }

        public Status Status { get; set; }




        public static Trade Create(
            Issue issue,
            double price,
            int qty,
            Firm initFirm,
            SettlePair initSettlePair,
            string initAction,
            string initMemo,
            Firm confFirm)
        {

            if (initFirm == null)
            {
                throw new Exception("InitFirm is null");
            }

            if (issue == null)
            {
                throw new Exception("Issue is null");
            }

            if (price <= 0)
            {
                throw new Exception("Wrong price");
            }

            if (qty <= 0)
            {
                throw new Exception("Wrong qty");
            }

            if (!(initAction == TradeAction.Buy || initAction == TradeAction.Sell))
            {
                throw new Exception("Wrong action");
            }


            if (!initFirm.SettlePairs.Contains(initSettlePair))
            {
                throw new Exception("Wrong settle pair");
            }

            if (confFirm == null)
            {
                throw new Exception("ConfFirm is null");
            }

            var result = new Trade
            {
                Issue = issue,
                Price = price,
                Qty = qty,
                InitFirm = initFirm,
                InitSettlePair = initSettlePair,
                InitAction = initAction,
                InitMemo = initMemo,
                ConfFirm = confFirm,
                TradeMoment = DateTime.UtcNow,
                Status = Status.New,
                ConfAction = TradeAction.OpositeTradeAction(initAction)
            };

            if (result.Volume <= 0)
            {
                throw new Exception("Wrong volume");
            }

            return result;
        }

        public void Confirm(SettlePair confSettlePair, string confMemo)
        {
            if (!ConfFirm.SettlePairs.Contains(confSettlePair))
            {
                throw new Exception("Wrong settle pair");
            }

            this.ConfSettlePair = confSettlePair;
            this.ConfMemo = confMemo;
            this.AffirmMoment = DateTime.UtcNow;
            this.Status = Status.Affirm;
        }


    }
}
