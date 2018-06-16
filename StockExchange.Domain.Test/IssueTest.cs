using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockExchange.Domain.Test.Builders;

namespace StockExchange.Domain.Test
{
    [TestClass]
    public class IssueTest
    {
        [TestMethod]
        public void IssueBuilder()
        {
            var issue = new IssueBuilder()
                .WithId(1)
                .WithName("testIssue")
                .WithFullName("DescriptionIssue")
                .Build();

            Assert.IsNotNull(issue);
            Assert.AreEqual(1, issue.Id);
            Assert.AreEqual("testIssue", issue.Name);
            Assert.AreEqual("DescriptionIssue", issue.FullName);
        }

       

    }
}
