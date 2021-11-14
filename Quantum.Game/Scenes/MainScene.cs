using Microsoft.Xna.Framework;
using Quantum.Engine.Components.Physics;
using Quantum.Engine.Components.Physics.Colliders;
using Quantum.Engine.Components.Rendering;
using Quantum.Engine.Core;
using Quantum.Game.Behavior;

namespace Quantum.Game.Scenes
{
    public class MainScene : Scene
    {
        public override void Start()
        {
            var player = new Entity("Player")
                            .AddComponent(new SpriteRenderer() 
                            { 
                                TexturePath = Assets.Player,
                                Rows = 3,
                                Columns = 3,
                            })
                            .AddComponent(new PlayerController())
                            .AddComponent(new Rigidbody())
                            .AddComponent(new RectangleCollider(10, 15, Vector2.Zero));

            this.AddEntity(player);
        }
    }
}