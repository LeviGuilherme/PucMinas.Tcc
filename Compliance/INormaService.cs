using System.Net.Http;
using System.Threading.Tasks;

namespace Compliance
{
    public interface INormaService
    {
        Task<string> GetNormas();
        Task<string> GetNorma(int id);
    }
}