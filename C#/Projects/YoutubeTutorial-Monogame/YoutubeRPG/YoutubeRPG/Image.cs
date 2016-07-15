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
        public bool IsActive;


        public Texture2D Texture;
        Vector2 origin;
        ContentManager content;
        RenderTarget2D renderTarget;
        SpriteFont font;
        Dictionary<string, ImageEffect> effectList;
        public string Effects;

        public FadeEffect FadeEffect;

        public Image()
        {
            this.Path = this.Text = Effects = String.Empty;
            this.FontName = "Fonts/Consolas";
            this.Position = Vector2.Zero;
            this.Scale = Vector2.One;
            this.Alpha = 1.0f;
            this.SourceRect = Rectangle.Empty;
            effectList = new Dictionary<string, ImageEffect>();
        }

        void SetEffect<T>(ref T effect)
        {
            if (effect == null)
            {
                effect = (T)Activator.CreateInstance(typeof(T));
            }
            else
            {
                (effect as ImageEffect).IsActive = true;
                var obj = this;
                (effect as ImageEffect).LoadContent(ref obj);
            }

            effectList.Add(effect.GetType().ToString().Replace("YoutubeRPG.", ""), (effect as ImageEffect));
        }

        public void ActivateEffect(string effect)
        {
            if (effectList.ContainsKey(effect))
            {
                effectList[effect].IsActive = true;
                var obj = this;
                effectList[effect].LoadContent(ref obj);
            }
        }

        public void DeactivateEffect(string effect)
        {
            if (effectList.ContainsKey(effect))
            {
                effectList[effect].IsActive = false;
                effectList[effect].UnloadContent();
            }
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

            SetEffect<FadeEffect>(ref FadeEffect);

            if (Effects != string.Empty)
            {
                string[] split = Effects.Split(':');
                foreach (var item in split)
                {
                    ActivateEffect(item);
                }
            }

        }

        public void UnloadContent()
        {
            content.Unload();
            foreach (var effect in effectList)
            {
                DeactivateEffect(effect.Key);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (var effect in effectList)
            {
                if (effect.Value.IsActive)
                {
                    effect.Value.Update(gameTime);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            origin = new Vector2(SourceRect.Width / 2, SourceRect.Height / 2);
            spriteBatch.Draw(Texture, Position + origin, SourceRect, Color.White * Alpha, 0.0f, origin, Scale, SpriteEffects.None, 0.0f);
        }
    }
}
