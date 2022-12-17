using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TextTally.Common.Http
{
    public class HttpReader : IHttpReader
    {
        public HttpReader(HttpResponseMessage httpResponseMessage, CancellationToken cancellationToken)
        {
            HttpResponseMessage = httpResponseMessage;
            CancellationToken = cancellationToken;
        }

        public HttpResponseMessage HttpResponseMessage { get; }
        public CancellationToken CancellationToken { get; }

        public async Task<string> ReadBody() => await HttpResponseMessage.Content.ReadAsStringAsync(CancellationToken);
    }
}