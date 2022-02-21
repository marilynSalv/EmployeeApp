using EmployeeApp.Api.Services;
using EmployeeApp.Dal.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.AutoMock;
using System;
using System.Threading.Tasks;

namespace EmployeeApp.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private AutoMocker _mocker;
        private AuthenticationService _authenticationService;
        private Mock<IAuthenticationRepository> _authenticationRepository;

        [TestInitialize]
        public void SetUp()
        {
            _mocker = new AutoMocker();
            _authenticationRepository = _mocker.GetMock<IAuthenticationRepository>();
            _authenticationService = _mocker.CreateInstance<AuthenticationService>();
        }

        [TestMethod]
        public async Task Test1()
        {
            _authenticationRepository.Setup(x => x.AddRefreshToken(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>()));
            await _authenticationService.AddRefreshToken("test", "test");

            _authenticationRepository.Verify(x => x.AddRefreshToken(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>()), Times.zero);
        }
    }
}