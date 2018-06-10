using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockExchange.Domain.Test.Builders;

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
        }
    }
}
