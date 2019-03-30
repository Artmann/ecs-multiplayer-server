using Newtonsoft.Json;
using System;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Server
{
  public class SocketManager : WebSocketBehavior
  {
    private Game.Game game;

    public SocketManager(Game.Game game) {
      this.game = game;

      game.StateChanged += OnStateChanged;
    }

    protected override void OnMessage (MessageEventArgs e)
    {
      var action = JsonConvert.DeserializeObject<Action>(e.Data);

      if (action.type == "JOIN") {
        var player = game.AddPlayer();

        Send(player.id);
      }
    }

    private void OnStateChanged(WorldState state) {
      var json = JsonConvert.SerializeObject(state);

      Sessions.Broadcast(json);
    }
  }
}
