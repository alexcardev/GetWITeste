using GetWITeste.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetWITeste.Core.Interfaces
{
    public interface IDapperRepository
    {
        void InserirWorkItem(WorkItems workItems);
        List<WorkItems> ListarWorkitems();
        List<WorkItems> ListarWorkitemsPorTipo();
        void AddLogAnalise(LogAnalise entity);
    }
}
