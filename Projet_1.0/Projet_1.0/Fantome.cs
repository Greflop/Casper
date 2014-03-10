using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Test_deplacement
{
    public enum Direction
    {
        Up, Down, Left, Right
    };

    class Fantome
    {
        Texture2D fantomeTexture;
        Rectangle hitbox;

        public Fantome(ContentManager content)
        {
            fantomeTexture = content.Load<Texture2D>("Casper1");
            hitbox = new Rectangle(0, 0, 40, 68);
        }

        public void Update(MouseState mouseState, KeyboardState keyboardState, GraphicsDevice graphicsDevice, Decors decors)
        {
            /// <control>
            if (keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.W))
            {
                hitbox.Y -= 5;
            }
            if (keyboardState.IsKeyDown(Keys.Down) || keyboardState.IsKeyDown(Keys.S))
            {
                hitbox.Y += 5;
            }
            if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
            {
                hitbox.X += 5;
            }
            if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left))
            {
                hitbox.X -= 5;
            }
            /// </control>
            /// <ToStayInWindow>
            if (hitbox.X < 0)
            {
                hitbox.X = 0;
            }
            if (hitbox.Y < 0)
            {
                hitbox.Y = 0;
            }
            if (hitbox.X + hitbox.Width > graphicsDevice.Viewport.Width)
            {
                hitbox.X = graphicsDevice.Viewport.Width - hitbox.Width;
            }
            if (hitbox.Y + hitbox.Height > graphicsDevice.Viewport.Height)
            {
                hitbox.Y = graphicsDevice.Viewport.Height - hitbox.Height;
            }
            /// </ToStayInWindow>
            // if (hitbox.X >= decors.Hitbox.X && hitbox.X + hitbox.Width <= decors.Hitbox.X + decors.Hitbox.Width) // Test if Casper is between the bounds of the platform.
            if (hitbox.X + hitbox.Width >= decors.Hitbox.X && hitbox.X <= decors.Hitbox.X + decors.Hitbox.Width)
            {
                if (hitbox.Y + hitbox.Height >= decors.Hitbox.Y && hitbox.Y < decors.Hitbox.Y)
                {
                    hitbox.Y = decors.Hitbox.Y - hitbox.Height - 1; // Block Casper above the platform.
                }
                if (hitbox.Y <= decors.Hitbox.Y + decors.Hitbox.Height && hitbox.Y + hitbox.Height > decors.Hitbox.Y + decors.Hitbox.Height)
                {
                    hitbox.Y = decors.Hitbox.Y + decors.Hitbox.Height + 1; // Block Casper under the platform.
                }
            }

            //else // Here Casper is out of the bounds of the platform, to the left or to the right.
            //{
            if (hitbox.Y + hitbox.Height >= decors.Hitbox.Y && hitbox.Y <= decors.Hitbox.Y + decors.Hitbox.Height) // Then Casper is at the same height as the platform.
            {
                if (hitbox.X + hitbox.Width >= decors.Hitbox.X && hitbox.X < decors.Hitbox.X)
                {
                    hitbox.X = decors.Hitbox.X - hitbox.Width - 1; // Block Casper at the left of the platform.
                }
                if (hitbox.X <= decors.Hitbox.X + decors.Hitbox.Width && hitbox.X + hitbox.Width > decors.Hitbox.X + decors.Hitbox.Width)
                {
                    hitbox.X = decors.Hitbox.X + decors.Hitbox.Width + 1; // Block Casper at the right of platform.
                }
            }
            // }

            //hitbox.Y += 1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(fantomeTexture, hitbox, Color.White);
        }
    }
}
