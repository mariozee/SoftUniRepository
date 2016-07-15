using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace YoutubeRPG
{
    public class FadeEffect : ImageEffect
    {
        public float FadeSpeed;
        public bool Increase;

        public FadeEffect()
        {
            this.FadeSpeed = 1;
            this.Increase = false;
        }

        public override void LoadContent(ref Image Image)
        {
            base.LoadContent(ref Image);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (image.IsActive)
            {
                if (!Increase)
                {
                    image.Alpha -= FadeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                else
                {
                    image.Alpha += FadeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

                if (image.Alpha < 0.0f)
                {
                    this.Increase = true;
                    image.Alpha = 0.0f;
                }
                else if (image.Alpha > 1.0f)
                {
                    this.Increase = false;
                    image.Alpha = 1.0f;
                }
            }
            else
            {
                image.Alpha = 1.0f;
            }
        }
    }
}
