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
            if (hitbox.X + hitbox.Width > decors.Hitbox.X && hitbox.X + hitbox.Width < decors.Hitbox.X + decors.Hitbox.Width && (hitbox.Y + hitbox.Height > decors.Hitbox.Y && hitbox.Y < decors.Hitbox.Y + decors.Hitbox.Height))
            {
                hitbox.X -= 5; // gauche
            }
            if (hitbox.X < decors.Hitbox.X + hitbox.Width && hitbox.X > decors.Hitbox.X && (hitbox.Y + hitbox.Height > decors.Hitbox.Y && hitbox.Y < decors.Hitbox.Y + decors.Hitbox.Height))
            {
                hitbox.X += 5; // droite
            }
            if (hitbox.Y < decors.Hitbox.Y + decors.Hitbox.Height && hitbox.Y > decors.Hitbox.Y && hitbox.X + hitbox.Width > decors.Hitbox.X && hitbox.X < decors.Hitbox.X + decors.Hitbox.Width)
            {
                hitbox.Y = decors.Hitbox.Y + decors.Hitbox.Height; // Attention avec la gravité, pour éviter les sursauts [ dessous de plateforme]
            }
            if (hitbox.Y + hitbox.Height > decors.Hitbox.Y && hitbox.Y + hitbox.Height < decors.Hitbox.Y + decors.Hitbox.Height && hitbox.X + hitbox.Width > decors.Hitbox.X && hitbox.X < decors.Hitbox.X + decors.Hitbox.Width)
            {
                hitbox.Y = decors.Hitbox.Y + hitbox.Width; // a regler sautillement/faille spatio temporel
            }

            hitbox.Y += 1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(fantomeTexture, hitbox, Color.White);
        }
    }
}
