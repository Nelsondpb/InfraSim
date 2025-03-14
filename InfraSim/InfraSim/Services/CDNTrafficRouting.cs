using InfraSim.Models;

namespace InfraSim.Services
{
    public class CDNTrafficRouting : TrafficRouting
    {
        public CDNTrafficRouting(List<IServer> servers) : base(servers)
        {
        }
    }
}