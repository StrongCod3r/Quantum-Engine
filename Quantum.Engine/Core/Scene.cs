using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Quantum.Engine.Components;
using Quantum.Engine.Components.Rendering;
using Quantum.Engine.Extension;

namespace Quantum.Engine.Core
{
    public class Scene
    {
        private List<Entity> entities;

        public Scene()
        {
            entities = new List<Entity>();
        }

        public virtual void Start() { }

        private void LoadComponents(Entity entity)
        {
            foreach (Component comp in entity.components.Values)
            {
                foreach (var prop in comp.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance))
                {
                    var attrs = prop.GetCustomAttributes(typeof(RequiredComponent), false);

                    if(attrs.Length > 0)
                    {
                        prop.SetValue(comp, entity.FindComponent<Component>(prop.PropertyType), null);
                    }
                }

                foreach (var field in comp.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance))
                {
                    var attrs = field.GetCustomAttributes(typeof(RequiredComponent), false);

                    if (attrs.Length > 0)
                    {
                        field.SetValue(comp, entity.FindComponent<Component>(field.FieldType));
                    }
                }
            }
        }

        internal void Initialize()
        {
            foreach (Entity entity in entities)
            {
                entity.components.ForEach(e => e.Value.Start());
            }
        }

        internal void Update()
        {
            foreach (Entity entity in entities)
            {
                if (entity.Active)
                {
                    entity.componentsUpdate.ForEach(comp =>
                    {
                        if (((Component)comp.Value).Active)
                            comp.Value.Update();
                    });
                }
            }
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            foreach (Entity entity in entities)
            {
                if (entity.Active)
                    entity.componentsDraw.ForEach(comp =>
                    {
                        if (((Component)comp.Value).Active)
                            comp.Value.Draw(spriteBatch);
                    });
            }
        }

        public Entity AddEntity(Entity entity)
        {
            if (!entities.Contains(entity))
                entities.Add(entity);

            LoadComponents(entity);
            return entity;
        }

        public void RemoveEntity(Entity entity)
        {
            entities.Remove(entity);
        }
    }
}
