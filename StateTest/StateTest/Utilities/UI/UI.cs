using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace StateTest
{
    class UI
    {
        private int health, progress;
        private Texture2D[] h, p;
        //private Texture2D[] building, upgrade;
        private string name;
        private Texture2D healthBox, progBox;
        private Rectangle size;
        private StatusBar sBar;
        private Vector2 pos;
        private SpriteFont spriteName;
        private Vector2 fontLoc;

        private SpriteBatch spriteBatch;
        private Game game;
        private Camera2D cam;
        private MouseHandler mH;

        //****************************************
        // THIS IS FOR THE BUILDING CLASS
        //****************************************
        public UI(Game game, SpriteBatch spriteBatch, Camera2D cam, MouseHandler mH, Building b)
        {
            this.game = game;
            this.spriteBatch = spriteBatch;
            this.cam = cam;
            this.mH = mH;

            pos = new Vector2(b.Position.X, b.ImageRec.Height);
            size = new Rectangle((int)b.Position.X, (int)b.Position.Y, b.ImageRec.Width / 10, 10);
            progBox = game.Content.Load<Texture2D>("UtilityTextures/RedBox");
            healthBox = game.Content.Load<Texture2D>("UtilityTextures/RedBox");
            sBar = new StatusBar(pos, healthBox, health, size, "Right", spriteBatch, cam);

            //font
            spriteName = game.Content.Load<SpriteFont>("menufont");
            fontLoc = new Vector2(b.Position.X, b.Position.Y - 10);
            name = b.UnitName;
            //Console.WriteLine("Font Location: " + fontLoc.X + ", " + fontLoc.Y);
        }

        //****************************************
        // THIS IS FOR THE MINION CLASS
        //****************************************
        public UI(Game game, SpriteBatch spriteBatch, Camera2D cam, MouseHandler mH, MinionBase m)
        {
            this.game = game;
            this.spriteBatch = spriteBatch;
            this.cam = cam;
            this.mH = mH;
            
            pos = new Vector2(m.Position.X, m.ImageRec.Height);
            progBox = game.Content.Load<Texture2D>("UtilityTextures/RedBox");
            healthBox = game.Content.Load<Texture2D>("UtilityTextures/RedBox");
            size = new Rectangle((int)m.Position.X, (int)m.Position.Y, m.ImageRec.Width / 10, 10);
            sBar = new StatusBar(m.Position, healthBox, health, size, "Right", spriteBatch, cam);
            //font
            spriteName = game.Content.Load<SpriteFont>("menufont");
            fontLoc = new Vector2(m.Position.X, m.Position.Y - 10);
            name = m.UnitName;
        }

        public void Update(GameTime gameTime, Building b)
        {
            GetObject(b);

            //Console.Clear();
            //Console.WriteLine("Lower Left Corner: " + pos);
            //Console.WriteLine("Upper Right Corner: " + b.Position);
            //Console.WriteLine("Size of object (w, H): " + b.Image.Width + ", " + b.ImageRec.Height);
            //Console.WriteLine("Size of Health Bar: " + size.Width + ", " + size.Height);
            //Console.WriteLine("Font Location: " + fontLoc.X + ", " + fontLoc.Y);
        }

        public void Update(GameTime gameTime, MinionBase m)
        {
            GetObject(m);


        }

        public void DrawUI(GameTime gameTime)
        {
            sBar.DrawStatus(gameTime);
            if (name != null)
                spriteBatch.DrawString(spriteName, name, new Vector2(fontLoc.X - cam.CamPosX, fontLoc.Y - cam.CamPosY), Color.White);
            
        }

        private void GetObject(Building b)
        {
            pos = new Vector2(b.Position.X, b.ImageRec.Height + b.Position.Y);

            //font
            name = b.UnitName;
            fontLoc.X = b.Position.X;
            fontLoc.Y  =  b.Position.Y - 20;
            //end font

            health = b.Health;
            
            size = new Rectangle((int)pos.X, (int)pos.Y, b.ImageRec.Width / 10, 10);           
            h = new Texture2D[health];
            sBar = new StatusBar(pos, healthBox, health, size, "Right", spriteBatch, cam);

        }

        private void GetObject(MinionBase m)
        {
            pos = new Vector2(m.Position.X, m.Position.Y + m.ImageRec.Height);
            
            //font
            name = m.UnitName;
            fontLoc.X = m.Position.X;
            fontLoc.Y = m.Position.Y - 20;
            //end font

            health = m.Health;

            size = new Rectangle((int)pos.X, (int)pos.Y, m.ImageRec.Width / 10, 10);
            h = new Texture2D[health];
            sBar = new StatusBar(pos, healthBox, health, size, "Right", spriteBatch, cam);
        }

    }
}
