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
            // Recupera os últimos work items de um projeto específico no azure devops e grava no banco de dados.
            var ultimoId = _repository.ObterUltimoIdWorkItem();

            var workItens = _azureDevOpsService.ObterWorkItems(ultimoId);

            foreach(var item in workItens)
            {
                var workItem = new WorkItems
                {
                    Id = item.Id,
                    Tipo = item.Tipo,
                    Titulo = item.Titulo,
                    DataCriacao = item.DataCriacao
                };

                _repository.IncluirWorkItem(workItem);
            }

            var works = _repository.ListarWorkitems();
        }
    }
}
