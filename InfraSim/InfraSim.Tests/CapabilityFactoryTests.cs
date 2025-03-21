using InfraSim.Models;
using Xunit;

namespace InfraSim.Tests
{
    public class CapabilityFactoryTests
    {
        [Fact]
        public void Create_ShouldReturnBasicServerCapability_ForServerTypeServer()
        {
            var factory = new CapabilityFactory();
            var capability = factory.Create(ServerType.Server);

            Assert.Equal(1000, capability.MaximumRequests);
            Assert.Equal(2500, capability.Cost);
        }

        [Fact]
        public void Create_ShouldReturnCacheCapability_ForServerTypeCache()
        {
            var factory = new CapabilityFactory();
            var capability = factory.Create(ServerType.Cache);

            Assert.Equal(1100, capability.MaximumRequests);
            Assert.Equal(3500, capability.Cost);
        }

        [Fact]
        public void Create_ShouldReturnLoadBalancerCapability_ForServerTypeLoadBalancer()
        {
            var factory = new CapabilityFactory();
            var capability = factory.Create(ServerType.LoadBalancer);

            Assert.Equal(11000, capability.MaximumRequests); 
            Assert.Equal(4000, capability.Cost);
        }

        [Fact]
        public void Create_ShouldReturnCDNCapability_ForServerTypeCDN()
        {
            var factory = new CapabilityFactory();
            var capability = factory.Create(ServerType.CDN);

            Assert.Equal(12100, capability.MaximumRequests); 
            Assert.Equal(55000, capability.Cost);
        }
    }
}