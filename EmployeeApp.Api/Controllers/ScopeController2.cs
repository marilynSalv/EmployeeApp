using EmployeeApp.Api.Services;
using EmployeeApp.Dal.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmployeeApp.Api.Controllers
{
    [ApiController]
    [Route("scope2")]
    public class ScopeController2 : ControllerBase
    {
        private readonly IScoped _scopedService;
        private readonly IScoped _scopedService2;
        private readonly ITransient _transientService;
        private readonly ITransient _transientService2;
        private readonly ISingleton _singletonService;
        private readonly ISingleton _singletonService2;

        public ScopeController2(ITransient transientService,
            ITransient transientService2,
            ISingleton singletonService,
            ISingleton singletonService2,
            IScoped scopedService,
            IScoped scopedService2)

        {
            _scopedService = scopedService;
            _scopedService2 = scopedService2;
            _transientService = transientService;
            _transientService2 = transientService2;
            _singletonService = singletonService;
            _singletonService2 = singletonService2;
        }

        [HttpGet("transient")]
        public ActionResult<string> GetTransient()
        {
            var result = _transientService.GetOperationId();
            return result;
        }

        [HttpGet("singleton")]
        public ActionResult<string> GetSingleton()
        {
            var result = _singletonService.GetOperationId();
            return result;
        }

        [HttpGet("scoped")]
        public ActionResult<string> GetScoped()
        {
            var result = _scopedService.GetOperationId();
            return result;
        }

        [HttpGet("All")]
        public ActionResult<List<RequestDto>> GetAll()
        {
            var request1 = new RequestDto
            {
                Scoped = _scopedService.GetOperationId(),
                Singleton = _singletonService.GetOperationId(),
                Transient = _transientService.GetOperationId(),
            };

            var request2 = new RequestDto
            {
                Scoped = _scopedService2.GetOperationId(),
                Singleton = _singletonService2.GetOperationId(),
                Transient = _transientService2.GetOperationId(),
            };

            return new List<RequestDto> { request1, request2 };
        }
    }
}
