using Ecs;
using System;
using System.Threading;

namespace Game
{
  public class Game
  {
    public delegate void OnStateChanged(WorldState state);
    public OnStateChanged StateChanged;

    private World world;

    public Game() {
      world = new World();
    }

    public Player AddPlayer() {
      var player = new Player();

      return player;
    }

    public void Run() {
      float timestamp = GetCurrentTime();

      while (true) {
        float now = GetCurrentTime();
        float deltaTime = now - timestamp;
        timestamp = now;

        ProcessInput();

        world.Tick(deltaTime);

        var state = new WorldState();

        StateChanged?.Invoke(state);

        Thread.Sleep(3);
      }
    }

    private float GetCurrentTime() {
      return DateTime.Now.Millisecond / 1000f;
    }

    private void ProcessInput() {}
  }
}
