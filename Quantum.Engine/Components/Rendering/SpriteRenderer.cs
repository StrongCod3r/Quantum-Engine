using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Quantum.Engine.Core;
using System;
using System.Collections.Generic;

namespace Quantum.Engine.Components.Rendering
{
    public class SpriteRenderer : Component, ICompUpdate, ICompDraw
    {
        #region Fields
        private float time;
        private int frameWidth;
        private int frameHeight;
        private int framesTotal;
        private List<Rectangle> frames;
        private Texture2D texture;
        private bool canAnimate = false;
        #endregion

        #region Properties
        public string TexturePath { get; set; }
        public int FrameIndex { get; private set; }
        public Animation2D CurrentAnimation { get; private set; }


        private int rows = 1;

        public UInt32 Rows
        {
            get { return (UInt32)rows; }
            set 
            { 
                rows = (int)value; 
            }
        }

        private int columns = 1;

        public UInt32 Columns
        {
            get { return (UInt32)columns; }
            set { columns = (int)value; }
        }

        #endregion


        public override void Start()
        {
            if (!string.IsNullOrEmpty(TexturePath))
            {
                this.texture = GameCore.Instance.Content.Load<Texture2D>(TexturePath);
                InitializeFrames();
            }
        }

        public void Play() => canAnimate = true;

        public void Stop() => canAnimate = false;

        public void SetAnimation(Animation2D animation)
        {
            CurrentAnimation = animation;
            InitializeFrames();
        }

        private void InitializeFrames()
        {
            if (texture is null)
                return;

            FrameIndex = 0;
            frameHeight = texture.Height / rows;
            frameWidth = texture.Width / columns;
            framesTotal = rows * columns;

            frames = new List<Rectangle>();

            // Calculate all frame animations
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    frames.Add(new Rectangle(c * frameWidth, r * frameHeight, frameWidth, frameHeight));
                }
            }
        }

        public void Update()
        {
            if (CurrentAnimation is null)
                return;

            //Process passing time.
            time += Time.DeltaTime;
            while (time > CurrentAnimation.FrameTime)
            {
                time -= CurrentAnimation.FrameTime;

                // Advance the frame index; looping or clamping as appropriate.
                if (CurrentAnimation.IsLooping)
                {
                    FrameIndex = (FrameIndex + 1) % CurrentAnimation.FrameCount;
                }
                else
                {
                    FrameIndex = Math.Min(FrameIndex + 1, CurrentAnimation.FrameCount - 1);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (texture is null)
                return;

            if (!canAnimate)
                return;

            if (CurrentAnimation is null)
                return;

            int numberFrame = CurrentAnimation.Frames[FrameIndex];

            if (numberFrame > frames.Count)
                return;

            // Draw the current frame.
            spriteBatch.Draw(
                texture, 
                Entity.Transform.Position, 
                frames[numberFrame - 1], 
                Color.White, 
                0.0f, 
                Vector2.Zero, 
                1.0f, 
                CurrentAnimation.Flip, 
                0.0f
            );
        }
    }
}
