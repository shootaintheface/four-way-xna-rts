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
    class BandUList
    {
        List<BuildandUpgrade> build, upgrade;
        BuildandUpgrade initialBuild, initialUpgrade;
        Texture2D UpgradeImage, BuildImage;

        Vector2 structPos, bPos;
        Texture2D structImg;
        SpriteBatch spriteBatch;
        Camera2D cam;

        Building.BuildingList bList;

        public BandUList(Game game, SpriteBatch sB, Camera2D cam, Texture2D image, Vector2 pos, Building.BuildingList bL)
        {
            this.spriteBatch = sB;
            this.cam = cam;
            structPos = pos;
            bPos = structPos;
            structImg = image;
            bList = bL;
            UpgradeImage = game.Content.Load<Texture2D>("Upgrade");
            BuildImage = game.Content.Load<Texture2D>("Build");
            initialBuild = new BuildandUpgrade(sB, cam, BuildImage, pos);
            initialUpgrade = new BuildandUpgrade(sB, cam, UpgradeImage, pos);
        }

        public void Update(GameTime gameTime, Vector2 U)
        {
            if (bList == Building.BuildingList.Barracks)
            {
                UpdateBarracks(U);
            }
            else if (bList == Building.BuildingList.Light)
            {

            }
            else if (bList == Building.BuildingList.Heavy)
            {

            }
            else if (bList == Building.BuildingList.Air)
            {

            }
            else if (bList == Building.BuildingList.Command)
            {

            }
        }

        public void Draw(GameTime gameTime)
        {
            if (bList == Building.BuildingList.Barracks)
            {
                DrawBarracks();
            }
            else if (bList == Building.BuildingList.Light)
            {

            }
            else if (bList == Building.BuildingList.Heavy)
            {

            }
            else if (bList == Building.BuildingList.Air)
            {

            }
            else if (bList == Building.BuildingList.Command)
            {

            }
        }

        private void UpdateBarracks(Vector2 updatedPos)
        {
            structPos = new Vector2(updatedPos.X + structImg.Width + 10,
                                    updatedPos.Y - 20);
            Vector2 uPos = structPos;

            //Build Menu
            initialBuild.Position = structPos;
            if (build == null)
            {
                build = new List<BuildandUpgrade>();
                build.Add(initialBuild);
                BuildandUpgrade testB = new BuildandUpgrade(spriteBatch, cam, BuildImage, structPos);

                testB.Position = NextPosition(build);
                build.Add(testB);
            }

            else
            {
                foreach (BuildandUpgrade p in build)
                {
                    p.Update(structPos);
                }
            }
            //Upgrade Menu
            uPos = new Vector2(updatedPos.X + structImg.Width + 10,
                               updatedPos.Y + 40);
            initialUpgrade.Position = uPos;
            if (upgrade == null)
            {
                upgrade = new List<BuildandUpgrade>();
                upgrade.Add(initialUpgrade);
            }

            else
            {
                foreach (BuildandUpgrade u in upgrade)
                {
                    u.Update(structPos);
                }
            }
        }

        private Vector2 NextPosition(List<BuildandUpgrade> bL)
        {
            if (bL != null)
            {
                Vector2 NP;
                BuildandUpgrade bU;
                bU = bL.Last();
                NP = new Vector2(bU.Position.X + bU.Size.Width + 5, bU.Position.Y);
                return NP;
            }
            return new Vector2(0f, 0f);
        }

        private void DrawBarracks()
        {
            //Console.Clear();
            if (build != null)
            {
                foreach (BuildandUpgrade p in build)
                {
                    p.DrawMenu();
                    //Console.WriteLine("Position: " + p.Position.X + ", " + p.Position.Y);
                }
            }
            if (upgrade != null)
            {
                foreach (BuildandUpgrade p in upgrade)
                {
                    p.DrawMenu();
                }
            }

            
            
            
        }
    }
}
