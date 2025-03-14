using InfraSim.Models;

namespace InfraSim.Services
{
    public class CacheTrafficRouting : TrafficRouting
    {
        public CacheTrafficRouting(List<IServer> servers) : base(servers)
        {
        }
    }
}