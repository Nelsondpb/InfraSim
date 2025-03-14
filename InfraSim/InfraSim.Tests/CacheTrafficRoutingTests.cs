using InfraSim.Services;
using InfraSim.Models;
using Xunit;
using System.Collections.Generic;
using Moq;

namespace InfraSim.Tests
{
    public class CacheTrafficRoutingTests
    {
        [Fact]
        public void TestCacheRequestCount_ShouldReturnOneThirdOfRequests()
        {
            var mockServer1 = new Mock<IServer>();
            var mockServer2 = new Mock<IServer>();

            mockServer1.Setup(s => s.ServerType).Returns(ServerType.Cache);
            mockServer2.Setup(s => s.ServerType).Returns(ServerType.Cache);

            var servers = new List<IServer> { mockServer1.Object, mockServer2.Object };
            var cacheTrafficRouting = new CacheTrafficRouting(servers);

            int requests = cacheTrafficRouting.CalculateRequests(100);

            Assert.Equal(33, requests); 
        }

        [Fact]
        public void TestCacheObtainServers_ShouldReturnOnlyCacheServers()
        {
            var mockServer1 = new Mock<IServer>();
            var mockServer2 = new Mock<IServer>();
            var mockServer3 = new Mock<IServer>();

            mockServer1.Setup(s => s.ServerType).Returns(ServerType.Cache);
            mockServer2.Setup(s => s.ServerType).Returns(ServerType.Cache);
            mockServer3.Setup(s => s.ServerType).Returns(ServerType.Server);

            var servers = new List<IServer> { mockServer1.Object, mockServer2.Object, mockServer3.Object };
            var cacheTrafficRouting = new CacheTrafficRouting(servers);

            var obtainedServers = cacheTrafficRouting.ObtainServers();

            Assert.Equal(2, obtainedServers.Count);
            Assert.Contains(mockServer1.Object, obtainedServers);
            Assert.Contains(mockServer2.Object, obtainedServers);
            Assert.DoesNotContain(mockServer3.Object, obtainedServers);
        }
    }
}