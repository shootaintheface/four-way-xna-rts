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
    class ActionScreen : GameScreen
    {
        KeyboardState keyboardState;
        Terrain tMap;
        Camera2D cam;
        Building unit;
        MouseHandler mouse = new MouseHandler();

        public ActionScreen(Game game, SpriteBatch spriteBatch, Viewport vp)
            : base(game, spriteBatch)
        {
            tMap = new Terrain(game);
            cam = new Camera2D(vp);
            unit = new Building(spriteBatch, game, cam, mouse);
        }

        public void LoadAction()
        {
            tMap.AddTiles("dirttile");
            tMap.AddTiles("grasstile");
            tMap.AddTiles("snowtile");
            tMap.AddTiles("watertile");
            mouse.MousePic = game.Content.Load<Texture2D>("UtilityTextures/RedDot");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            MoveScreen();
            mouse.UpdateMouse();
            unit.UpdateUnit(gameTime);

            base.Update(gameTime);

            


            keyboardState = Keyboard.GetState();
            //Game Logic goes here.
        }

        private void MoveScreen()
        {
            Vector2 outerLimits;
            outerLimits = new Vector2();
            outerLimits = tMap.Edge();

            if (keyboardState.IsKeyDown(Keys.Up)) { cam.ScrollUp(); }
            if (keyboardState.IsKeyDown(Keys.Down)) { cam.ScrollDown(); }
            if (keyboardState.IsKeyDown(Keys.Right)) { cam.ScrollRight(); }
            if (keyboardState.IsKeyDown(Keys.Left)) { cam.ScrollLeft(); }

            cam.LockCamera(tMap.TileWidth, tMap.TileHeight, tMap.newTerrain);

        }

        public override void Draw(GameTime gameTime)
        {
            //Shit that means something to the game goes here.
            tMap.DrawTerrain(spriteBatch, cam);

            unit.DrawBuilding(gameTime);

            mouse.DrawMouseStuff(spriteBatch);

            base.Draw(gameTime);
        }
    }

}