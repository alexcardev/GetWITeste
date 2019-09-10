using GetWITeste.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetWITeste.Core.Interfaces
{
    public interface IDapperRepository
    {
        void IncluirWorkItem(WorkItems workItems);
        List<WorkItems> ListarWorkitems();
        int ObterUltimoIdWorkItem();
        void AddLogAnalise(LogAnalise entity);
        void Dispose();
    }
}
