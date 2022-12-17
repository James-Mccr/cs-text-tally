using System;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TextTally.Common.Http;

namespace TextTally.Common.Source.UnitTests
{
    [TestFixture]
    public class UnitTestHttpSource
    {
        const string TestUrl = "http://localhost";

        [Test]
        public void HttpSourceConstruct()
        {
            var mockClient = new Mock<IHttpRequester>();
            var uri = new Uri(TestUrl);
            var source = new HttpSource(mockClient.Object, uri);
            Assert.AreSame(mockClient.Object, source.Client);
            Assert.AreSame(uri, source.Uri);
        }

        [TestCaseSource(nameof(HttpSourceConstructThrowsData))]
        public void HttpSourceConstructThrows(IHttpRequester client, Uri uri, string expectedParamName) 
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new HttpSource(client, uri));
            Assert.AreEqual(expectedParamName, ex.ParamName);
        }

        [Datapoint]
        static object[] HttpSourceConstructThrowsData =
        {
            new object[] { null, null, nameof(HttpSource.Client) },
            new object[] { new Mock<IHttpRequester>().Object, null, nameof(HttpSource.Uri) }
        };

        [Test]
        public void HttpSourceRead()
        {
            var mockResponse = new Mock<IHttpReader>();
            var mockClient = new Mock<IHttpRequester>();
            mockClient.Setup(m => m.Request(It.IsAny<Uri>())).Returns(Task.FromResult(mockResponse.Object));
            var uri = new Uri(TestUrl);
            var mockSource = new HttpSource(mockClient.Object, uri);

            mockSource.Read();

            mockClient.Verify(m => m.Request(It.IsAny<Uri>()), Times.Once);
            mockResponse.Verify(m => m.ReadBody(), Times.Once);
        }

        [Test]
        public void HttpSourceReadAsync()
        {
            var mockResponse = new Mock<IHttpReader>();
            var mockClient = new Mock<IHttpRequester>();
            mockClient.Setup(m => m.Request(It.IsAny<Uri>())).Returns(Task.FromResult(mockResponse.Object));
            var uri = new Uri(TestUrl);
            var source = new HttpSource(mockClient.Object, uri);

            source.ReadAsync().Wait();

            mockClient.Verify(m => m.Request(It.IsAny<Uri>()), Times.Once);
            mockResponse.Verify(m => m.ReadBody(), Times.Once);
        }
    }
}