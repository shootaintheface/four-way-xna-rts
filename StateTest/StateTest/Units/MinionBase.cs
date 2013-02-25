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
    class MinionBase : UnitBase
    {
        private string unitName;
        private string uniqueName;
        private Vector2 destination;
        private int speed = 2;
        UI ui;


        public string UnitName
        {
            get { return unitName; }
            set { unitName = value; }
        }

        public Vector2 Destination
        {
            get { return destination; }
            set { destination = value; }
        }

        public MinionBase(SpriteBatch spriteBatch, Game game, Camera2D cam, MouseHandler mH) 
               :base(spriteBatch, game, cam, mH)
        {
            Image = game.Content.Load<Texture2D>("KC_Pong");
            ImageRec = new Rectangle((int)Position.X, (int)Position.Y, Image.Width, Image.Height);
            Position = new Vector2(50, 50);
            OType = "minionbase";
            Health = 100;
            ui = new UI(game, spriteBatch, cam, mH, this);
            unitName = "Minion!";
        }

        public override void UpdateUnit(GameTime gameTime)
        {
            base.UpdateUnit(gameTime);
            UpdateDestination();
            UpdateMovement();
            if (Selection == true)
                ui.Update(gameTime, this);
        }

        private void UpdateDestination()
        {
            if (MH.MouseCurrentState.RightButton == ButtonState.Pressed && this.Selection == true)
            {
                this.destination.X = (MH.MousePosition.X + Cam.CamPosX);
                this.destination.Y = (MH.MousePosition.Y + Cam.CamPosY);
            }
        }

        private void UpdateMovement()
        {
            Vector2 pos = new Vector2(Position.X, Position.Y);
            if (Position.X < destination.X) { pos.X += speed; }
            if (Position.X > destination.X) { pos.X -= speed; }
            if (Position.Y < destination.Y) { pos.Y += speed; }
            if (Position.Y > destination.Y) { pos.Y -= speed; }
            pos.X = Convert.ToInt16(pos.X);
            pos.Y = Convert.ToInt16(pos.Y);
            Position = pos;
           
            
        }

        public override void DrawUnit(GameTime gameTime)
        {
            base.DrawUnit(gameTime);
            if (Selection == true)
                ui.DrawUI(gameTime);
        }
    }
}
