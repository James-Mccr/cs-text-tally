using System;
using System.Threading.Tasks;
using TextTally.Common.Http;

namespace TextTally.Common.Source
{
    public class HttpSource : ISource
    {
        public HttpSource(IHttpRequester client, Uri uri)
        {
            Client = client ?? throw new ArgumentNullException(nameof(Client));
            Uri = uri ?? throw new ArgumentNullException(nameof(Uri));
        }

        public IHttpRequester Client { get; }
        public Uri Uri { get; }

        public string Read() => ReadAsync().Result;

        public async Task<string> ReadAsync() 
        {
            var response = await Client.Request(Uri);
            return await response.ReadBody();
        } 
    }
}