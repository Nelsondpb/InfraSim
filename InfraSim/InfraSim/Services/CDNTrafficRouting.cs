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

        public override void SendRequestsToServers(int requests, List<IServer> servers)
        {
            int requestsPerServer = requests / servers.Count;
            int remainder = requests % servers.Count;

            for (int i = 0; i < servers.Count; i++)
            {
                int requestsToHandle = requestsPerServer + (i < remainder ? 1 : 0);
                servers[i].HandleRequests(requestsToHandle);
            }
        }
    }
}