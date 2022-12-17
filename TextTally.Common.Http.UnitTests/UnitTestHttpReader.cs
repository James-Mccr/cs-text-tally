using System.Net.Http;
using System.Threading;
using Moq;
using NUnit.Framework;

namespace TextTally.Common.Http.UnitTests
{
    public class UnitTestHttpReader
    {
        [Test]
        public void HttpReaderConstruct()
        {
            var response = new HttpResponseMessage();
            var cancellationToken = new System.Threading.CancellationToken();
            var reader = new HttpReader(response, cancellationToken);
            Assert.AreSame(response, reader.HttpResponseMessage);
            Assert.AreEqual(cancellationToken, reader.CancellationToken);
        }

        [Test]
        public void HttpReaderReadBody()
        {
            var response = new HttpResponseMessage();
            var content = new StringContent("Testing 123");
            response.Content = content;
            var reader = new HttpReader(response, It.IsAny<CancellationToken>());

            var body = reader.ReadBody().Result;

            Assert.AreEqual("Testing 123", body);
        }
    }
}