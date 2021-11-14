using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Quantum.Engine.Core
{
    public interface ICompDraw
    {
        void Draw(SpriteBatch spriteBatch);
    }
}
