using GetWITeste.Core.Entities;
using GetWITeste.Core.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using System.Linq;

namespace GetWITeste.Infra.Api
{
    public class AzureDevOpsService : IAzureDevOpsService
    {
        private readonly AppSettings _config;
        private readonly string _uri;
        private readonly string _token;
        private readonly string _projeto;

        public AzureDevOpsService(IOptions<AppSettings> config)
        {
            _config = config.Value;
            _uri = $"{_config.Uri}{_config.NomeOrganizacao}";
            _token = _config.TokenAcesso;
            _projeto = _config.NomeProjeto;
        }

        public List<WorkItems> ObterWorkItems(int ultimoId)
        {
            // Recupera os work items no azure devops
            var WItems = new List<WorkItems>();
            var uri = new Uri(_uri);
            string personalAccessToken = _token;
            string project = _projeto;

            VssBasicCredential credentials = new VssBasicCredential("", _token);

            Wiql wiql = new Wiql()
            {
                Query = "Select [Id], [Title], [Work Item Type], [Changed Date] " +
                    "From WorkItems " +
                    "Where [System.TeamProject] = '" + project + "' " +
                    "And [Id] > " + ultimoId + " " +
                    "Order By [Changed Date] Desc"
            };

            using (WorkItemTrackingHttpClient workItemTrackingHttpClient = new WorkItemTrackingHttpClient(uri, credentials))
            {
                WorkItemQueryResult workItemQueryResult = workItemTrackingHttpClient.QueryByWiqlAsync(wiql).Result;

                if (workItemQueryResult.WorkItems.Any())
                {
                    List<int> list = new List<int>();
                    foreach (var item in workItemQueryResult.WorkItems)
                    {
                        list.Add(item.Id);
                    }
                    int[] arr = list.ToArray();

                    string[] fields = new string[4];
                    fields[0] = "System.Id";
                    fields[1] = "System.Title";
                    fields[2] = "System.WorkItemType";
                    fields[3] = "System.ChangedDate";

                    var workItems = workItemTrackingHttpClient.GetWorkItemsAsync(arr, fields, workItemQueryResult.AsOf).Result;

                    Console.WriteLine("Query Results: {0} items found", workItems.Count);

                    foreach (var workItem in workItems)
                    {
                        var WItem = new WorkItems
                        {
                            Id = workItem.Id,
                            Titulo = workItem.Fields["System.Title"].ToString(),
                            Tipo = workItem.Fields["System.WorkItemType"].ToString(),
                            Data = (DateTime)workItem.Fields["System.ChangedDate"]
                        };

                        WItems.Add(WItem);
                    }                    
                }

                return WItems;
            }
        }
    }
}
