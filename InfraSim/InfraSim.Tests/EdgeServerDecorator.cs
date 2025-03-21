using InfraSim.Models;
using Xunit;

namespace InfraSim.Tests
{
    public class EdgeServerDecoratorTests
    {
        [Fact]
        public void EdgeServerDecorator_ShouldIncreaseMaximumRequestsAndCost()
        {
            IServerCapability basicServer = new ServerCapability();
            IServerCapability serverWithEdgeServer = new EdgeServerDecorator(basicServer);

            Assert.Equal(2000, serverWithEdgeServer.MaximumRequests);
            Assert.Equal(52500, serverWithEdgeServer.Cost);
        }
    }
}