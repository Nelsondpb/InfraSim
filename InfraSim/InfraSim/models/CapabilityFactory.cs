namespace InfraSim.Models
{
    public class CapabilityFactory : ICapabilityFactory
    {
        public IServerCapability Create(ServerType serverType)
        {
            IServerCapability capability = new ServerCapability();

            switch (serverType)
            {
                case ServerType.Cache:
                    capability = new TemporaryStorageDecorator(capability);
                    break;

                case ServerType.LoadBalancer:
                    capability = new TrafficDistributionDecorator(capability);
                    break;

                case ServerType.CDN:
                    capability = new TemporaryStorageDecorator(capability);
                    capability = new TrafficDistributionDecorator(capability);
                    capability = new EdgeServerDecorator(capability);
                    break;

                case ServerType.Server:
                default:
                    break;
            }

            return capability;
        }
    }
}