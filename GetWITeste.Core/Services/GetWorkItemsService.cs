using GetWITeste.Core.Entities;
using GetWITeste.Core.Interfaces;
using Microsoft.Extensions.Options;

namespace GetWITeste.Core.Services
{
    public class GetWorkItemsService : IGetWorkItemsService
    {
        private readonly IDapperRepository _repository;
        private readonly IAzureDevOpsService _azureDevOpsService;
        private readonly AppSettings _config;

        public GetWorkItemsService(
            IDapperRepository repository,
            IAzureDevOpsService azureDevOpsService,
            IOptions<AppSettings> config)
        {
            _repository = repository;
            _azureDevOpsService = azureDevOpsService;
            _config = config.Value;
        }

        public void Processar()
        {
            ObterWorkItems();
        }

        private void ObterWorkItems()
        {
            // Recupera os work items no azure devops e grava no banco de dados.
        }
    }
}
