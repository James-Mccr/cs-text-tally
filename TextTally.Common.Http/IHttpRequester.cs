using System;
using System.Threading.Tasks;

namespace TextTally.Common.Http
{
    public interface IHttpRequester
    {
        Task<IHttpReader> Request(Uri uri);
    }
}