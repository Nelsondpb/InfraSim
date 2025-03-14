using InfraSim.Models;

namespace InfraSim.Services
{
    public class FullTrafficRouting : TrafficRouting
    {
        public FullTrafficRouting(List<IServer> servers) : base(servers)
        {
        }
    }
}