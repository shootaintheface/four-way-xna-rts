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
    class BuildandUpgrade
    {
        private string name, description;
        private int cost;
        private Vector2 position;
        private Rectangle size;
        private Texture2D image;
        private bool available;

        private SpriteBatch spriteBatch;
        private Camera2D cam;

        #region properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Rectangle Size
        {
            get { return size; }
            set { size = value; }
        }

        public Texture2D Image
        {
            get { return image; }
            set { image = value; }
        }

        public bool Available
        {
            get { return available; }
            set { available = value; }
        }
        #endregion

        public BuildandUpgrade(SpriteBatch spriteBatch, Camera2D cam, Texture2D image, Vector2 pos)
        {
            this.spriteBatch = spriteBatch;
            this.cam = cam;
            this.image = image;

            size.Width = 30;
            size.Height = 30;
            this.position = pos;
            size.X = (int)position.X;
            size.Y = (int)position.Y;
         }

        public void Update(Vector2 pos)
        {
            size.X = (int)position.X;
            size.Y = (int)position.Y;
            size.Width = 30;
            size.Height = 30;
        }

        public void DrawMenu()
        {
            spriteBatch.Draw(image, new Rectangle(size.X - cam.CamPosX, size.Y- cam.CamPosY, size.Width, size.Height), Color.White);
            //Console.WriteLine("Position: " + this.position.X + ", " + this.position.Y);
        }
    }
}
