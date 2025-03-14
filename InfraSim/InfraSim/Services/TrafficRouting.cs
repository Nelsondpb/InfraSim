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

        public abstract void SendRequestsToServers(int requests, List<IServer> servers);

        public void RouteTraffic(int requestsCount)
        {
            int requests = CalculateRequests(requestsCount);
            List<IServer> servers = ObtainServers();
            SendRequestsToServers(requests, servers);
        }
    }
}