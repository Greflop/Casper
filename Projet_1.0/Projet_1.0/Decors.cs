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
        Rectangle hitbox;
        public Vector2 pos;

        public Rectangle groundHitbox
        {
            get { return hitbox; }
            set { hitbox = value; }
        }
        public Vector2 groundPos
        {
            get { return pos; }
            set { pos = value; }
        }

        public Decors(ContentManager content)
        {
            decorsTexture = content.Load<Texture2D>("ground");
            hitbox = new Rectangle(400, 500,995, 48); // a definir [ objet a placer fixe ]
            pos = new Vector2(897, 524);
        }

        public void Update(Fantome fantome)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(decorsTexture, hitbox, Color.White);
        }
    }
}
