using System;
using System.Collections.Generic;
using System.Linq;

namespace Ecs
{
  public class Entity
  {
    public List<IComponent> components;

    private string id;

    public Entity() {
      id = Guid.NewGuid().ToString();

      components = new List<IComponent>();
    }

    public T AddComponent<T>() where T : IComponent, new() {
      var component = new T();

      components.Add(component);

      return component;
    }

    public T GetComponent<T>() where T : IComponent {
      var component = (T) components.FirstOrDefault(c => c is T);

      return component;
    }
  }
}
