using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetWITeste.Core.Entities;
using GetWITeste.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GetWIApiTeste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkItemsController : ControllerBase
    {
        private readonly IGetWorkItemsService _service;

        public WorkItemsController(IGetWorkItemsService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<WorkItems>> Get()
        {
            return _service.ListarWorkitems();

        }
    }
}