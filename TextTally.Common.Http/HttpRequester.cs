using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TextTally.Common.Http
{
    public class HttpRequester : IHttpRequester
    {
        public HttpRequester(HttpClient httpClient, CancellationToken cancellationToken)
        {
            HttpClient = httpClient;
            CancellationToken = cancellationToken;
        }

        public HttpClient HttpClient { get; }
        public CancellationToken CancellationToken { get; }

        public async Task<IHttpReader> Request(Uri uri) 
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var response = await HttpClient.SendAsync(request, CancellationToken);
            return new HttpReader(response, CancellationToken);
        } 
    }
};