using EmployeeApp.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Api.Controllers
{
    [ApiController]
    [Route("scope2")]
    public class ScopeController2 : ControllerBase
    {
        private readonly IScoped _scopedService;
        private readonly ITransient _transientService;
        private readonly ISingleton _singletonService;

        public ScopeController2(IScoped scopedService, ITransient transientService, ISingleton singletonService)
        {
            _scopedService = scopedService;
            _transientService = transientService;
            _singletonService = singletonService;
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
    }
}
