using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockExchange.Domain.Test.Builders;

namespace StockExchange.Domain.Test
{
    [TestClass]
    public class AssetTest
    {
        [TestMethod]
        public void AssetBuilder()
        {
            var asset = new AssetBuilder()
                .withId(1)
                .withAcctNum("111_2_333")
                .withFree(1.11)
                .Build();


            Assert.IsNotNull(asset);
            Assert.AreEqual(1,asset.Id);
            Assert.AreEqual("111_2_333",asset.AcctNum);
            Assert.AreEqual(1.11,asset.Free);
        }
    }
}
