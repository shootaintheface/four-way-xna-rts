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
    class StatusBar
    {
        private Vector2 position;
        private Texture2D image;
        private int length;
        private Rectangle size;
        PosImg[] pImgA;
        PosImg pImg;
        SpriteBatch spriteBatch;
        Camera2D cam;

        public Rectangle Size
        {
            get { return size; }
            set { size = value; }
        }

        public StatusBar(Vector2 pos, Texture2D img, int len, Rectangle size, string Direction, SpriteBatch spriteBatch, Camera2D cam)
        {
            this.position = pos;
            this.image = img;
            this.length = len;
            this.size = size;
            this.spriteBatch = spriteBatch;
            this.cam = cam;

            length = (int)(length / 10);
            pImgA = new PosImg[length];

            for (int i = 0; i < length; i++)
            {
                pImg = new PosImg(position, image);
                pImgA[i] = pImg;

                if (Direction == "Right")
                {
                    position.X += size.Width + 1;
                }
                else if (Direction == "Left")
                {
                    position.X -= size.Width - 1;
                }
                else if (Direction == "Up")
                {
                    position.Y -= size.Height - 1;
                }
                else if (Direction == "Down")
                {
                    position.Y += size.Height + 1;
                }
            }
        }

        public void DrawStatus(GameTime gameTime)
        {
            for (int i = 0; i < length; i++)
            {
                spriteBatch.Draw(pImgA[i].Texture, new Rectangle((int)pImgA[i].Postion.X -cam.CamPosX, (int)pImgA[i].Postion.Y - cam.CamPosY, size.Width, size.Height),
                                 Color.White);
            }
        }




    }

    partial class PosImg
    {
        private Vector2 position;
        private Texture2D texture;

        public PosImg(Vector2 pos, Texture2D tex)
        {
            this.position = pos;
            this.texture = tex;
        }

        public Vector2 Postion
        {
            get { return position; }
            set { position = value; }
        }

        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }
    }
}
