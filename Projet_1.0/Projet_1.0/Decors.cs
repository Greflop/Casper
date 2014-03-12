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
        Texture2D Block3x2;
        Texture2D Ground1x3;
        Texture2D Ground5x1;
        Texture2D Ground6x1;
        Texture2D Platform2x1;
        int ScreenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        int ScreenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;


        public List<Rectangle> groundHitbox = new List<Rectangle>();

        public Decors(ContentManager content)
        {
            Block3x2 = content.Load<Texture2D>("Decors/Block3x2");
            Ground1x3 = content.Load<Texture2D>("Decors/Ground1x3");
            Ground5x1 = content.Load<Texture2D>("Decors/Ground5x1");
            Ground6x1 = content.Load<Texture2D>("Decors/Ground6x1");
            Platform2x1 = content.Load<Texture2D>("Decors/Platform2x1");
            double coeffX = ScreenWidth / 1680;
            double coeffY = ScreenHeight / 1050;
            //Rectangle Block = new Rectangle();
           
            Rectangle Block1 = new Rectangle(0, Convert.ToInt32(970*coeffY), Convert.ToInt32(600*coeffX), Convert.ToInt32(80*coeffY));
            Rectangle Block2 = new Rectangle(Convert.ToInt32(720*coeffX), Convert.ToInt32(970*coeffY), Convert.ToInt32(720*coeffX), Convert.ToInt32(80*coeffY));
            Rectangle Block3 = new Rectangle(Convert.ToInt32(1560*coeffX), Convert.ToInt32(730*coeffY), Convert.ToInt32(120*coeffX), Convert.ToInt32(320*coeffY));
            Rectangle Block4 = new Rectangle(Convert.ToInt32(840*coeffX), Convert.ToInt32(890*coeffY), Convert.ToInt32(240*coeffX), Convert.ToInt32(80*coeffY));
            Rectangle Block5 = new Rectangle(Convert.ToInt32(960*coeffX), Convert.ToInt32(810*coeffY), Convert.ToInt32(240*coeffX), Convert.ToInt32(80*coeffY));
            Rectangle Block6 = new Rectangle(Convert.ToInt32(1080*coeffX), Convert.ToInt32(730*coeffY), Convert.ToInt32(120*coeffX), Convert.ToInt32(80*coeffY));
            Rectangle Block7 = new Rectangle(Convert.ToInt32(1320*coeffX), Convert.ToInt32(810*coeffY), Convert.ToInt32(120*coeffX), Convert.ToInt32(80*coeffY));
            Rectangle Block8 = new Rectangle(Convert.ToInt32(1320*coeffX), Convert.ToInt32(570*coeffY), Convert.ToInt32(240*coeffX), Convert.ToInt32(80*coeffY));
            Rectangle Block9 = new Rectangle(Convert.ToInt32(1200*coeffX), Convert.ToInt32(490*coeffY), Convert.ToInt32(240*coeffX), Convert.ToInt32(80*coeffY));
            Rectangle Block10 = new Rectangle(Convert.ToInt32(1080*coeffX), Convert.ToInt32(410*coeffY), Convert.ToInt32(240*coeffX), Convert.ToInt32(80*coeffY));
            Rectangle Block11 = new Rectangle(Convert.ToInt32(840*coeffX), Convert.ToInt32(410*coeffY), Convert.ToInt32(240*coeffX), Convert.ToInt32(80*coeffY));
            Rectangle Block12 = new Rectangle(Convert.ToInt32(840*coeffX), Convert.ToInt32(330*coeffY), Convert.ToInt32(120*coeffX), Convert.ToInt32(80*coeffY));
            Rectangle Block13 = new Rectangle(Convert.ToInt32(480*coeffX), Convert.ToInt32(410*coeffY), Convert.ToInt32(240*coeffX), Convert.ToInt32(80*coeffY));
            Rectangle Block14 = new Rectangle(Convert.ToInt32(120*coeffX), Convert.ToInt32(330*coeffY), Convert.ToInt32(240*coeffX), Convert.ToInt32(80*coeffY));
            Rectangle Block15 = new Rectangle(Convert.ToInt32(120*coeffX), Convert.ToInt32(250*coeffY), Convert.ToInt32(120*coeffX), Convert.ToInt32(80*coeffY));
            Rectangle Block16 = new Rectangle(Convert.ToInt32(360*coeffX), Convert.ToInt32(130*coeffY), Convert.ToInt32(120*coeffX), Convert.ToInt32(80*coeffY));
            Rectangle Block17 = new Rectangle(Convert.ToInt32(600*coeffX), Convert.ToInt32(130*coeffY), Convert.ToInt32(120*coeffX), Convert.ToInt32(80*coeffY));
            Rectangle Block18 = new Rectangle(Convert.ToInt32(840*coeffX), Convert.ToInt32(130*coeffY), Convert.ToInt32(120*coeffX), Convert.ToInt32(80*coeffY));
            Rectangle Block19 = new Rectangle(Convert.ToInt32(1080*coeffX), Convert.ToInt32(130*coeffY), Convert.ToInt32(120*coeffX), Convert.ToInt32(80*coeffY));
            Rectangle Block20 = new Rectangle(Convert.ToInt32(1320*coeffX), Convert.ToInt32(210*coeffY), Convert.ToInt32(120*coeffX), Convert.ToInt32(80*coeffY));
            Rectangle Block21 = new Rectangle(Convert.ToInt32(1560*coeffX), Convert.ToInt32(210*coeffY), Convert.ToInt32(120*coeffX), Convert.ToInt32(80*coeffY));
            groundHitbox.Add(Block1); // a definir [ objet a placer fixe ]
            groundHitbox.Add(Block2);
            groundHitbox.Add(Block3);
            groundHitbox.Add(Block4);
            groundHitbox.Add(Block5);
            groundHitbox.Add(Block6);
            groundHitbox.Add(Block7);
            groundHitbox.Add(Block8);
            groundHitbox.Add(Block9);
            groundHitbox.Add(Block10);
            groundHitbox.Add(Block11);
            groundHitbox.Add(Block12);
            groundHitbox.Add(Block13);
            groundHitbox.Add(Block14);
            groundHitbox.Add(Block15);
            groundHitbox.Add(Block16);
            groundHitbox.Add(Block17);
            groundHitbox.Add(Block18);
            groundHitbox.Add(Block19);
            groundHitbox.Add(Block20);
            groundHitbox.Add(Block21);            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            /*Rectangle Block1 = new Rectangle(0, 970, 600, 80);
            Rectangle Block2 = new Rectangle(720, 970, 720, 80);
            Rectangle Block3 = new Rectangle(1560, 730, 120, 320);
            Rectangle Block4 = new Rectangle(840, 890, 240, 80);
            Rectangle Block5 = new Rectangle(960, 810, 240, 80);
            Rectangle Block6 = new Rectangle(1080, 730, 120, 80);
            Rectangle Block7 = new Rectangle(1320, 810, 120, 80);
            Rectangle Block8 = new Rectangle(1320, 570, 240, 80);
            Rectangle Block9 = new Rectangle(1200, 490, 240, 80);
            Rectangle Block10 = new Rectangle(1080, 410, 240, 80);
            Rectangle Block11 = new Rectangle(840, 410, 240, 80);
            Rectangle Block12 = new Rectangle(840, 330, 120, 80);
            Rectangle Block13 = new Rectangle(480, 410, 240, 80);
            Rectangle Block14 = new Rectangle(120, 330, 240, 80);
            Rectangle Block15 = new Rectangle(120, 250, 120, 80);
            Rectangle Block16 = new Rectangle(360, 130, 120, 80);
            Rectangle Block17 = new Rectangle(600, 130, 120, 80);
            Rectangle Block18 = new Rectangle(840, 130, 120, 80);
            Rectangle Block19 = new Rectangle(1080, 130, 120, 80);
            Rectangle Block20 = new Rectangle(1320, 210, 120, 80);
            Rectangle Block21 = new Rectangle(1560, 210, 120, 80);*/
            double coeffX = ScreenWidth / 1680;
            double coeffY = ScreenHeight / 1050;
            Rectangle Block1 = new Rectangle(0, Convert.ToInt32(970 * coeffY), Convert.ToInt32(600 * coeffX), Convert.ToInt32(80 * coeffY));
            Rectangle Block2 = new Rectangle(Convert.ToInt32(720 * coeffX), Convert.ToInt32(970 * coeffY), Convert.ToInt32(720 * coeffX), Convert.ToInt32(80 * coeffY));
            Rectangle Block3 = new Rectangle(Convert.ToInt32(1560 * coeffX), Convert.ToInt32(730 * coeffY), Convert.ToInt32(120 * coeffX), Convert.ToInt32(320 * coeffY));
            Rectangle Block4 = new Rectangle(Convert.ToInt32(840 * coeffX), Convert.ToInt32(890 * coeffY), Convert.ToInt32(240 * coeffX), Convert.ToInt32(80 * coeffY));
            Rectangle Block5 = new Rectangle(Convert.ToInt32(960 * coeffX), Convert.ToInt32(810 * coeffY), Convert.ToInt32(240 * coeffX), Convert.ToInt32(80 * coeffY));
            Rectangle Block6 = new Rectangle(Convert.ToInt32(1080 * coeffX), Convert.ToInt32(730 * coeffY), Convert.ToInt32(120 * coeffX), Convert.ToInt32(80 * coeffY));
            Rectangle Block7 = new Rectangle(Convert.ToInt32(1320 * coeffX), Convert.ToInt32(810 * coeffY), Convert.ToInt32(120 * coeffX), Convert.ToInt32(80 * coeffY));
            Rectangle Block8 = new Rectangle(Convert.ToInt32(1320 * coeffX), Convert.ToInt32(570 * coeffY), Convert.ToInt32(240 * coeffX), Convert.ToInt32(80 * coeffY));
            Rectangle Block9 = new Rectangle(Convert.ToInt32(1200 * coeffX), Convert.ToInt32(490 * coeffY), Convert.ToInt32(240 * coeffX), Convert.ToInt32(80 * coeffY));
            Rectangle Block10 = new Rectangle(Convert.ToInt32(1080 * coeffX), Convert.ToInt32(410 * coeffY), Convert.ToInt32(240 * coeffX), Convert.ToInt32(80 * coeffY));
            Rectangle Block11 = new Rectangle(Convert.ToInt32(840 * coeffX), Convert.ToInt32(410 * coeffY), Convert.ToInt32(240 * coeffX), Convert.ToInt32(80 * coeffY));
            Rectangle Block12 = new Rectangle(Convert.ToInt32(840 * coeffX), Convert.ToInt32(330 * coeffY), Convert.ToInt32(120 * coeffX), Convert.ToInt32(80 * coeffY));
            Rectangle Block13 = new Rectangle(Convert.ToInt32(480 * coeffX), Convert.ToInt32(410 * coeffY), Convert.ToInt32(240 * coeffX), Convert.ToInt32(80 * coeffY));
            Rectangle Block14 = new Rectangle(Convert.ToInt32(120 * coeffX), Convert.ToInt32(330 * coeffY), Convert.ToInt32(240 * coeffX), Convert.ToInt32(80 * coeffY));
            Rectangle Block15 = new Rectangle(Convert.ToInt32(120 * coeffX), Convert.ToInt32(250 * coeffY), Convert.ToInt32(120 * coeffX), Convert.ToInt32(80 * coeffY));
            Rectangle Block16 = new Rectangle(Convert.ToInt32(360 * coeffX), Convert.ToInt32(130 * coeffY), Convert.ToInt32(120 * coeffX), Convert.ToInt32(80 * coeffY));
            Rectangle Block17 = new Rectangle(Convert.ToInt32(600 * coeffX), Convert.ToInt32(130 * coeffY), Convert.ToInt32(120 * coeffX), Convert.ToInt32(80 * coeffY));
            Rectangle Block18 = new Rectangle(Convert.ToInt32(840 * coeffX), Convert.ToInt32(130 * coeffY), Convert.ToInt32(120 * coeffX), Convert.ToInt32(80 * coeffY));
            Rectangle Block19 = new Rectangle(Convert.ToInt32(1080 * coeffX), Convert.ToInt32(130 * coeffY), Convert.ToInt32(120 * coeffX), Convert.ToInt32(80 * coeffY));
            Rectangle Block20 = new Rectangle(Convert.ToInt32(1320 * coeffX), Convert.ToInt32(210 * coeffY), Convert.ToInt32(120 * coeffX), Convert.ToInt32(80 * coeffY));
            Rectangle Block21 = new Rectangle(Convert.ToInt32(1560 * coeffX), Convert.ToInt32(210 * coeffY), Convert.ToInt32(120 * coeffX), Convert.ToInt32(80 * coeffY));
            spriteBatch.Draw(Ground5x1, Block1, Color.White);
            spriteBatch.Draw(Ground6x1, Block2, Color.White);
            spriteBatch.Draw(Ground1x3, Block3, Color.White);
            spriteBatch.Draw(Platform2x1, Block4, Color.White);
            spriteBatch.Draw(Platform2x1, Block5, Color.White);
            spriteBatch.Draw(Block3x2, Block6, Color.White);
            spriteBatch.Draw(Block3x2, Block7, Color.White);
            spriteBatch.Draw(Platform2x1, Block8, Color.White);
            spriteBatch.Draw(Platform2x1, Block9, Color.White);
            spriteBatch.Draw(Platform2x1, Block10, Color.White);
            spriteBatch.Draw(Platform2x1, Block11, Color.White);
            spriteBatch.Draw(Block3x2, Block12, Color.White);
            spriteBatch.Draw(Platform2x1, Block13, Color.White);
            spriteBatch.Draw(Platform2x1, Block14, Color.White);
            spriteBatch.Draw(Block3x2, Block15, Color.White);
            spriteBatch.Draw(Block3x2, Block16, Color.White);
            spriteBatch.Draw(Block3x2, Block17, Color.White);
            spriteBatch.Draw(Block3x2, Block18, Color.White);
            spriteBatch.Draw(Block3x2, Block19, Color.White);
            spriteBatch.Draw(Block3x2, Block20, Color.White);
            spriteBatch.Draw(Block3x2, Block21, Color.White);
        }
    }
}
