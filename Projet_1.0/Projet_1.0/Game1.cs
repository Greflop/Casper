using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Projet_1._0;

namespace Test_deplacement
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Fantome fantome;
        Decors decors;
        Back_Ground back_ground;
        Song music;


        bool checkExitKey(KeyboardState keyboardState, GamePadState gamePadState)       // METHODE POUR EXIT LE JEU AVEC ESC ou BACK
        {
            // Check to see whether ESC was pressed on the keyboard 
            // or BACK was pressed on the controller.
            if (keyboardState.IsKeyDown(Keys.Escape) ||
                gamePadState.Buttons.Back == ButtonState.Pressed)
            {
                Exit();
                return true;
            }
            return false;
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
                graphics.IsFullScreen = true;
            int ScreenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            int ScreenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.PreferredBackBufferWidth = ScreenWidth;           // RESOLUTION D ECRAN
            graphics.PreferredBackBufferHeight = ScreenHeight;           // RESOLUTION D ECRAN
            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            fantome = new Fantome(Content);
            decors = new Decors(Content);
            back_ground = new Back_Ground(Content);


            music = Content.Load<Song>("SoundFX/Ambiance");
            MediaPlayer.Play(music);                              // Musique de fond, dès que le jeu est lancé, a changer => créer une classe? 
            MediaPlayer.IsRepeating = true;
        }


        protected override void UnloadContent()
        {
            decors = null;
            fantome = null;
            back_ground = null;
            music = null;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) // De base, no use???
                this.Exit();
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);  // touche exit
            KeyboardState keyboardState = Keyboard.GetState();              //
                                                                            // 
            // Check to see if the user has exited                          //
            if (checkExitKey(keyboardState, gamePadState))                  //
            {                                                               //
                base.Update(gameTime);                                      //
                return;                                                     //
            }                                                               //
            fantome.Update(Mouse.GetState(), Keyboard.GetState(), GraphicsDevice, decors,gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            back_ground.Draw(spriteBatch);
            fantome.Draw(spriteBatch);
            decors.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
