using NUnit.Framework;
using Ecs;

namespace Ecs.Tests.Integration
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TheCarMovesWithAVelocity()
        {
            var world = new World();
            var car = world.CreateEntity();
            var transformComponent = car.AddComponent<TransformComponent>();
            var velocityComponent = car.AddComponent<VelocityComponent>();

            world.AddSystem(new MovementSystem());

            velocityComponent.value = 10f;

            world.Tick(1f);
            world.Tick(0.5f);
            world.Tick(0.5f);
            world.Tick(1f);

            Assert.AreEqual(30, transformComponent.x, "The car has moved the correct distance along the x axis");
            Assert.AreEqual(0, transformComponent.y, "The car has not moved along the y axis");
            Assert.AreEqual(0, transformComponent.z, "The car has not moved along the z axis");
        }
    }
}
