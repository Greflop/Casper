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
            graphics.PreferredBackBufferWidth = 1680;           // RESOLUTION D ECRAN
            graphics.PreferredBackBufferHeight = 1050;           // RESOLUTION D ECRAN
            graphics.IsFullScreen = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = true;

            gameState = Gamestate.StartMenu;

            playButton = new Rectangle(700, 450, 352, 88);
            optionsButton = new Rectangle(700, 600, 352, 88);
            exitButton = new Rectangle(700, 750, 352, 88);
            
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
        }


        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) // De base, no use???
                this.Exit();
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);  // touche exit
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

                fantome.Update(Keyboard.GetState(), GraphicsDevice, decors);
                if (checkExitKey(keyboardState)) //, gamePadState))             //
                {
                    gameState = Gamestate.StartMenu;
                }                                                               //

            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            if (gameState == Gamestate.StartMenu)
            {
                spriteBatch.Draw(startMenu_text, new Rectangle(0, 0, 1680, 1050), Color.White);
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
