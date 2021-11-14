using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Quantum.Engine;
using Quantum.Engine.Components.Rendering;
using Quantum.Engine.Core;
using System.Collections.Generic;

namespace Quantum.Game.Behavior
{
    public enum PlayerAnimations
    {
        Walk_Front, 
        Walk_Front_Idle,
        Walk_Back,
        Walk_Back_Idle,
        Walk_Right,
        Walk_Right_Idle,
        Walk_Left,
        Walk_Left_Idle
    }

    public class PlayerController : Component, ICompUpdate
    {
        float speed = 60;
        Vector2 movement;
        Dictionary<PlayerAnimations, Animation2D> playerAnimations;
        PlayerAnimations currentAnimation;
        PlayerAnimations oldAnimation;
        Keys lastPressKey;

        [RequiredComponent]
        SpriteRenderer spriteRenderer;

        public override void Start()
        {
            movement = Vector2.Zero;
            playerAnimations = new Dictionary<PlayerAnimations, Animation2D>();

            playerAnimations.Add(PlayerAnimations.Walk_Front, new Animation2D(PlayerAnimations.Walk_Front.ToString(), 1, 3));
            playerAnimations.Add(PlayerAnimations.Walk_Front_Idle, new Animation2D(PlayerAnimations.Walk_Front_Idle.ToString(), 2));
            playerAnimations.Add(PlayerAnimations.Walk_Right, new Animation2D(PlayerAnimations.Walk_Right.ToString(), 4, 6) { FlipHorizontal = true });
            playerAnimations.Add(PlayerAnimations.Walk_Right_Idle, new Animation2D(PlayerAnimations.Walk_Right_Idle.ToString(), 5) { FlipHorizontal = true });
            playerAnimations.Add(PlayerAnimations.Walk_Left, new Animation2D(PlayerAnimations.Walk_Left.ToString(), 4, 6));
            playerAnimations.Add(PlayerAnimations.Walk_Left_Idle, new Animation2D(PlayerAnimations.Walk_Left_Idle.ToString(), 5));
            playerAnimations.Add(PlayerAnimations.Walk_Back, new Animation2D(PlayerAnimations.Walk_Back.ToString(), 7, 9));
            playerAnimations.Add(PlayerAnimations.Walk_Back_Idle, new Animation2D(PlayerAnimations.Walk_Back_Idle.ToString(), 8));

            SetAnimation(PlayerAnimations.Walk_Right_Idle);
            spriteRenderer.Play();
        }

        public void Update()
        {
            UpdateInput();
            UpdateMovement();
        }

        private void UpdateInput()
        {
            KeyboardState state = Keyboard.GetState();
            movement.X = Entity.Transform.Position.X;
            movement.Y = Entity.Transform.Position.Y;

            if (state.IsKeyDown(Keys.Right))
            {
                movement.X += 1.5f;
                SetAnimation(PlayerAnimations.Walk_Right);
                Entity.Transform.Position = movement;
                lastPressKey = Keys.Right;
                return;
            }

            if (state.IsKeyDown(Keys.Left))
            {
                movement.X += -1.5f;
                SetAnimation(PlayerAnimations.Walk_Left);
                Entity.Transform.Position = movement;
                lastPressKey = Keys.Left;
                return;
            }

            if (state.IsKeyDown(Keys.Down))
            {
                movement.Y += 1.5f;
                SetAnimation(PlayerAnimations.Walk_Front);
                Entity.Transform.Position = movement;
                lastPressKey = Keys.Down;
                return;
            }

            if (state.IsKeyDown(Keys.Up))
            {
                movement.Y += -1.5f;
                SetAnimation(PlayerAnimations.Walk_Back);
                Entity.Transform.Position = movement;
                lastPressKey = Keys.Up;
                return;
            }



            //---------------------------------------------

            if (lastPressKey == Keys.Right)
            {
                SetAnimation(PlayerAnimations.Walk_Right_Idle);
            }

            if (lastPressKey == Keys.Left)
            {
                SetAnimation(PlayerAnimations.Walk_Left_Idle);
            }

            if (lastPressKey == Keys.Down)
            {
                SetAnimation(PlayerAnimations.Walk_Front_Idle);
            }

            if (lastPressKey == Keys.Up)
            {
                SetAnimation(PlayerAnimations.Walk_Back_Idle);
            }
        }

        private void SetAnimation(PlayerAnimations animation)
        {

            if (currentAnimation == animation)
                return;

            this.oldAnimation = currentAnimation;

            if (playerAnimations.TryGetValue(animation, out Animation2D value))
            {
                spriteRenderer.SetAnimation(value);
                this.currentAnimation = animation;
            }
        }

        private void UpdateMovement()
        {
            //float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            //Vector2 position = Vector2.Zero;

            //position.X += speed * Time.DeltaTime;
            //position.Y += speed * Time.DeltaTime;

            //Entity.Transform.Position += movement;
            //movement = Vector2.Zero;
        }
    }
}
