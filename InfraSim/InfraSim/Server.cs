namespace InfraSim.Models
{
    public class Server : IServer
    {
        public ServerType ServerType { get; }

        public Server(ServerType serverType)
        {
            ServerType = serverType;
        }

        public void HandleRequests(int requestsCount)
        {
            Console.WriteLine($"Servidor do tipo {ServerType} está processando {requestsCount} requisições.");
        }
    }
}