using System.Threading.Tasks;

namespace TextTally.Common.Source
{
    public interface ISource
    {
        string Read();
        Task<string> ReadAsync();
    }
}