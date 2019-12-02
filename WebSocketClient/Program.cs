using System;
using WebSocketSharp;

namespace WebSocketClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ws = new WebSocket("wss://localhost:44357/ws"))
            {
                ws.OnMessage += (sender, e) =>
                Console.WriteLine("Received Message: " + e.Data);
                ws.Connect();
                ws.Send("Test Message");
                Console.ReadKey();
            }

            Console.ReadKey();
        }
    }
}
