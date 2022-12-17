using System.Threading.Tasks;

namespace TextTally.Common.Http
{
    public interface IHttpReader
    {
        Task<string> ReadBody();
    }
}