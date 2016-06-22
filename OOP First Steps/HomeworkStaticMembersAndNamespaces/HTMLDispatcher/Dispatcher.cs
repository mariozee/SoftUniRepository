using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLDispatcher
{
    class Dispatcher
    {
        public static ElementBuilder CreateImage(string imageSrc, string alt, string title)
        {
            var img = new ElementBuilder("img");
            img.AddAtribute("title", title);
            img.AddAtribute("alt", alt);
            img.AddAtribute("src", imageSrc);

            return img;
        }       

        public static ElementBuilder CreateURL(string urlSrc, string title, string text)
        {
            var url = new ElementBuilder("url");
            url.AddAtribute("URL", urlSrc);
            url.AddAtribute("title", title);
            url.AddContent(text);

            return url;
        }

        public static ElementBuilder CreateInput(string inputType, string name, string value)
        {
            var input = new ElementBuilder("input");
            input.AddAtribute("input type", inputType);
            input.AddAtribute("name", name);
            input.AddAtribute("value", value);

            return input;
        }
    }
}
