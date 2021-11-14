using Microsoft.Xna.Framework;
using Quantum.Engine.Core;

namespace Quantum.Engine.Components.Transform
{
    [UniqueComponent]
    public class Transform : Component
    {
        public Vector2 Position;
        public float Scale { get; set; }
        public float Rotation { get; set; }

        public void Translate(Vector2 distance)
        {
            Position += distance;
        }
    }
}
