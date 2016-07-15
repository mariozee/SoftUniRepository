using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace YoutubeRPG
{
    public class ScreenManager
    {
        private static ScreenManager instance;
        GameScreen currentScreen;
        public GraphicsDevice GraphicsDevice;
        public SpriteBatch SpriteBatch;
        XmlManager<GameScreen> xmlGameScreenManager;


        public ScreenManager()
        {
            this.Dimentions = new Vector2(1500, 1000);
            this.currentScreen = new SplashScreen();
            this.xmlGameScreenManager = new XmlManager<GameScreen>();
            this.xmlGameScreenManager.Type = this.currentScreen.Type;
            this.currentScreen = xmlGameScreenManager.Load("Load/SplashScreen.xml");
        }

        public ContentManager Content { get; private set; }

        public Vector2 Dimentions { get; private set; }


        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ScreenManager();
                }

                return instance;
            }
        }

        public void LoadContent(ContentManager content)
        {
            this.Content = new ContentManager(content.ServiceProvider, "Content");
            currentScreen.LoadContent();
        }

        public void UnloadContent()
        {
            currentScreen.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);
        }
    }
}
