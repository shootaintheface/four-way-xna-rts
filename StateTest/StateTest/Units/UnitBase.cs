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
    class UnitBase
    {
        #region Variables
        private Texture2D image;
        private Rectangle imageRec;
        private Vector2 position;
        private bool selection;
        private Rectangle selectionBox;
        private Texture2D selectionTexture;
        private string oType;

        private int health;

        private SpriteBatch spriteBatch;
        private Camera2D cam;
        private MouseHandler mH;

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public string OType
        {
            get { return oType; }
            set { oType = value; }
        }

        public Camera2D Cam
        {
            get { return cam; }
        }

        public MouseHandler MH
        {
            get { return mH; }
        }

        public Texture2D SelectionTexture
        {
            get { return selectionTexture; }
            set { selectionTexture = value; }
        }

        public bool Selection
        {
            get { return selection; }
            set { selection = value; }
        }

        public Texture2D Image
        {
            get { return image; }
            set { image = value; }
        }

        public Rectangle ImageRec
        {
            get { return imageRec; }
            set { imageRec = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        #endregion

        public UnitBase(SpriteBatch spriteBatch, Game game, Camera2D cam, MouseHandler mH)
        {
            selectionTexture = game.Content.Load<Texture2D>("UtilityTextures/SBox");

            this.spriteBatch = spriteBatch;
            this.cam = cam;
            this.mH = mH;
            oType = "unitbase";
        }

        public virtual void UpdateUnit(GameTime gameTime)
        {
            UpdateSelection(mH);
        }

        private void UpdateSelection(MouseHandler mouseH)
        {
            selectionBox.X = (int)position.X - cam.CamPosX;
            selectionBox.Y = (int)position.Y - cam.CamPosY;
            selectionBox.Width = image.Width;
            selectionBox.Height = image.Height + 10;

            if (mouseH.MouseCurrentState.LeftButton == ButtonState.Pressed &&
                mouseH.MousePreviousState.LeftButton == ButtonState.Released)
                selection = mouseH.MouseCollision(this.selectionBox, selection);
        }

        public virtual void DrawUnit(GameTime gameTime)
        {
            spriteBatch.Draw(image, new Rectangle((int)position.X - cam.CamPosX, (int)position.Y - cam.CamPosY,
                                                  imageRec.Width, imageRec.Height),
                             Color.White);
            if (selection == true)
                DrawSelected();
        }

        private void DrawSelected()
        {
            spriteBatch.Draw(selectionTexture, selectionBox, Color.White);
        }

    }
}
