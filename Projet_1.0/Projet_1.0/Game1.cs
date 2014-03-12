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
        Gamestate gameState;
        Texture2D playButton_text;
        Texture2D optionsButton_text;
        Texture2D exitButton_text;
        Texture2D startMenu_text;
        Rectangle playButton;
        Rectangle optionsButton;
        Rectangle exitButton;
        Rectangle mouseClick;
        MouseState mouseState;
        MouseState previousmouseState;
        Song music;


        enum Gamestate
        {
            StartMenu,
            Playing
        }

        bool checkExitKey(KeyboardState keyboardState) //, GamePadState gamePadState)       // METHODE POUR EXIT LE JEU AVEC ESC ou BACK
        {
            // Check to see whether ESC was pressed on the keyboard 
            // or BACK was pressed on the controller.
            if (keyboardState.IsKeyDown(Keys.Escape)) 
            /*||gamePadState.Buttons.Back == ButtonState.Pressed) */ //xbox button
            {
                return true;
            }
            return false;
        }

        void MouseClicked(int x, int y)
        {
            mouseClick = new Rectangle(x, y, 10, 10);
            if (gameState == Gamestate.StartMenu)
            {
                if (mouseClick.Intersects(playButton))
                {
                    gameState = Gamestate.Playing;
                }
                else if (mouseClick.Intersects(exitButton))
                {
                    Exit();
                }
            }


        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = true;
            double ScreenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            double ScreenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            double coeffX = 1680d / ScreenWidth;
            double coeffY = 1050d / ScreenHeight;
            graphics.PreferredBackBufferWidth = Convert.ToInt32(ScreenWidth);           // RESOLUTION D ECRAN
            graphics.PreferredBackBufferHeight = Convert.ToInt32(ScreenHeight);           // RESOLUTION D ECRAN
            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = true;

            gameState = Gamestate.StartMenu;
            double ScreenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            double ScreenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            double coeffX = 1680d / ScreenWidth;
            double coeffY = 1050d / ScreenHeight;
            playButton = new Rectangle(Convert.ToInt32(700 / coeffX), Convert.ToInt32(450 / coeffY), Convert.ToInt32(352 / coeffX), Convert.ToInt32(88 / coeffY));
            optionsButton = new Rectangle(Convert.ToInt32(700 / coeffX), Convert.ToInt32(600 / coeffY), Convert.ToInt32(352 / coeffX), Convert.ToInt32(88 / coeffY));
            exitButton = new Rectangle(Convert.ToInt32(700 / coeffX), Convert.ToInt32(750 / coeffY), Convert.ToInt32(352 / coeffX), Convert.ToInt32(88 / coeffY));
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            fantome = new Fantome(Content);
            decors = new Decors(Content);
            back_ground = new Back_Ground(Content);
            startMenu_text = Content.Load<Texture2D>("Menu/Menu");
            playButton_text = Content.Load<Texture2D>("Menu/Bouton_Play");
            optionsButton_text = Content.Load<Texture2D>("Menu/Bouton_Option");
            exitButton_text = Content.Load<Texture2D>("Menu/Bouton_Exit");
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
            /// <ControlManetteDeJeu>
            /// if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) // De base, no use???
            ///    this.Exit();
            /// GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
            /// </ControlManetteDeJeu>
            
            /// <ExitButtom>
            KeyboardState keyboardState = Keyboard.GetState();              //
            // 
            // Check to see if the user has exited
            mouseState = Mouse.GetState();

            if (previousmouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released)
            {
                MouseClicked(mouseState.X, mouseState.Y);
            }

            previousmouseState = mouseState;

            if (gameState == Gamestate.Playing)
            {

                fantome.Update(Mouse.GetState(), Keyboard.GetState(), GraphicsDevice, decors, gameTime);
                if (checkExitKey(keyboardState)) //, gamePadState))             //
                {
                    gameState = Gamestate.StartMenu;
                }                                                               //

            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            double ScreenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            double ScreenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            double coeffX = 1680d / ScreenWidth;
            double coeffY = 1050d / ScreenHeight;
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            if (gameState == Gamestate.StartMenu)
            {
                spriteBatch.Draw(startMenu_text, new Rectangle(0, 0, Convert.ToInt32(ScreenWidth), Convert.ToInt32(ScreenHeight)), Color.White);
                spriteBatch.Draw(playButton_text, playButton, Color.White);
                spriteBatch.Draw(optionsButton_text, optionsButton, Color.White);
                spriteBatch.Draw(exitButton_text, exitButton, Color.White);
            }
            else if (gameState == Gamestate.Playing)
            {
                back_ground.Draw(spriteBatch);
                fantome.Draw(spriteBatch);
                decors.Draw(spriteBatch);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
