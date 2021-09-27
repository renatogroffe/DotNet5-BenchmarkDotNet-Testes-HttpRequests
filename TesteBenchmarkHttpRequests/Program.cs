using BenchmarkDotNet.Running;
using TesteBenchmarkHttpRequests.Tests;

namespace TesteBenchmarkHttpRequests
{
    class Program
    {
        static void Main()
        {
            BenchmarkRunner.Run<HttpClientVsRefit>();
        }
    }
}