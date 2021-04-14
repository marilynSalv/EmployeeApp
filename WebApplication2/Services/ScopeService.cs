using System;

namespace EmployeeApp.Api.Services
{
    public class ScopeService : IScoped, ITransient, ISingleton
    {
        public string OperationId { get; } = Guid.NewGuid().ToString()[^6..];


        public string GetOperationId()
        {
            return OperationId;
        }
    }
}
