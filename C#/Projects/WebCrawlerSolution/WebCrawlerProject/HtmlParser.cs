using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebCrawlerProject
{
    public class HtmlParser
    {
        private const string ImgTagPattern = "<img.*?src=\"(.*?)\".*?>";
        //TODO: cache regex
        public static List<string> ParseImgTags(string html)
        {
            MatchCollection matches = Regex.Matches(html, ImgTagPattern);
            return matches
                .Cast<Match>()
                .Select(m => m.Groups[1].Value)
                .ToList();
        }
    }
}
