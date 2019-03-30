using System.Collections.Generic;

namespace Ecs
{
  public class World
  {
    public List<Entity> entities;
    public List<System> systems;

    public World() {
      entities = new List<Entity>();
      systems = new List<System>();
    }

    public void AddSystem(System system) {
      this.systems.Add(system);
    }

    public Entity CreateEntity() {
      var entity = new Entity();

      entities.Add(entity);

      return entity;
    }

    public void Tick(float deltaTime) {
      foreach (var system in systems) {
        system.Perform(entities.ToArray(), deltaTime, this);
      }
    }
  }
}
