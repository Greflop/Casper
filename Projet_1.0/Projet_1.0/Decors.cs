using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Test_deplacement
{
    class Decors
    {

        Texture2D decorsTexture;
        Rectangle Block = new Rectangle(400, 501, 995, 48);
        Rectangle Block2 = new Rectangle(100, 700, 995, 100);
        Rectangle Block3 = new Rectangle(500, 100, 120, 50);

        public List<Rectangle> groundHitbox = new List<Rectangle>();

        public Decors(ContentManager content)
        {
            decorsTexture = content.Load<Texture2D>("ground");
            groundHitbox.Add(Block); // a definir [ objet a placer fixe ]
            groundHitbox.Add(Block2);
            groundHitbox.Add(Block3);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(decorsTexture, Block, Color.White);
            spriteBatch.Draw(decorsTexture, Block2, Color.White);
            spriteBatch.Draw(decorsTexture, Block3, Color.White);
        }
    }
}
