using GetWITeste.Core.Interfaces;
using GetWITeste.Interfaces;

namespace GetWITeste.Services
{
    public class GetWorkItems : IGetWorkItems
    {
        private readonly IGetWorkItemsService _service;

        public GetWorkItems(IGetWorkItemsService service)
        {
            _service = service;
        }

        public void Processar()
        {
            _service.Processar();
        }
    }
}
