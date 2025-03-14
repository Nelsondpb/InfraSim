namespace InfraSim.Models
{
    public interface IServer
    {
        ServerType ServerType { get; }
        void HandleRequests(int requestsCount);
    }
}