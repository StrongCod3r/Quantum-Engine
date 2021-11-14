using Quantum.Engine.Components.Rendering;
using Quantum.Engine.Core;

namespace Quantum.Game.Behavior
{
    public class BirdController : Component
    {
        [RequiredComponent]
        private SpriteRenderer spriteRenderer;

        public override void Start()
        {
            spriteRenderer.SetAnimation(new Animation2D("Flutter", 1, 14));
            spriteRenderer.Play();
        }
    }
}
