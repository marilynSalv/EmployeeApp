using EmployeeApp.Api.Services;
using EmployeeApp.Dal.Dtos;
using EmployeeApp.Dal.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApp.Api.Controllers
{
    [ApiController]
    [Route("scope")]
    public class ScopeController : ControllerBase
    {
        private readonly IScoped _scopedService;
        private readonly IScoped _scopedService2;
        private readonly ITransient _transientService;
        private readonly ITransient _transientService2;
        private readonly ISingleton _singletonService;
        private readonly ISingleton _singletonService2;
        private readonly ISprocRepository _sprocRepository;

        public ScopeController(
            ITransient transientService,
            ITransient transientService2,
            ISingleton singletonService,
            ISingleton singletonService2,
            IScoped scopedService,
            IScoped scopedService2,
            ISprocRepository sprocRepository)

        {
            _scopedService = scopedService;
            _scopedService2 = scopedService2;
            _transientService = transientService;
            _transientService2 = transientService2;
            _singletonService = singletonService;
            _singletonService2 = singletonService2;
            _sprocRepository = sprocRepository;
        }

        [HttpGet("All")]
        public ActionResult<List<RequestDto>> GetAll()
        {
            var call1 = new RequestDto
            {
                Scoped = _scopedService.GetOperationId(),
                Singleton = _singletonService.GetOperationId(),
                Transient = _transientService.GetOperationId(),
            };
                                                                                                                                 
            var call2 = new RequestDto
            {
                Scoped = _scopedService2.GetOperationId(),
                Singleton = _singletonService2.GetOperationId(),
                Transient = _transientService2.GetOperationId(),
            };

            return new List<RequestDto> { call1, call2 };
        }

        [HttpGet("TestSproc")]
        public async Task GetTestSproc()
        {
            await _sprocRepository.ReadSprocTest();
        }
    }
}
