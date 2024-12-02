using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : Controller
    {
        private static ConcurrentDictionary<string, WebSocket> _connectedClients = 
            new ConcurrentDictionary<string, WebSocket>();

        [HttpGet("/ws")]
        public async Task Get()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                var username = HttpContext.Request.Query["username"];
                WebSocket socket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                _connectedClients.TryAdd(username, socket);
                Console.WriteLine($"Connected to {username}");
                await BroadcastMessage($"{username} is connected!");

                await RecieveMessage(username, socket);
            }
            else
            {
                HttpContext.Response.StatusCode = 400;
            }
        }

        private async Task RecieveMessage(string username, WebSocket socket)
        {
            var buffer = new byte[1024];
            WebSocketReceiveResult result = await 
                socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            while (!result.CloseStatus.HasValue)
            {
                var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                await BroadcastMessage($"{username}: {message}");
                
                result = await socket.ReceiveAsync(
                    new ArraySegment<byte>(buffer), CancellationToken.None);
                
                _connectedClients.TryRemove(username, out _);
                
                await BroadcastMessage($"{username} is disconnected!");
                
                await socket.CloseAsync(
                    result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
            }
        }
        
        private async Task BroadcastMessage(string message)
        {
            var buffer = Encoding.UTF8.GetBytes(message);

            foreach (var client in _connectedClients.Values)
            {
                if (client.State == WebSocketState.Open)
                {
                    await client.SendAsync(new ArraySegment<byte>(buffer), 
                        WebSocketMessageType.Text, true, CancellationToken.None);
                }
            }
        }
    }
}