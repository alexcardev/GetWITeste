using System;
using System.Collections.Generic;
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

        public List<WorkItems> ListarWorkitems()
        {
            return _repository.ListarWorkitems();
        }

        public void Processar()
        {
            try
            {
                ObterWorkItems();
            }
            catch (Exception ex)
            {
                var logAnalise = new LogAnalise
                {
                    TipoLog = 1,
                    Mensagem = ex.Message,
                    Data = DateTime.Now
                };

                _repository.AddLogAnalise(logAnalise);
            }
            
        }

        private void ObterWorkItems()
        {
            // Recupera os últimos work items de um projeto específico no azure devops e grava no banco de dados.
            var ultimoId = _repository.ObterUltimoIdWorkItem();

            var workItems = _azureDevOpsService.ObterWorkItems(ultimoId);

            foreach(var item in workItems)
            {
                var workItem = new WorkItems
                {
                    Id = item.Id,
                    Tipo = item.Tipo,
                    Titulo = item.Titulo,
                    Data = item.Data
                };

                _repository.IncluirWorkItem(workItem);
            }

            var works = _repository.ListarWorkitems();
        }
    }
}
