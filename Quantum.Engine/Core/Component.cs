using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Quantum.Engine;

namespace Quantum.Engine.Core
{
    public abstract class Component
    {
        public bool Active { get; set; } = true;
        public bool Visible { get; set; } = true;
        public Entity Entity { get; private set; }
        public Scene Scene => Entity?.Scene;

        //public GameTime Time { get; internal set; }

        internal void Attach(Entity entity)
        {
            this.Entity = entity;
        }

        #region Virtual Methods
        public virtual void Start() { }
        //public virtual void Update() { }
        public virtual void FixedUpdate() { }
        public virtual void LateUpdate() { }
        public virtual void OnGUI() { }
        public virtual void OnDisable() { }
        public virtual void OnEnable() { }
        #endregion
    }
}
