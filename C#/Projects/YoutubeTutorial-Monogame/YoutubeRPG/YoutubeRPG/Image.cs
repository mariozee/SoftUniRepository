using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Xml.Serialization;
namespace YoutubeRPG
{
    public class Image
    {
        public float Alpha;
        public string Text, FontName, Path;
        public Vector2 Position, Scale;
        public Rectangle SourceRect;

        public Texture2D Texture;
        Vector2 origin;
        ContentManager content;
        RenderTarget2D renderTarget;
        SpriteFont font;

        public Image()
        {
            this.Path = this.Text = String.Empty;
            this.FontName = "Fonts/Consolas";
            this.Position = Vector2.Zero;
            this.Scale = Vector2.One;
            this.Alpha = 1.0f;
            this.SourceRect = Rectangle.Empty;
        }

        public void LoadContent()
        {
            this.content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "Content");

            if (this.Path != string.Empty)
            {
                this.Texture = content.Load<Texture2D>(this.Path);
            }

            this.font = content.Load<SpriteFont>(this.FontName);

            Vector2 dimentions = Vector2.Zero;

            if (this.Texture != null)
            {
                dimentions.X += this.Texture.Width;
            }

            dimentions.X += this.font.MeasureString(this.Text).X;

            if (this.Texture != null)
            {
                dimentions.Y = Math.Max(this.Texture.Height, this.font.MeasureString(this.Text).Y);
            }
            else
            {
                dimentions.Y = font.MeasureString(this.Text).Y;
            }

             
            if (this.SourceRect == Rectangle.Empty)
            { 
                this.SourceRect = new Rectangle(0, 0, (int)dimentions.X, (int)dimentions.Y);
            }

            this.renderTarget = new RenderTarget2D(ScreenManager.Instance.GraphicsDevice, (int)dimentions.X, (int)dimentions.Y);
            ScreenManager.Instance.GraphicsDevice.SetRenderTarget(this.renderTarget);
            ScreenManager.Instance.GraphicsDevice.Clear(Color.Transparent);
            ScreenManager.Instance.SpriteBatch.Begin();
            if (this.Texture != null)
            {
                ScreenManager.Instance.SpriteBatch.Draw(this.Texture, Vector2.Zero, Color.White);
            }

            ScreenManager.Instance.SpriteBatch.DrawString(this.font, this.Text, Vector2.Zero, Color.White);
            ScreenManager.Instance.SpriteBatch.End();

            this.Texture = this.renderTarget;
            ScreenManager.Instance.GraphicsDevice.SetRenderTarget(null);
        }

        public void UnloadContent()
        {
            content.Unload();
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            origin = new Vector2(SourceRect.Width / 2, SourceRect.Height / 2);
            spriteBatch.Draw(Texture, Position + origin, SourceRect, Color.White * Alpha, 0.0f, origin, Scale, SpriteEffects.None, 0.0f);
        }
    }
}
