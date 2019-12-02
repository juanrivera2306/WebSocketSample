using System;
using WebSocketSharp;

namespace WebScoketClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ws = new WebSocket("wss://localhost:44383/ws"))
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
