using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GetWITeste.Core.Entities;
using GetWITeste.Core.Interfaces;
using GetWITeste.Core.Services;
using GetWITeste.Infra.Api;
using GetWITeste.Infra.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GetWIApiTeste
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            //Configuration = configuration;
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        readonly string PermissaoAcesso = "_permissaoAcesso";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(PermissaoAcesso,
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200");
                });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.Configure<AppSettings>(Configuration.GetSection("Configuration"));
            services.AddScoped(typeof(IGetWorkItemsService), typeof(GetWorkItemsService));
            services.AddScoped(typeof(IAzureDevOpsService), typeof(AzureDevOpsService));
            services.AddScoped(typeof(IDapperRepository), typeof(DapperRepository));            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(PermissaoAcesso);

            app.UseMvc();
        }
    }
}
