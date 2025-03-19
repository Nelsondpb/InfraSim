using InfraSim.Models;
using System.Collections.Generic;
using System.Linq;

namespace InfraSim.Services
{
    public class CacheTrafficRouting : TrafficRouting
    {
        public CacheTrafficRouting(List<IServer> servers) : base(servers)
        {
        }

        public override int CalculateRequests(int requestsCount)
        {
            return requestsCount / 3;
        }

        public override List<IServer> ObtainServers()
        {
            return _servers.Where(s => s.ServerType == ServerType.Cache).ToList();
        }
    }
}