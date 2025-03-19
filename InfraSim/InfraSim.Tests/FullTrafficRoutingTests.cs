using InfraSim.Services;
using InfraSim.Models;
using Xunit;
using System.Collections.Generic;
using Moq;

namespace InfraSim.Tests
{
    public class FullTrafficRoutingTests
    {
        [Fact]
        public void TestRequestCount_ShouldReturnCorrectRequestCount()
        {
            var mockServer1 = new Mock<IServer>();
            var mockServer2 = new Mock<IServer>();
            var mockServer3 = new Mock<IServer>();

            mockServer1.Setup(s => s.ServerType).Returns(ServerType.Server);
            mockServer2.Setup(s => s.ServerType).Returns(ServerType.Server);
            mockServer3.Setup(s => s.ServerType).Returns(ServerType.Server);

            var servers = new List<IServer> { mockServer1.Object, mockServer2.Object, mockServer3.Object };
            var fullTrafficRouting = new FullTrafficRouting(servers);

            int requests = fullTrafficRouting.CalculateRequests(100);

            Assert.Equal(100, requests);
        }

        [Fact]
        public void TestRequestDistribution_ShouldDistributeRequestsEqually()
        {
            var mockServer1 = new Mock<IServer>();
            var mockServer2 = new Mock<IServer>();
            var mockServer3 = new Mock<IServer>();

            mockServer1.Setup(s => s.ServerType).Returns(ServerType.Server);
            mockServer2.Setup(s => s.ServerType).Returns(ServerType.Server);
            mockServer3.Setup(s => s.ServerType).Returns(ServerType.Server);

            var servers = new List<IServer> { mockServer1.Object, mockServer2.Object, mockServer3.Object };
            var fullTrafficRouting = new FullTrafficRouting(servers);

            fullTrafficRouting.RouteTraffic(100);

            mockServer1.Verify(s => s.HandleRequests(34), Times.Once);
            mockServer2.Verify(s => s.HandleRequests(33), Times.Once);
            mockServer3.Verify(s => s.HandleRequests(33), Times.Once);
        }

        [Fact]
        public void TestObtainServers_ShouldReturnCorrectServers()
        {
            var mockServer1 = new Mock<IServer>();
            var mockServer2 = new Mock<IServer>();
            var mockServer3 = new Mock<IServer>();

            mockServer1.Setup(s => s.ServerType).Returns(ServerType.Server);
            mockServer2.Setup(s => s.ServerType).Returns(ServerType.Server);
            mockServer3.Setup(s => s.ServerType).Returns(ServerType.Server);

            var servers = new List<IServer> { mockServer1.Object, mockServer2.Object, mockServer3.Object };
            var fullTrafficRouting = new FullTrafficRouting(servers);

            var obtainedServers = fullTrafficRouting.ObtainServers();

            Assert.Equal(3, obtainedServers.Count);
            Assert.Contains(mockServer1.Object, obtainedServers);
            Assert.Contains(mockServer2.Object, obtainedServers);
            Assert.Contains(mockServer3.Object, obtainedServers);
        }
    }
}