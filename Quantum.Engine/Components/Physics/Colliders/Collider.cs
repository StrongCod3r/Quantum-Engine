using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Quantum.Engine.Core;

namespace Quantum.Engine.Components.Physics.Colliders
{
    public abstract class Collider : Component
    {
        public static bool renderColliders = false;

        protected bool hasRB, lc, rc, dc, uc;
        protected Rigidbody rb;

        public override void Start()
        {
            rb = Entity.FindComponent<Rigidbody>();
            hasRB = rb != null;
            //Main.Systems.ColiderSystem.CS.colliders.Add(this);
            //Main.Rendering.Renderer.VDs.Add(this);
        }

        abstract protected Vector2 GetGlobalCenter();

        abstract public float GetLeft(); // min x
        abstract public float GetRight(); // max x
        abstract public float GetTop(); // min y
        abstract public float GetBottom(); // max y
        abstract public Vector2 GetCenter();
        abstract public void Collide(int dir, Vector2 pushVector);
    }
}
