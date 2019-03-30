using System;

namespace Game
{
  public class Player
  {
    public string id;

    public Player() {
      id = Guid.NewGuid().ToString();
    }
  }
}
