using Quantum.Engine.Components.Rendering;
using Quantum.Engine.Core;
using Quantum.Game.Behavior;

namespace Quantum.Game.Scenes
{
    public class BirdScene : Scene
    {
        public override void Start()
        {
            var bird = new Entity("Bird")
                            .AddComponent(new SpriteRenderer()
                            {
                                TexturePath = Assets.Bird,
                                Rows = 2,
                                Columns = 7,
                            })
                            .AddComponent(new BirdController());

            this.AddEntity(bird);
        }
    }
}
