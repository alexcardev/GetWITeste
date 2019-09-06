using GetWITeste.Core.Entities;
using GetWITeste.Core.Interfaces;
using GetWITeste.Core.Services;
using GetWITeste.Infra.Api;
using GetWITeste.Infra.Data;
using GetWITeste.Interfaces;
using GetWITeste.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace GetWITeste
{
    public class Startup
    {
        IConfigurationRoot Configuration { get; }

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.Configure<AppSettings>(Configuration.GetSection("Configuration"));
            services.AddSingleton<IConfigurationRoot>(Configuration);

            services.AddScoped(typeof(IApplicationService), typeof(ApplicationService));
            services.AddScoped(typeof(IGetWorkItems), typeof(GetWorkItems));
            services.AddScoped(typeof(IDapperRepository), typeof(DapperRepository));
            services.AddScoped(typeof(IGetWorkItemsService), typeof(GetWorkItemsService));
            services.AddScoped(typeof(IAzureDevOpsService), typeof(AzureDevOpsService));
        }
    }
}
