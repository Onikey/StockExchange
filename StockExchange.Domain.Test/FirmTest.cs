using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockExchange.Domain.Test.Builders;
using System.Linq;

namespace StockExchange.Domain.Test
{
    [TestClass]
    public class FirmTest
    {
        [TestMethod]
        public void FirmBuilder()
        {
            var firm = new FirmBuilder()
                        .WithId(1)
                        .WithName("test")
                        .WithFullName("OOO Test")
                        .Build();

            Assert.IsNotNull(firm);
            Assert.AreEqual(1, firm.Id);
            Assert.AreEqual("test", firm.Name);
            Assert.AreEqual("OOO Test", firm.FullName);
        }

        [TestMethod]
        public void CreateTrade()
        {
            var firmConf = new FirmBuilder()
            .WithId(2)
            .WithName("testConf")
            .WithFullName("OOO TestConf")
            .Build();

            var issue = new IssueBuilder()
                .WithId(1)
                .WithName("DOEN")
                .WithFullName("Donetsk obl energo")
                .Build();

            var price = 15.53;

            var qty = 133;

            var asset1 = new AssetBuilder()
                .withId(1)
                .withAcctNum("111_2_333")
                .withFree(50)
                .Build();


            var settlPairInit = new SettlePairBuilder()
           .WithId(1)
           .WithName("cust1")
           .WithDepoNum("111_2_333")
           .WithAsset(asset1)
           .Build();


            var firmInit = new FirmBuilder()
                        .WithId(1)
                        .WithName("testInit")
                        .WithFullName("OOO TestInit")
                        .WithSettlePair(settlPairInit)
                        .Build();

            var memoInit = "memoInit";

            var actionInit = "S";




            firmInit.CreateTrade(
                issue,
                price,
                qty,
                settlPairInit,
                actionInit,
                memoInit,
                firmConf);

            Assert.IsNotNull(firmInit.Trades);
            Assert.AreEqual(issue.Id, firmInit.Trades.FirstOrDefault().Issue.Id);
            Assert.AreEqual(issue.Name, firmInit.Trades.FirstOrDefault().Issue.Name);
            Assert.AreEqual(issue.FullName, firmInit.Trades.FirstOrDefault().Issue.FullName);
            Assert.AreEqual(price, firmInit.Trades.FirstOrDefault().Price);
            Assert.AreEqual(qty, firmInit.Trades.FirstOrDefault().Qty);
            Assert.AreEqual(qty * price, firmInit.Trades.FirstOrDefault().Volume);
            Assert.AreEqual(firmInit.Id, firmInit.Trades.FirstOrDefault().InitFirm.Id);
            Assert.AreEqual(firmInit.Name, firmInit.Trades.FirstOrDefault().InitFirm.Name);
            Assert.AreEqual(firmInit.FullName, firmInit.Trades.FirstOrDefault().InitFirm.FullName);
            Assert.AreEqual(settlPairInit.Id, firmInit.Trades.FirstOrDefault().InitSettlePair.Id);
            Assert.AreEqual(settlPairInit.Name, firmInit.Trades.FirstOrDefault().InitSettlePair.Name);
            Assert.AreEqual(settlPairInit.DepoNum, firmInit.Trades.FirstOrDefault().InitSettlePair.DepoNum);
            Assert.AreEqual(actionInit, firmInit.Trades.FirstOrDefault().InitAction);
            Assert.AreEqual(memoInit, firmInit.Trades.FirstOrDefault().InitMemo);
            Assert.AreEqual(firmConf.Id, firmInit.Trades.FirstOrDefault().ConfFirm.Id);
            Assert.AreEqual(firmConf.Name, firmInit.Trades.FirstOrDefault().ConfFirm.Name);
            Assert.AreEqual(firmConf.FullName, firmInit.Trades.FirstOrDefault().ConfFirm.FullName);
            Assert.AreEqual(null, firmInit.Trades.FirstOrDefault().ConfSettlePair);
            Assert.AreEqual("P", firmInit.Trades.FirstOrDefault().ConfAction);
            Assert.AreEqual(null, firmInit.Trades.FirstOrDefault().ConfMemo);
            Assert.AreEqual(Status.New, firmInit.Trades.FirstOrDefault().Status);
        }

        [TestMethod]
        public void CreateTrade_ConfFirm_Ok()
        {
            var firmConf = new FirmBuilder()
            .WithId(2)
            .WithName("testConf")
            .WithFullName("OOO TestConf")
            .Build();

            var issue = new IssueBuilder()
                .WithId(1)
                .WithName("DOEN")
                .WithFullName("Donetsk obl energo")
                .Build();

            var price = 15.53;

            var qty = 133;

            var asset1 = new AssetBuilder()
                .withId(1)
                .withAcctNum("111_2_333")
                .withFree(50)
                .Build();


            var settlPairInit = new SettlePairBuilder()
           .WithId(1)
           .WithName("cust1")
           .WithDepoNum("111_2_333")
           .WithAsset(asset1)
           .Build();


            var firmInit = new FirmBuilder()
                        .WithId(1)
                        .WithName("testInit")
                        .WithFullName("OOO TestInit")
                        .WithSettlePair(settlPairInit)
                        .Build();

            var memoInit = "memoInit";

            var actionInit = "S";




            firmInit.CreateTrade(
                issue,
                price,
                qty,
                settlPairInit,
                actionInit,
                memoInit,
                firmConf);

            var newTrade = firmInit.Trades.FirstOrDefault();

            Assert.IsTrue(firmConf.Trades.Contains(newTrade));
        }

        [TestMethod]
        public void CreateTrade_ConfAndInitIsSame_Ok()
        {
            var issue = new IssueBuilder()
                .WithId(1)
                .WithName("DOEN")
                .WithFullName("Donetsk obl energo")
                .Build();

            var price = 15.53;

            var qty = 133;

            var asset1 = new AssetBuilder()
                .withId(1)
                .withAcctNum("111_2_333")
                .withFree(50)
                .Build();


            var settlPairInit = new SettlePairBuilder()
           .WithId(1)
           .WithName("cust1")
           .WithDepoNum("111_2_333")
           .WithAsset(asset1)
           .Build();


            var firmInit = new FirmBuilder()
                        .WithId(1)
                        .WithName("testInit")
                        .WithFullName("OOO TestInit")
                        .WithSettlePair(settlPairInit)
                        .Build();

            var memoInit = "memoInit";

            var actionInit = "S";




            firmInit.CreateTrade(
                issue,
                price,
                qty,
                settlPairInit,
                actionInit,
                memoInit,
                firmInit);

            var newTrade = firmInit.Trades.FirstOrDefault();

            Assert.AreEqual(1, firmInit.Trades.Count(x => x == newTrade));
        }
    }
}
