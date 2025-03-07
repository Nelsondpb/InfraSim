using InfraSim.Services;
using InfraSim.Models;
using Xunit;
using System.Collections.Generic;

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
    }
}