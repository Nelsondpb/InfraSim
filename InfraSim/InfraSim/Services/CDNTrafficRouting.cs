using InfraSim.Models;
using System.Collections.Generic;
using System.Linq;

namespace InfraSim.Services
{
    public class CDNTrafficRouting : TrafficRouting
    {
        public CDNTrafficRouting(List<IServer> servers) : base(servers)
        {
        }

        public override int CalculateRequests(int requestsCount)
        {
            return requestsCount / 2;
        }

        public override List<IServer> ObtainServers()
        {
            return _servers.Where(s => s.ServerType == ServerType.CDN).ToList();
        }
    }
}