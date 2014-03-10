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
        Vector2 pos;

        public Fantome(ContentManager content)
        {
            fantomeTexture = content.Load<Texture2D>("Casper1");
            hitbox = new Rectangle(0, 0, 40, 68);
            pos = new Vector2(hitbox.X + fantomeTexture.Width/2, hitbox.Y + fantomeTexture.Height/2);
        }

        public void Update(MouseState mouseState, KeyboardState keyboardState, GraphicsDevice graphicsDevice, Decors decors)
        {
            /// <control>
            if (keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.W))
            {
                hitbox.Y -= 5;
                pos.Y -= 5;
            }
            if (keyboardState.IsKeyDown(Keys.Down) || keyboardState.IsKeyDown(Keys.S))
            {
                hitbox.Y += 5;
                pos.Y += 5;
            }
            if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
            {
                hitbox.X += 5;
                pos.X += 5;
            }
            if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left))
            {
                hitbox.X -= 5;
                pos.X -= 5;
            }
            /// </control>
            /// <ToStayInWindow>
            if (hitbox.X < 0)
            {
                hitbox.X = 0;
                pos.X = fantomeTexture.Width / 2;
            }
            if (hitbox.Y < 0)
            {
                hitbox.Y = 0;
                pos.Y = fantomeTexture.Height / 2;
            }
            if (hitbox.X + hitbox.Width > graphicsDevice.Viewport.Width)
            {
                hitbox.X = graphicsDevice.Viewport.Width - hitbox.Width;
                pos.X = graphicsDevice.Viewport.Width - fantomeTexture.Width / 2;
            }
            if (hitbox.Y + hitbox.Height > graphicsDevice.Viewport.Height)
            {
                hitbox.Y = graphicsDevice.Viewport.Height - hitbox.Height;
                pos.Y = graphicsDevice.Viewport.Height - fantomeTexture.Height / 2;
            }
            /// </ToStayInWindow>
            // if (hitbox.X >= decors.Hitbox.X && hitbox.X + hitbox.Width <= decors.Hitbox.X + decors.Hitbox.Width) // Test if Casper is between the bounds of the platform.
            if (pos.X >= decors.groundHitbox.X && pos.X <= decors.groundHitbox.X + decors.groundHitbox.Width)
            {
                if (pos.Y + hitbox.Height/2 >= decors.groundHitbox.Y && pos.Y < decors.groundHitbox.Y)
                {
                    hitbox.Y = decors.groundHitbox.Y - hitbox.Height - 1;
                    pos.Y = hitbox.Y + fantomeTexture.Height;
                    // Block Casper above the platform.
                }
                if (hitbox.Y <= decors.groundHitbox.Y + decors.groundHitbox.Height && pos.Y + hitbox.Height/2 > decors.groundHitbox.Y + decors.groundHitbox.Height)
                {
                    hitbox.Y = decors.groundHitbox.Y + decors.groundHitbox.Height + 1;
                    pos.Y = hitbox.Y + fantomeTexture.Height;
                    // Block Casper under the platform.
                }
            }

            //else // Here Casper is out of the bounds of the platform, to the left or to the right.
            //{
            if (pos.Y >= decors.groundHitbox.Y && pos.Y <= decors.groundHitbox.Y + decors.groundHitbox.Height) // Then Casper is at the same height as the platform.
            {
                if (hitbox.X + hitbox.Width >= decors.groundHitbox.X && hitbox.X < decors.groundHitbox.X)
                {
                    hitbox.X = decors.groundHitbox.X - hitbox.Width - 1;
                    pos.X = hitbox.X + fantomeTexture.Width;
                    // Block Casper at the left of the platform.
                }
                if (hitbox.X <= decors.groundHitbox.X + decors.groundHitbox.Width && hitbox.X + hitbox.Width > decors.groundHitbox.X + decors.groundHitbox.Width)
                {
                    hitbox.X = decors.groundHitbox.X + decors.groundHitbox.Width + 1;
                    pos.X = hitbox.X + fantomeTexture.Width;
                    // Block Casper at the right of platform.
                }
            }
            // }

            hitbox.Y += 1;
            pos.Y = hitbox.Y + fantomeTexture.Height;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(fantomeTexture, hitbox, Color.White);
        }
    }
}
