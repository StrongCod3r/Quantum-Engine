using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;

namespace Quantum.Engine.Components.Rendering
{
    public class Animation2D
    {
        public string Name { get; }
        public float FrameTime { get; set; } = 0.1f;
        public bool IsLooping { get; set; } = true;
        public int[] Frames { get; }
        public int FrameCount { get => Frames.Length; }

        internal SpriteEffects Flip => flipHorizontal | flipVertical;

        private SpriteEffects flipHorizontal = SpriteEffects.None;
        public bool FlipHorizontal
        {
            get { return flipHorizontal != SpriteEffects.None; }
            set { flipHorizontal = value? SpriteEffects.FlipHorizontally : SpriteEffects.None; }
        }

        private SpriteEffects flipVertical = SpriteEffects.None;
        public bool FlipVertical
        {
            get { return flipVertical != SpriteEffects.None; }
            set { flipVertical = value ? SpriteEffects.FlipVertically : SpriteEffects.None; }
        }

        public Animation2D(string name, int firstFrame, int lastFrame)
        {
            if (firstFrame <= 0)
                throw new Exception("First frame is incorrect");

            if (firstFrame <= 0)
                throw new Exception("Last frame is incorrect");

            if (firstFrame > lastFrame)
                throw new Exception("Frame interval is incorrect");

            this.Name = name;
            Frames = Enumerable.Range(firstFrame, lastFrame - firstFrame + 1).ToArray();
        }

        public Animation2D(string name, int singleFrame)
        {
            if (singleFrame <= 0)
                throw new Exception("Last frame is incorrect");

            this.Name = name;
            Frames = new int[] { singleFrame };
        }

        public Animation2D(string name, int[] frames)
        {
            if (frames.Length == 0)
                throw new Exception("Frames cannot be empty");

            if (frames.Where(x => x <= 0).Any())
                throw new Exception("Frames has index invalid");

            this.Name = name;
            Frames = frames;
        }
    }
}
