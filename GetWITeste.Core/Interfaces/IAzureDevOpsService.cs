using GetWITeste.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GetWITeste.Core.Interfaces
{
    public interface IAzureDevOpsService
    {
        List<WorkItems> ObterWorkItems(int ultimoId);
    }
}
