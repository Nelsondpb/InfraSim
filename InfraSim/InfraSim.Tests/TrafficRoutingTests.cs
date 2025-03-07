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
        public void TestRequestCount_ShouldReturnCorrectRequestCount()
        {
            
            var servers = new List<IServer> { new Server(), new Server(), new Server() };
            var trafficRouting = new TrafficRouting(servers);

            
            int requests = trafficRouting.CalculateRequests(100);

            
            Assert.Equal(100, requests);
        }

        [Fact]
        public void TestRequestDistribution_ShouldDistributeRequestsEqually()
        {
            
            var mockServer1 = new Mock<IServer>();
            var mockServer2 = new Mock<IServer>();
            var mockServer3 = new Mock<IServer>();

            var servers = new List<IServer> { mockServer1.Object, mockServer2.Object, mockServer3.Object };
            var trafficRouting = new TrafficRouting(servers);

            
            trafficRouting.RouteTraffic(100);

            
            mockServer1.Verify(s => s.HandleRequests(34), Times.Once);
            mockServer2.Verify(s => s.HandleRequests(33), Times.Once);
            mockServer3.Verify(s => s.HandleRequests(33), Times.Once);
        }
    }
}