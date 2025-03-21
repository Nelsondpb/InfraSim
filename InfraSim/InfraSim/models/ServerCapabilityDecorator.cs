namespace InfraSim.Models
{
    public abstract class ServerCapabilityDecorator : IServerCapability
    {
        protected IServerCapability _capability;

        public ServerCapabilityDecorator(IServerCapability capability)
        {
            _capability = capability;
        }

        public virtual long MaximumRequests => _capability.MaximumRequests;
        public virtual int Cost => _capability.Cost;
    }
}