using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Quantum.Engine.Components.Physics.Colliders
{
    public class CircleCollider : Collider
    {
        // Private Vars
        protected Vector2 _center;
        protected float _radius;

        // Constructor
        public CircleCollider(float radius, Vector2 center)
        {
            _radius = radius;
            _center = center;
        }

        protected override Vector2 GetGlobalCenter()
        {
            return _center + Entity.Transform.Position;
        }

        // Public Functions
        public override Vector2 GetCenter()
        {
            return GetGlobalCenter();
        }

        public override float GetBottom()
        {
            return GetGlobalCenter().Y + _radius;
        }

        public override float GetLeft()
        {
            return GetGlobalCenter().X - _radius;
        }

        public override float GetRight()
        {
            return GetGlobalCenter().X + _radius;
        }

        public override float GetTop()
        {
            return GetGlobalCenter().Y - _radius;
        }

        public float GetRadius()
        {
            return _radius;
        }

        public override void Collide(int dir, Vector2 pushVector)
        {
            Collide(pushVector);
        }

        public void Collide(Vector2 pushVector)
        {
            if (hasRB)
            {
                rb.velocity = pushVector;
            }
        }
    }
}
