using InfraSim.Models;
using Xunit;

namespace InfraSim.Tests
{
    public class ServerCapabilityTests
    {
        [Fact]
        public void ServerCapability_ShouldHaveDefaultValues()
        {
            IServerCapability server = new ServerCapability();
            Assert.Equal(1000, server.MaximumRequests);
            Assert.Equal(2500, server.Cost);
        }
    }
}