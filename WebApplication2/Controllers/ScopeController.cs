using EmployeeApp.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Api.Controllers
{
    [ApiController]
    [Route("scope1")]
    public class ScopeController : ControllerBase
    {
        private readonly IScoped _scopedService;
        private readonly ITransient _transientService;
        private readonly ISingleton _singletonService;
        public ScopeController(ITransient transientService, ISingleton singletonService, IScoped scopedService)

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

        [HttpGet("All")]
        public ActionResult<string> GetAll()
        {
            var scopedResult = _scopedService.GetOperationId();
            var scopedResult2 = _scopedService.GetOperationId();


            var singletonResult = _singletonService.GetOperationId();
            var singletonResult2 = _singletonService.GetOperationId();


            var transientResult = _transientService.GetOperationId();
            var transientResult2 = _transientService.GetOperationId();
            var transientResult3 = GetTransient();

            return "test";
        }
    }
}
