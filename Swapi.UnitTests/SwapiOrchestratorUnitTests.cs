using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using SwapiApiChallenge;
using SwapiApiChallenge.Common;
using SwapiApiChallenge.Interfaces;
using Xunit;

namespace Swapi.UnitTests
{
    public class SwapiOrchestratorUnitTests
    {
        private readonly Mock<ISwapiServiceProxy> _serviceProxyFake = new Mock<ISwapiServiceProxy>();
        private readonly Mock<IShipTransformer> _shipTransformerFake = new Mock<IShipTransformer>();

        [Fact]
        public void SwapiOrchestratorUnitTests_Exists()
        {
            ISwapiOrchestrator swapiOrchestrator = new SwapiOrchestrator(_serviceProxyFake.Object, _shipTransformerFake.Object);
            Assert.NotNull(swapiOrchestrator);
        }

        [Fact]
        public void SwapiOrchestratorUnitTests_GivenServiceProxyIsNull_ThrowsNullArgumentException()
        {
            Assert.Throws<ArgumentNullException>(() => new SwapiOrchestrator(null, _shipTransformerFake.Object));

        }

        [Fact]
        public void SwapiOrchestratorUnitTests_GivenShipTransformerIsNull_ThrowsNullArgumentException()
        {
            Assert.Throws<ArgumentNullException>(() => new SwapiOrchestrator(_serviceProxyFake.Object, null));
        }

        [Fact]
        public async Task GetAll_CallsServiceProxyOnce()
        {
            var serviceProxyMock = new Mock<ISwapiServiceProxy>();
            serviceProxyMock.Setup(x => x.GetAll()).Returns(Task.FromResult(It.IsAny<IEnumerable<ShipModel>>())).Verifiable();

            _shipTransformerFake.Setup(x => x.ToViewModel(It.IsAny<IEnumerable<ShipModel>>()))
                .Returns(It.IsAny<IEnumerable<ShipViewModel>>());
             
            var swapiOrchestrator = new SwapiOrchestrator(serviceProxyMock.Object, _shipTransformerFake.Object);

            await swapiOrchestrator.GetAll();

            serviceProxyMock.Verify(x => x.GetAll(), Times.Once);

        }

        [Fact]
        public async Task GetAll_CallsShipTransfomerOnce()
        {
            var shipTransformerMock = new Mock<IShipTransformer>();
            shipTransformerMock.Setup(x => x.ToViewModel(It.IsAny<IEnumerable<ShipModel>>()))
                .Returns(It.IsAny<IEnumerable<ShipViewModel>>()).Verifiable();

            var swapiOrchestrator = new SwapiOrchestrator(_serviceProxyFake.Object, shipTransformerMock.Object);

            await swapiOrchestrator.GetAll();

            shipTransformerMock.Verify(x => x.ToViewModel(It.IsAny<IEnumerable<ShipModel>>()), Times.Once);

        }

    }
}