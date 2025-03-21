using InfraSim.Models;
using Xunit;

namespace InfraSim.Tests
{
    public class TrafficDistributionDecoratorTests
    {
        [Fact]
        public void TrafficDistributionDecorator_ShouldIncreaseMaximumRequestsAndCost()
        {
            IServerCapability basicServer = new ServerCapability();
            IServerCapability serverWithTrafficDistribution = new TrafficDistributionDecorator(basicServer);

            Assert.Equal(11000, serverWithTrafficDistribution.MaximumRequests);
            Assert.Equal(4000, serverWithTrafficDistribution.Cost);
        }
    }
}