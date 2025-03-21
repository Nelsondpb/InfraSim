namespace InfraSim.Models
{
    public class ServerCapability : IServerCapability
    {
        public long MaximumRequests => 1000;
        public int Cost => 2500;
    }
}