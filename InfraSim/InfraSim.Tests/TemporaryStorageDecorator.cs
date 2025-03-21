using InfraSim.Models;
using Xunit;

namespace InfraSim.Tests
{
    public class TemporaryStorageDecoratorTests
    {
        [Fact]
        public void TemporaryStorageDecorator_ShouldIncreaseMaximumRequestsAndCost()
        {
            IServerCapability basicServer = new ServerCapability();
            IServerCapability serverWithTemporaryStorage = new TemporaryStorageDecorator(basicServer);

            Assert.Equal(1100, serverWithTemporaryStorage.MaximumRequests);
            Assert.Equal(3500, serverWithTemporaryStorage.Cost);
        }
    }
}