using System;
using System.Threading.Tasks;
using Moq;
using SwapiApiChallenge;
using SwapiApiChallenge.Interfaces;
using Xunit;

namespace Swapi.UnitTests
{
    public class ServiceProxyUnitTests
    {

        private readonly Mock<IAppConfigReader> _appReaderFake = new Mock<IAppConfigReader>();

        [Fact]
        public void SwapiOrchestratorUnitTests_Exists()
        {
            ISwapiServiceProxy serviceProxy = new ServiceProxy(_appReaderFake.Object);
            Assert.NotNull(serviceProxy);
        }

        [Fact]
        public void SwapiOrchestratorUnitTests_GivenNullConfigReader_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new ServiceProxy(null));
        }


        [Fact]
        public async Task Sw()
        {
            const int idStub = 9;

            _appReaderFake.Setup(x => x.GetApiUrl()).Returns("htt");
            var serviceProxy = new ServiceProxy(_appReaderFake.Object);
            var result =await serviceProxy.Get(idStub);

        }

    }
}