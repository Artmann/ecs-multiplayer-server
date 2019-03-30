using Game;
using System;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Server
{
    class Server
    {
        static void Main(string[] args)
        {
            var game = new Game.Game();
            var webSocketServer = new WebSocketServer(4949);

            webSocketServer.AddWebSocketService<SocketManager>("/game", () => new SocketManager(game));

            Console.WriteLine("Starting server");
            webSocketServer.Start();

            game.Run();
            //Console.ReadKey (true);

            webSocketServer.Stop();
        }
    }
}
