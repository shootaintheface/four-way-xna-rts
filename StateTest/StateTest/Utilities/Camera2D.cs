using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StateTest
{
    class Camera2D
    {
        private Viewport _viewport;
        private int cameraPositionX;
        private int cameraPositionY;
        private int cameraSpeed = 4;

        public void ScrollUp() { cameraPositionY -= cameraSpeed; }
        public void ScrollDown() { cameraPositionY += cameraSpeed; }
        public void ScrollRight() { cameraPositionX += cameraSpeed; }
        public void ScrollLeft() { cameraPositionX -= cameraSpeed; }

        public Viewport viewport
        {
            get { return _viewport; }
            set { _viewport = value; }
        }

        public int CamPosX
        {
            get { return cameraPositionX; }
            set { cameraPositionX = value; }
        }

        public int CamPosY
        {
            get { return cameraPositionY; }
            set { cameraPositionY = value; }
        }

        public void LockCamera(int tileWidth, int tileHeight, int[,] map)
        {
            cameraPositionX = (int)MathHelper.Clamp(cameraPositionX, 0, tileWidth * map.GetLength(1)
                - _viewport.Width);
            cameraPositionY = (int)MathHelper.Clamp(cameraPositionY, 0, tileHeight * map.GetLength(0)
                - _viewport.Height);
        }

        public Camera2D(Viewport vp) { _viewport = vp; }
    }
}
