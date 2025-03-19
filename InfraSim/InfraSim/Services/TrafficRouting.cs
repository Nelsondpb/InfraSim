using InfraSim.Models;
using System.Collections.Generic;

namespace InfraSim.Services
{
    public abstract class TrafficRouting
    {
        protected List<IServer> _servers;

        public TrafficRouting(List<IServer> servers)
        {
            _servers = servers;
        }

        public abstract int CalculateRequests(int requestsCount);

        public abstract List<IServer> ObtainServers();

        public void SendRequestsToServers(int requests, List<IServer> servers)
        {
            int requestsPerServer = requests / servers.Count;
            int remainder = requests % servers.Count;

            for (int i = 0; i < servers.Count; i++)
            {
                int requestsToHandle = requestsPerServer + (i < remainder ? 1 : 0);
                servers[i].HandleRequests(requestsToHandle);
            }
        }

        public void RouteTraffic(int requestsCount)
        {
            int requests = CalculateRequests(requestsCount);
            List<IServer> servers = ObtainServers();
            SendRequestsToServers(requests, servers);
        }
    }
}