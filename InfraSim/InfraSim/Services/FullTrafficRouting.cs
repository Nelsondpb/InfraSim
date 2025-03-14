using InfraSim.Models;
using System.Collections.Generic;
using System.Linq;

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