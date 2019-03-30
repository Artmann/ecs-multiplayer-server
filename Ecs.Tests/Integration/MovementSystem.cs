using Ecs;

namespace Ecs.Tests.Integration
{
  public class MovementSystem : Ecs.System
  {
    public override void Perform(Entity[] entities, float deltaTime, World world)
    {
      foreach (var entity in entities) {
        var transform = entity.GetComponent<TransformComponent>();
        var velocity = entity.GetComponent<VelocityComponent>();

        transform.x += velocity.value * deltaTime;
      }
    }
  }
}
