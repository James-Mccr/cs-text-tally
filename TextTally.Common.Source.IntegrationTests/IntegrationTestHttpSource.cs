using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using TextTally.Common.Http;
using TextTally.Common.Tests;

namespace TextTally.Common.Source.IntegrationTests
{
    public class IntegrationTestHttpSource
    {
        [Test]
        public void HttpSourceReadLocalHost()
        {
            var server = new TestServer().Create();
            var client = new HttpRequester(new HttpClient(), new CancellationToken());
            var uri = new Uri(server.Url);
            var source = new HttpSource(client, uri);

            var content = source.Read();

            Assert.AreEqual(TestServer.DefaultBody, content);
        }

        [Test]
        public async Task HttpSourceReadAsyncLocalHost()
        {
            var server = new TestServer().Create();
            var client = new HttpRequester(new HttpClient(), new CancellationToken());
            var uri = new Uri(server.Url);
            var source = new HttpSource(client, uri);

            var content = await source.ReadAsync();

            Assert.AreEqual(TestServer.DefaultBody, content);
        }
    }
}