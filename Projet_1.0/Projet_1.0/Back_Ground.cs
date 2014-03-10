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
        public Back_Ground(ContentManager content)
        {
            Back_GroundTexture = content.Load<Texture2D>("BackGround");
        }
        public void Update()
        {
            // Pour l instant le fond est fixe
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Back_GroundTexture, new Vector2(0,0), Color.White);
        }
    }
}
