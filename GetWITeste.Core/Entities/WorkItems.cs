using System;
using System.Collections.Generic;
using System.Text;

namespace GetWITeste.Core.Entities
{
    public class WorkItems
    {
        public int? Id { get; set; }
        public string Tipo { get; set; }
        public string Titulo { get; set; }
        public DateTime Data { get; set; }
    }
}
