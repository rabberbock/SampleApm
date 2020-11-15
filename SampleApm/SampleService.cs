
using Elastic.Apm.Api;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApm
{
    public class SampleService : BackgroundService
    {
        private readonly ILogger<SampleService> _logger;
        private ITracer _tracer;

        public SampleService(ILogger<SampleService> logger, ITracer tracer)
        {
            _logger = logger;
            _tracer = tracer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                await _tracer.CaptureTransaction("SampleHttpTransaction", ApiConstants.TypeRequest, async() =>
                {
                    var client = new HttpClient();
                    HttpResponseMessage response = await client.GetAsync("http://www.example.com/");
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    // Above three lines can be replaced with new helper method below
                    // string responseBody = await client.GetStringAsync(uri);

                    Console.WriteLine(responseBody);
                   
                });
                await Task.Delay(10_000);
            }

        }
    }
}
