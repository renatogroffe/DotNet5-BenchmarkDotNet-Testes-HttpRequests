using System.Net.Http;
using System.Net.Http.Json;
using BenchmarkDotNet.Attributes;
using Refit;
using TesteBenchmarkHttpRequests.Refit;
using TesteBenchmarkHttpRequests.Models;

namespace TesteBenchmarkHttpRequests.Tests
{
    public class HttpClientVsRefit
    {
        private const string API_CONTAGEM_HTTPCLIENT = "http://localhost:5000/contador";
        private const string API_CONTAGEM_REFIT = "http://localhost:6000/";
        private HttpClient _httpClient;
        private IContagemAPI _refitClient;
        
        [IterationSetup(Target = nameof(HttpRequestWithHttpClient))]
        public void SetupHttpClient()
        {
            _httpClient = new HttpClient();
        }

        [Benchmark]
        public ResultadoContador HttpRequestWithHttpClient()
        {
            return _httpClient.GetFromJsonAsync<ResultadoContador>(
                API_CONTAGEM_HTTPCLIENT).Result;
        }

        [IterationCleanup(Target = nameof(HttpRequestWithHttpClient))]
        public void CleanupHttpClient()
        {
            _httpClient = null;
        }

        [IterationSetup(Target = nameof(HttpRequestWithRefit))]
        public void SetupRefit()
        {
            _refitClient = RestService.For<IContagemAPI>(API_CONTAGEM_REFIT);
        }

        [Benchmark]
        public ResultadoContador HttpRequestWithRefit()
        {
            return _refitClient.ObterValorAtualAsync().Result;
        }

        [IterationCleanup(Target = nameof(HttpRequestWithRefit))]
        public void CleanupRefit()
        {
            _refitClient = null;
        }
    }
}