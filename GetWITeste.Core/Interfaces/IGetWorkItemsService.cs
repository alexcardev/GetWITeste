﻿using GetWITeste.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetWITeste.Core.Interfaces
{
    public interface IGetWorkItemsService
    {
        void Processar();
        List<WorkItems> ListarWorkitems();
    }
}
