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
    class Building : UnitBase
    {
        private string unitName;
        private string uniqueName;
        private Vector2 destination;
        List<MinionBase> testCase = new List<MinionBase>();
        MinionBase minB;
        private bool alive = false;
        KeyboardState keyState, pastState;
        UI uI;
        private int counter = 0;
        BandUList bUL;

        SpriteBatch spriteBatch;
        Game game;
        Camera2D cam;
        MouseHandler mH;

        #region properties
        public string UnitName
        {
            get { return unitName; }
        }

        public bool Alive
        {
            get { return alive; }
            set { alive = value; }
        }

        public int Counter
        {
            get { return counter; }
        }
        #endregion

        public enum BuildingList
        {
            Light,
            Heavy,
            Barracks,
            Air,
            Command
        };

        BuildingList bList;

        public Building(SpriteBatch spriteBatch, Game game, Camera2D cam, MouseHandler mH)
            : base(spriteBatch, game, cam, mH)
        {
            Image = game.Content.Load<Texture2D>("CPU_Pong");
            ImageRec = new Rectangle((int)Position.X, (int)Position.Y, Image.Width, Image.Height);
            unitName = "test";
            uniqueName = "101";
            OType = "building";
            Health = 100;

            bList = BuildingList.Barracks;
            bUL = new BandUList(game, spriteBatch, cam, this.Image, this.Position, bList);

            uI = new UI(game, spriteBatch, cam, mH, this);
            this.spriteBatch = spriteBatch;
            this.game = game;
            this.cam = cam;
            this.mH = mH;
        }

        public override void UpdateUnit(GameTime gameTime)
        {
            keyState = Keyboard.GetState();   
            if (alive == true)
            {
                if (Selection == true)
                {
                    
                    uI.Update(gameTime, this);
                    bUL.Update(gameTime, this.Position);
                    if (keyState.IsKeyDown(Keys.C) && pastState.IsKeyUp(Keys.C))
                    {
                        AddUnit();
                    }
                }
            }
            else if (alive == false)
            {
                if (keyState.IsKeyDown(Keys.S) && pastState.IsKeyUp(Keys.S))
                {
                    
                    this.Position = mH.MousePosition;
                    alive = true;
                }
            }
            

            foreach (MinionBase t in testCase) { t.UpdateUnit(gameTime); }

            pastState = keyState;



            base.UpdateUnit(gameTime);
        }

        public void DrawBuilding(GameTime gameTime)
        {
            if (alive == true)
            {
                this.DrawUnit(gameTime);

                foreach (MinionBase t in testCase)
                {
                    t.DrawUnit(gameTime);
                }

                if (Selection == true)
                {
                    uI.DrawUI(gameTime);
                    bUL.Draw(gameTime);
                }
            }
        }

        private void AddUnit()
        {
            destination.X = this.Position.X - 100;
            destination.Y = this.Position.Y - 100;

            minB = new MinionBase(spriteBatch, game, cam, mH);
            minB.Position = this.Position;
            minB.UnitName = "Min" + counter;
            testCase.Add(minB);
            minB.Destination = destination;
            counter++;
        }


    }
}
