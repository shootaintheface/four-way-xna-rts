using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace StateTest
{
    class MouseHandler
    {
        private Vector2 _mousePosition;
        private Texture2D _mousePic;
        private MouseState _mouseCurrentState, _mousePreviousState;
        private Rectangle _mouseBox;
        private Texture2D _selectionTexture;
        private Rectangle _selectionBox;

        #region Properties
        public MouseState MousePreviousState
        {
            get { return _mousePreviousState; }
            set { _mousePreviousState = value; }
        }

        public Vector2 MousePosition
        {
            get { return _mousePosition; }
            set { _mousePosition = value; }
        }

        public Texture2D SelectionTexture
        {
            set { _selectionTexture = value; }
        }

        public Texture2D MousePic
        {
            get { return _mousePic; }
            set { _mousePic = value; }
        }

        public MouseState MouseCurrentState
        {
            get { return _mouseCurrentState; }
            set { _mouseCurrentState = value; }
        }

        public Rectangle MouseBox
        {
            get { return _mouseBox; }
            set { _mouseBox = value; }
        }
        #endregion


        public MouseHandler()
        {
            _mousePosition = Vector2.Zero;
        }

        public void UpdateMouse()
        {

            _mousePosition.X = MouseCurrentState.X;
            _mousePosition.Y = MouseCurrentState.Y;
            MouseBox = new Rectangle((int)MousePosition.X, (int)MousePosition.Y,
                MousePic.Bounds.Width, MousePic.Bounds.Height);

            MousePreviousState = _mouseCurrentState;
            MouseCurrentState = Mouse.GetState();
        }

        public void DrawMouseStuff(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(MousePic, MousePosition, null, Color.White, 0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0f);
        }

        public bool MouseCollision(Rectangle targetRec, bool selected)
        {
            if (targetRec.Intersects(_mouseBox) == true)
            {
                if (selected == true)
                {
                    selected = false;
                }
                else
                {
                    selected = true;
                    _selectionBox = targetRec;
                }
            }
            return selected;
        }
    }
}
