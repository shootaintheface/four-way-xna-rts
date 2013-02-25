using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace StateTest
{
    class Terrain
    {
        private int tileWidth = 64;
        private int tileHeight = 64;
        Game game;
        List<Texture2D> tiles;
        private string rootFolder = "TerrainTextures/";
        public Terrain(Game game)
        {
            tiles = new List<Texture2D>();
            this.game = game;
        }

        public int TileWidth
        {
            get { return tileWidth; }
            set { tileWidth = value; }
        }

        public int TileHeight
        {
            get { return tileHeight; }
            set { tileHeight = value; }
        }

        public int[,] newTerrain = {
                        {0,1,1,2,2,3,3,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                        {0,1,1,2,2,3,3,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                        {0,1,1,2,2,3,3,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                    };

        public void AddTiles(string tileName)
        {
            tiles.Add(game.Content.Load<Texture2D>(rootFolder + tileName));
        }

        public void DrawTerrain(SpriteBatch spriteBatch, Camera2D cam)
        {
            for (int y = 0; y < newTerrain.GetLength(0); y++)
            {
                for (int x = 0; x < newTerrain.GetLength(1); x++)
                {
                    spriteBatch.Draw(tiles[newTerrain[y, x]], new Rectangle(x * tileWidth - cam.CamPosX,
                        y * tileHeight - cam.CamPosY, tileWidth, tileHeight),
                        Color.White);
                }
            }
        }

        public Vector2 Edge()
        {
            Vector2 Limits;
            if (newTerrain != null)
            {
                int width = newTerrain.GetLength(1);
                int height = newTerrain.GetLength(0);
                width = width * tileWidth;
                height = height * tileHeight;

                Limits = new Vector2(width, height);
                return Limits;
            }
            else
            {
                Limits = new Vector2(0, 0);
                return Limits;
            }
        }
    }
}
