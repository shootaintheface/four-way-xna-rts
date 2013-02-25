using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace StateTest
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState keyboardState;
        KeyboardState oldKeyState;
        public static Viewport viewPort;

        GameScreen activeScreen;
        StartScreen startScreen;
        ActionScreen actionScreen;
        AreYouSure ynScreen;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            viewPort.Width = graphics.PreferredBackBufferWidth;
            viewPort.Height = graphics.PreferredBackBufferHeight;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            startScreen = new StartScreen(this, spriteBatch, Content.Load<SpriteFont>("menufont"),
                                          Content.Load<Texture2D>("GameScreen/ActiveArtillery"));
            Components.Add(startScreen);
            startScreen.Hide();

            actionScreen = new ActionScreen(this, spriteBatch, viewPort);
            actionScreen.LoadAction();
            Components.Add(actionScreen);
            actionScreen.Hide();

            ynScreen = new AreYouSure(this, spriteBatch, Content.Load<SpriteFont>("menufont"),
                                      Content.Load<Texture2D>("GameScreen/CoastGun"));
            Components.Add(ynScreen);
            ynScreen.Hide();

            activeScreen = startScreen;
            activeScreen.Show();
            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            keyboardState = Keyboard.GetState();

            if (activeScreen == startScreen)
            {
                HandleStartScreen();
            }
            else if (activeScreen == actionScreen)
            {
                HandleActionScreen();
            }
            else if (activeScreen == ynScreen)
            {
                HandleYNScreen();
            }

            base.Update(gameTime);
            oldKeyState = keyboardState;
        }

        private void HandleStartScreen()
        {
            if (CheckKey(Keys.Enter))
            {
                if (startScreen.SelectedIndex == 0)
                {
                    activeScreen.Hide();
                    activeScreen = actionScreen;
                    activeScreen.Show();
                }
                if (startScreen.SelectedIndex > 1)
                {
                    this.Exit();
                }
            }
        }

        private void HandleActionScreen()
        {
            if (CheckKey(Keys.Escape))
            {
                activeScreen.Enabled = false;
                activeScreen = ynScreen;
                activeScreen.Show();
            } 
        }

        private void HandleYNScreen()
        {
            //Console.WriteLine("Index: "+ ynScreen.SelectedIndex);
            if (CheckKey(Keys.Enter))
            {
                if (ynScreen.SelectedIndex == 0)
                {
                    activeScreen.Hide();
                    activeScreen = actionScreen;
                    activeScreen.Hide();
                    activeScreen = startScreen;
                    activeScreen.Show();
                }
                if (ynScreen.SelectedIndex == 1)
                {
                    activeScreen.Hide();
                    activeScreen = actionScreen;
                    activeScreen.Show();
                }
            }
        }

        private bool CheckKey(Keys theKey)
        {
            return keyboardState.IsKeyUp(theKey) &&
            oldKeyState.IsKeyDown(theKey);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
