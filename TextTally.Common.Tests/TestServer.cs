using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace TextTally.Common.Tests
{
    public class TestServer
    {
        public static readonly Header DefaultHeader = new Header("Content-Type", new[] { "text/plain" });
        public static readonly string[] DefaultPaths = new[] { "/" };
        public const string DefaultBody = "Hello world!";
        public const int DefaultStatusCode = 200;

        public static readonly IResponseBuilder DefaultResponse = 
            Response.Create()
                    .WithStatusCode(DefaultStatusCode)
                    .WithHeader(DefaultHeader.Name, DefaultHeader.Values)
                    .WithBody(DefaultBody);

        public static readonly IRequestBuilder DefaultRequest =
            Request.Create()
                   .WithPath(DefaultPaths)
                   .UsingGet();


        /// <summary>
        /// Construct test server with default settings
        /// </summary>
        public TestServer() : this(DefaultHeader, DefaultBody, DefaultPaths, DefaultStatusCode)
        {}

        public TestServer(Header header, string body, string[] paths, int statusCode)
        {                        
            Header = header;
            Body = body;
            Paths = paths;
            StatusCode = statusCode;
        }

        public string[] Paths { get; }
        public int StatusCode { get; }
        public Header Header { get; }
        public string Body { get; }

        public WireMockServer Create() => Create(DefaultRequest, DefaultResponse);

        public WireMockServer Create(IRequestBuilder request, IResponseBuilder response)
        {
            var server = WireMockServer.Start();
            server
                .Given(request)
                .RespondWith(response);
            return server;
        }
    }
}