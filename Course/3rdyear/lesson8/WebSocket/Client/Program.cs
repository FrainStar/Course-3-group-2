using System.Net.WebSockets;
using System.Text;

namespace Client
{
    class Program
    {
        private static readonly ClientWebSocket Client = new ClientWebSocket();
        
        
        static async Task Main(string[] args)
        {
            Console.WriteLine("Введите имя пользователя: ");
            string? userName = Console.ReadLine();
            
            Uri uri = new Uri($"ws://localhost:5180/ws?username={userName}");
            
            await Client.ConnectAsync(uri, CancellationToken.None);

            var receive = ReceiveMessage();
            if (Client.State == WebSocketState.Open)
            {
                Console.WriteLine("Connection installed");
            }
            else
            {
                Console.WriteLine("Connection lost");
            }

            Console.Write("Введите exit для выхода: ");
            while (true)
            {
                string? message = Console.ReadLine();
                if (message?.ToLower() == "exit")
                {
                    await Client.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                    break;
                }
                
                await SendMessage(message);
            }

            await receive;
        }


        private static async Task SendMessage(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            await Client.SendAsync(new ArraySegment<byte>(data), 
                WebSocketMessageType.Text, 
                true, 
                CancellationToken.None);
        }
        
        private static async Task ReceiveMessage()
        {
            byte[] buffer = new byte[1024 * 4];

            while (Client.State == WebSocketState.Open)
            {
                var result = await Client.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, result.Count));
            }
            
        }
    }
}