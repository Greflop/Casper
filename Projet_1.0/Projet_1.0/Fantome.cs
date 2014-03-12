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
        Rectangle Hitbox;
        Rectangle CurrentHitbox;

        public Fantome(ContentManager content)
        {
            fantomeTexture = content.Load<Texture2D>("Casper1");
            Hitbox = new Rectangle(0, 0, 40, 68);
        }

        public void Update(KeyboardState keyboardState, GraphicsDevice graphicsDevice, Decors decors)
        {
            CurrentHitbox = Hitbox; // To save the last position.

            /// <control>
            if (keyboardState.IsKeyDown(Keys.Down) || keyboardState.IsKeyDown(Keys.S))
            {
                Hitbox.Y += 5;
                foreach (Rectangle g in decors.groundHitbox)
                {
                    if (Hitbox.Intersects(g))
                        Hitbox = CurrentHitbox;
                }
            }

            if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
            {
                Hitbox.X += 5;
                foreach (Rectangle g in decors.groundHitbox)
                {
                    if (Hitbox.Intersects(g))
                        Hitbox = CurrentHitbox;
                }
                CurrentHitbox = Hitbox;
            }

            if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left))
            {
                Hitbox.X -= 5;
                foreach (Rectangle g in decors.groundHitbox)
                {
                    if (Hitbox.Intersects(g))
                        Hitbox = CurrentHitbox;
                }
                CurrentHitbox = Hitbox;
            }

            if (keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.W))
            {
                Hitbox.Y -= 5;
                foreach (Rectangle g in decors.groundHitbox)
                {
                    if (Hitbox.Intersects(g))
                        Hitbox = CurrentHitbox;
                }
            }
            else
                Hitbox.Y++;
            /// </control>
            
            /// <ToStayInWindow>
            if (Hitbox.X < 0)
            {
                Hitbox.X = 0;
            }
            if (Hitbox.Y < 0)
            {
                Hitbox.Y = 0;
            }
            if (Hitbox.X + Hitbox.Width > graphicsDevice.Viewport.Width)
            {
                Hitbox.X = graphicsDevice.Viewport.Width - Hitbox.Width;
            }
            if (Hitbox.Y + Hitbox.Height > graphicsDevice.Viewport.Height)
            {
                Hitbox.Y = graphicsDevice.Viewport.Height - Hitbox.Height;
            }
            /// </ToStayInWindow>
            
            foreach (Rectangle g in decors.groundHitbox)
            {
                if (Hitbox.Intersects(g))
                    Hitbox = CurrentHitbox;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(fantomeTexture, Hitbox, Color.White);
        }
    }
}
