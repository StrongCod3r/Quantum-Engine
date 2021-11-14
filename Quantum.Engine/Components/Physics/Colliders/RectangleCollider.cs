using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Quantum.Engine.Components.Physics.Colliders
{
    public class RectangleCollider : Collider
    {
        protected Vector2 _center;
        protected float _width, _height;

        public RectangleCollider(float width, float height, Vector2 center)
        {
            _width = width;
            _height = height;
            _center = center;
        }

        protected override Vector2 GetGlobalCenter()
        {
            return _center + Entity.Transform.Position;
        }

        public override float GetBottom()
        {
            return GetGlobalCenter().Y + _height / 2;
        }

        public override Vector2 GetCenter()
        {
            return GetGlobalCenter();
        }

        public override float GetLeft()
        {
            return GetGlobalCenter().X - _width / 2;
        }

        public override float GetRight()
        {
            return GetGlobalCenter().X + _width / 2;
        }

        public override float GetTop()
        {
            return GetGlobalCenter().Y - _height / 2;
        }

        public override void Collide(int dir, Vector2 pushVector)
        {
            throw new NotImplementedException();
        }
    }
}
