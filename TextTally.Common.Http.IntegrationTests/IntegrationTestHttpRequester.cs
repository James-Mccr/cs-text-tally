using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using TextTally.Common.Tests;

namespace TextTally.Common.Http.IntegrationTests
{
    public class IntegrationTestHttpRequester
    {
        [Test]
        public async Task HttpRequesterRequestFromLocalHost()
        {
            var server = new TestServer().Create();
            var client = new HttpClient();
            var cancellationToken = new CancellationToken();
            var requester = new HttpRequester(client, cancellationToken);
            var uri = new Uri(server.Url);

            var response = await requester.Request(uri) as HttpReader;

            Assert.AreEqual(TestServer.DefaultHeader.Values[0], response.HttpResponseMessage.Content.Headers.ContentType.MediaType);
            Assert.AreEqual(TestServer.DefaultBody.Length, response.HttpResponseMessage.Content.Headers.ContentLength);
            Assert.AreEqual(TestServer.DefaultBody, response.HttpResponseMessage.Content.ReadAsStringAsync().Result);
            Assert.AreEqual((HttpStatusCode)TestServer.DefaultStatusCode, response.HttpResponseMessage.StatusCode);
        }
    }
}