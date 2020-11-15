using System;
using Elastic.Apm;
using Elastic.Apm.Api;
using Elastic.Apm.DiagnosticSource;
using Elastic.Apm.EntityFrameworkCore;
using Elastic.Apm.NetCoreAll;
using Elastic.Apm.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SampleApm
{

    public class Program {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseAllElasticApm()
                .ConfigureServices((hostContext, services) =>
                {

                    services.AddHostedService(sp =>
                    {
                        //if (!Agent.IsConfigured)
                        //{
                        //    Agent.Setup(sp.GetRequiredService<AgentComponents>());
                        //    Agent.Subscribe(new HttpDiagnosticsSubscriber(),
                        //                    new EfCoreDiagnosticsSubscriber(),
                        //                    new SqlClientDiagnosticSubscriber());
                        //}
                        return new SampleService(sp.GetRequiredService<ILogger<SampleService>>(), sp.GetRequiredService<ITracer>());
                    });


                });
        }
}
