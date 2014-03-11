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
        Texture2D fantomeD1Texture, fantomeD2Texture, fantomeD3Texture, fantomeD4Texture, fantomeG1Texture, fantomeG2Texture, fantomeG3Texture, fantomeG4Texture, fantomeDSTexture, fantomeGSTexture, fantomeStopTexture, fantomeIniTexture, fantomeFallTexture, fantomeSTexture;
        Rectangle Hitbox;
        Rectangle CurrentHitbox;
        float timer;
        int timecounter;

        public Fantome(ContentManager content)
        {
            fantomeIniTexture = content.Load<Texture2D>("CasperStop");
            fantomeStopTexture = content.Load<Texture2D>("CasperStop");
            fantomeD1Texture = content.Load<Texture2D>("CasperDroite1");
            fantomeD2Texture = content.Load<Texture2D>("CasperDroite2");
            fantomeD3Texture = content.Load<Texture2D>("CasperDroite3");
            fantomeD4Texture = content.Load<Texture2D>("CasperDroite4");
            fantomeG1Texture = content.Load<Texture2D>("CasperGauche1");
            fantomeG2Texture = content.Load<Texture2D>("CasperGauche2");
            fantomeG3Texture = content.Load<Texture2D>("CasperGauche3");
            fantomeG4Texture = content.Load<Texture2D>("CasperGauche4");
            fantomeDSTexture = content.Load<Texture2D>("CasperDroiteSaut");
            fantomeGSTexture = content.Load<Texture2D>("CasperGaucheSaut");
            fantomeFallTexture = content.Load<Texture2D>("CasperFall");
            fantomeSTexture = content.Load<Texture2D>("CasperSaut");
            Hitbox = new Rectangle(0, 0, 40, 68);
        }

        public void Update(MouseState mouseState, KeyboardState keyboardState, GraphicsDevice graphicsDevice, Decors decors, GameTime gameTime)
        {
            CurrentHitbox = Hitbox; // To save the last position.
            int isGoingDown = Hitbox.Y;
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            timecounter += (int)timer;
            if (timecounter>10000)
            {
                timer = 0;
                timecounter = 0;
            }

            /// <control>

            if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
            {
                Hitbox.X += 5;
                if ( timecounter < 1500)
                {
                    fantomeIniTexture = fantomeD1Texture;
                }
                else if (timecounter < 5000 )
                {
                        fantomeIniTexture = fantomeD2Texture;
                }
                else if (timecounter < 7500)
                {
                    fantomeIniTexture = fantomeD3Texture;
                }
                else
                {
                    fantomeIniTexture = fantomeD4Texture;
                }
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
                if (timecounter < 1500)
                {
                    fantomeIniTexture = fantomeG1Texture;
                }
                else if (timecounter < 5000)
                {
                    fantomeIniTexture = fantomeG2Texture;
                }
                else if (timecounter < 7500)
                {
                    fantomeIniTexture = fantomeG3Texture;
                }
                else
                {
                    fantomeIniTexture = fantomeG4Texture;
                }

                foreach (Rectangle g in decors.groundHitbox)
                {
                    if (Hitbox.Intersects(g))
                        Hitbox = CurrentHitbox;
                }
                CurrentHitbox = Hitbox;
            }

            if (keyboardState.IsKeyDown(Keys.Down) || keyboardState.IsKeyDown(Keys.S))
            {
                Hitbox.Y += 5;
                fantomeIniTexture = fantomeFallTexture;
                if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
                {
                    fantomeIniTexture = fantomeFallTexture;
                }
                if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left))
                {
                    fantomeIniTexture = fantomeFallTexture;
                }
                foreach (Rectangle g in decors.groundHitbox)
                {
                    if (Hitbox.Intersects(g))
                        Hitbox = CurrentHitbox;
                }
            }

            if (keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.W))
            {
                Hitbox.Y -= 5;
                fantomeIniTexture = fantomeDSTexture;
                if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left))
                {
                    fantomeIniTexture = fantomeGSTexture;
                }
                if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
                {
                    fantomeIniTexture = fantomeDSTexture;
                }
                foreach (Rectangle g in decors.groundHitbox)
                {
                    if (Hitbox.Intersects(g))
                        Hitbox = CurrentHitbox;
                }
            }
            else
            {

                Hitbox.Y++;
                if (keyboardState.IsKeyUp(Keys.Up) && keyboardState.IsKeyUp(Keys.Down) && keyboardState.IsKeyUp(Keys.Right) && keyboardState.IsKeyUp(Keys.Left) && keyboardState.IsKeyUp(Keys.W) && keyboardState.IsKeyUp(Keys.S) && keyboardState.IsKeyUp(Keys.D) && keyboardState.IsKeyUp(Keys.A))
                {
                    fantomeIniTexture = fantomeFallTexture;
                    foreach (Rectangle g in decors.groundHitbox)
                    {
                        if (Hitbox.Intersects(g))
                        {
                            fantomeIniTexture = fantomeStopTexture;
                        }
                    }

                }

            
            }
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
                {
                    Hitbox = CurrentHitbox;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(fantomeIniTexture, Hitbox, Color.White);
        }
    }
}
