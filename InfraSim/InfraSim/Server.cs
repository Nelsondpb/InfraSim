namespace InfraSim.Models
{
    public class Server : IServer
    {
        public void HandleRequests(int requestsCount)
        {
            Console.WriteLine($"Servidor está processando {requestsCount} requisições.");
        }
    }
}