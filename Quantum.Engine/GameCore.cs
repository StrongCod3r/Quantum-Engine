using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Quantum.Engine.Core;
using System;

namespace Quantum.Engine
{
    public class GameCore : Game
    {
        public readonly Version Version = new Version(0, 0, 1);
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        public static int PixelsPerUnit = 100;
        public Scene CurrentScene
        {
            get => currentScene;
            set
            {
                value.Start();
                value.Initialize();
                currentScene = value;
            }
        }
        private Scene currentScene;

        public static GameCore Instance;
        
        public GameCore()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Instance = this;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Start();
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        public virtual void Start()
        {
            CurrentScene = new Scene();
        }


        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your logic code here
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Time.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            CurrentScene.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            CurrentScene.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
