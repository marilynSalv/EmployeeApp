using EmployeeApp.Api.Services;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<string> GetAll()
        {
            var scopedResult = _scopedService.GetOperationId();
            var scopedResult2 = _scopedService2.GetOperationId();


            var singletonResult = _singletonService.GetOperationId();
            var singletonResult2 = _singletonService2.GetOperationId();


            var transientResult = _transientService.GetOperationId();
            var transientResult2 = _transientService2.GetOperationId();

            return "test";
        }
    }
}
