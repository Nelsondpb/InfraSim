using InfraSim.Services;
using InfraSim.Models;
using Xunit;
using System.Collections.Generic;
using Moq;

namespace InfraSim.Tests
{
    public class TrafficRoutingTests
    {
        [Fact]
        public void TestRouteTraffic_CallsCalculateRequestsAndObtainServers()
        {
            var mockServer1 = new Mock<IServer>();
            var mockServer2 = new Mock<IServer>();

            mockServer1.Setup(s => s.ServerType).Returns(ServerType.Server);
            mockServer2.Setup(s => s.ServerType).Returns(ServerType.Server);

            var servers = new List<IServer> { mockServer1.Object, mockServer2.Object };

            var mockTrafficRouting = new Mock<TrafficRouting>(servers) { CallBase = true };

            mockTrafficRouting.Setup(t => t.CalculateRequests(It.IsAny<int>())).Returns(100);
            mockTrafficRouting.Setup(t => t.ObtainServers()).Returns(servers);

            mockTrafficRouting.Object.RouteTraffic(100);

            mockTrafficRouting.Verify(t => t.CalculateRequests(100), Times.Once);
            mockTrafficRouting.Verify(t => t.ObtainServers(), Times.Once);
            mockServer1.Verify(s => s.HandleRequests(50), Times.Once);
            mockServer2.Verify(s => s.HandleRequests(50), Times.Once);
        }
    }
}