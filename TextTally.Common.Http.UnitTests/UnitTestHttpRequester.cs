using System.Net.Http;
using System.Threading;
using NUnit.Framework;

namespace TextTally.Common.Http.UnitTests
{
    public class UnitTestHttpRequester
    {
        [Test]
        public void HttpRequesterConstruct()
        {
            var client = new HttpClient();
            var token = new CancellationToken();
            var requester = new HttpRequester(client, token);
            Assert.AreSame(client, requester.HttpClient);
            Assert.AreEqual(token, requester.CancellationToken);
        }
    }
}