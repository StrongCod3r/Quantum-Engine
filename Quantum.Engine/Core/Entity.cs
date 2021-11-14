using Microsoft.Xna.Framework;
using Quantum.Engine.Components.Transform;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quantum.Engine.Core
{
    public class Entity
    {
        public bool Active { get; set; } = true;
        public Scene Scene { get; internal set; }
        internal Dictionary<Type, Component> components;
        internal Dictionary<Type,ICompDraw> componentsDraw;
        internal Dictionary<Type,ICompUpdate> componentsUpdate;

        public Transform Transform { get; set; }
        public string Name { get; set; }
        public int Tag { get; set; } // tag = -1 means the tag has not been assigned

        public Entity(string name = "Entity")
        {
            this.Name = name;
            this.Tag = -1;
            this.Transform = new Transform() { Position = Vector2.Zero, Scale = 1, Rotation = 0 };
            this.components = new Dictionary<Type, Component>();
            this.componentsDraw = new Dictionary<Type, ICompDraw>();
            this.componentsUpdate = new Dictionary<Type, ICompUpdate>();
            AddComponent(Transform);
        }

        public Entity AddComponent(Component component)
        {
            if ((component is Transform))
                return this;

            Type type = component.GetType();

            if (!components.TryGetValue(type, out var comp))
            {
                components.Add(type, component);

                if (component is ICompDraw)
                    componentsDraw.Add(type, component as ICompDraw);

                if (component is ICompUpdate)
                    componentsUpdate.Add(type, component as ICompUpdate);

                component.Attach(this);
            }

            return this;
        }

        public T FindComponent<T>() where T : Component
        {
            if (components.TryGetValue(typeof(T), out var comp))
                return (T)comp;

            return null;
        }

        public T FindComponent<T>(Type componentType) where T : Component
        {
            if (components.TryGetValue(componentType, out var comp))
                return (T)comp;

            return null;
        }

        public bool RemoveComponent<T>() where T : Component
        {
            Type type = typeof(T);
            if (components.TryGetValue(type, out var comp))
            {
                if (comp is ICompDraw)
                    componentsDraw.Remove(type);

                if (comp is ICompUpdate)
                    componentsUpdate.Remove(type);

                this.components.Remove(type);
                return true;
            }

            return false;
        }

        public static bool operator ==(Entity e1, Entity e2)
        {
            return e1.Equals(e2);
        }

        public static bool operator !=(Entity e1, Entity e2)
        {
            return !(e1.Equals(e2));
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }
    }
}
