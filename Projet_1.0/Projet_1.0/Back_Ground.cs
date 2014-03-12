using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Projet_1._0
{
    class Back_Ground
    {        
        Texture2D Back_GroundTexture;
        int ScreenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        int ScreenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        
        public Back_Ground(ContentManager content)
        {
            Back_GroundTexture = content.Load<Texture2D>("Decors/Background1");
        }
        public void Update()
        {
            // Pour l instant le fond est fixe
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destinationRectangle = new Rectangle(0, 0, ScreenWidth, ScreenHeight);
            spriteBatch.Draw(Back_GroundTexture, destinationRectangle, Color.White);
        }
    }
}
