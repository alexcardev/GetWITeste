using GetWITeste.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GetWITeste
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            Startup startup = new Startup();
            startup.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            var app = serviceProvider.GetService<IApplicationService>();
            app.Startup();
        }
    }
}
