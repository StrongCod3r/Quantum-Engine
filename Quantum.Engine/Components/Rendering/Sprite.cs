using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Quantum.Engine.Core;

namespace Quantum.Engine.Components.Rendering
{
    public class Sprite : Component, ICompDraw
    {
        public string TexturePath = string.Empty;
        private Texture2D texture2D;
        public Color Color {get; set; } = Color.White;
        public int layerIndex {get; set; } = 0;

        public override void Start()
        {
            if (!string.IsNullOrEmpty(TexturePath))
                this.texture2D = GameCore.Instance.Content.Load<Texture2D>(TexturePath);
        }

        public void Draw(SpriteBatch sb)
        {
            if (texture2D is not null)
                sb.Draw(
                    texture2D,
                    Entity.Transform.Position,
                    null,
                    Color,
                    Entity.Transform.Rotation,
                    Vector2.Zero, Entity.Transform.Scale,
                    SpriteEffects.None,
                    layerIndex
                );
        }
    }
}
