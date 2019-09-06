using GetWITeste.Core.Entities;
using GetWITeste.Core.Interfaces;
using Microsoft.Extensions.Options;
using System;

namespace GetWITeste.Infra.Api
{
    public class AzureDevOpsService : IAzureDevOpsService
    {
        private readonly AppSettings _config;

        public AzureDevOpsService(IOptions<AppSettings> config)
        {
            _config = config.Value;
        }

        public WorkItems ObterWorkItems()
        {
            // Recupera os work items no azure devops
            throw new NotImplementedException();
        }
    }
}
