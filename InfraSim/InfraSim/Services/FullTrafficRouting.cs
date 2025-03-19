using InfraSim.Models;
using System.Collections.Generic;

namespace InfraSim.Services
{
    public class FullTrafficRouting : TrafficRouting
    {
        public FullTrafficRouting(List<IServer> servers) : base(servers)
        {
        }

        public override int CalculateRequests(int requestsCount)
        {
            return requestsCount;
        }

        public override List<IServer> ObtainServers()
        {
            return _servers;
        }
    }
}