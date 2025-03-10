namespace InfraSim.Models
{
    public interface IServer
    {
        void HandleRequests(int requestsCount);
    }
}