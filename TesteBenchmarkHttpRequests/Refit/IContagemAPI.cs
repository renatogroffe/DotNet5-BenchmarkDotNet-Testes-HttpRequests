using System.Threading.Tasks;
using Refit;
using TesteBenchmarkHttpRequests.Models;

namespace TesteBenchmarkHttpRequests.Refit
{
    public interface IContagemAPI
    {
        [Get("/Contador")]
        Task<ResultadoContador> ObterValorAtualAsync();
    }
}