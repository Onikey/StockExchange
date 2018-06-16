using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockExchange.Domain.Test.Builders;
namespace StockExchange.Domain.Test
{
    [TestClass]
    public class SettlePairTest
    {
        [TestMethod]
        public void SettlePairBuilder()
        {
            
                

            var settlePair = new SettlePairBuilder()
                .WithId(1)
                .WithName("settle1")
                .WithDepoNum("111_2_333")
                .Build();

            Assert.IsNotNull(settlePair);
            Assert.AreEqual(1, settlePair.Id);
            Assert.AreEqual("settle1", settlePair.Name);
            Assert.AreEqual("111_2_333", settlePair.DepoNum);
            
               
        }

        

    }
}
