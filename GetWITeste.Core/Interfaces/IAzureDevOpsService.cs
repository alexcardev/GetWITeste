using GetWITeste.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetWITeste.Core.Interfaces
{
    public interface IAzureDevOpsService
    {
        WorkItems ObterWorkItems();
    }
}
