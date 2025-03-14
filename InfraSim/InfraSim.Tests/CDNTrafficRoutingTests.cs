using InfraSim.Services;
using InfraSim.Models;
using Xunit;
using System.Collections.Generic;
using Moq;

namespace InfraSim.Tests
{
    public class CDNTrafficRoutingTests
    {
        [Fact]
        public void TestCDNRequestCount_ShouldReturnHalfOfRequests()
        {
            var mockServer1 = new Mock<IServer>();
            var mockServer2 = new Mock<IServer>();

            mockServer1.Setup(s => s.ServerType).Returns(ServerType.CDN);
            mockServer2.Setup(s => s.ServerType).Returns(ServerType.CDN);

            var servers = new List<IServer> { mockServer1.Object, mockServer2.Object };
            var cdnTrafficRouting = new CDNTrafficRouting(servers);

            int requests = cdnTrafficRouting.CalculateRequests(100);

            Assert.Equal(50, requests);
        }

        [Fact]
        public void TestCDNObtainServers_ShouldReturnOnlyCDNServers()
        {
            var mockServer1 = new Mock<IServer>();
            var mockServer2 = new Mock<IServer>();
            var mockServer3 = new Mock<IServer>();

            mockServer1.Setup(s => s.ServerType).Returns(ServerType.CDN);
            mockServer2.Setup(s => s.ServerType).Returns(ServerType.CDN);
            mockServer3.Setup(s => s.ServerType).Returns(ServerType.Server);

            var servers = new List<IServer> { mockServer1.Object, mockServer2.Object, mockServer3.Object };
            var cdnTrafficRouting = new CDNTrafficRouting(servers);

            var obtainedServers = cdnTrafficRouting.ObtainServers();

            Assert.Equal(2, obtainedServers.Count);
            Assert.Contains(mockServer1.Object, obtainedServers);
            Assert.Contains(mockServer2.Object, obtainedServers);
            Assert.DoesNotContain(mockServer3.Object, obtainedServers);
        }
    }
}