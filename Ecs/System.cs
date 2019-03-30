namespace Ecs
{
  public abstract class System
  {
    public abstract void Perform(Entity[] entities, float deltaTime, World world);
  }
}
