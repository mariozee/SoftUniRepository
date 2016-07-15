using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Xml.Serialization;

namespace YoutubeRPG
{
    public class SplashScreen : GameScreen
    {
        public Image Image;

        public override void LoadContent()
        {
            base.LoadContent();
            this.Image.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            this.Image.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            this.Image.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            this.Image.Draw(spriteBatch);
        }
    }
}
