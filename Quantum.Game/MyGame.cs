using System;
using System.Collections.Generic;
using System.Text;
using Quantum.Engine;
using Quantum.Game.Scenes;

namespace Quantum.Game
{
    public class MyGame : GameCore
    {
        public override void Start()
        {
            CurrentScene = new MainScene();
        }
    }
}
