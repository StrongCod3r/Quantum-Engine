using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Quantum.Engine.Core;

namespace Quantum.Engine.Components.Physics
{
    [UniqueComponent]
    public class Rigidbody : Component, ICompUpdate
    {
        public static float gravity = 9.8f;

        public bool affectedByGravity = true;
        public Vector2 velocity;

        public Rigidbody()
        {
            velocity = Vector2.Zero;
        }

        public void Update()
        {
            //if (affectedByGravity)
            //{
            //    velocity = new Vector2(velocity.X, velocity.Y + (gravity * Time.TotalTime));
            //}

            //Entity.Transform.Translate(velocity * GameCore.PixelsPerUnit * Time.TotalTime);
        }
    }
}
