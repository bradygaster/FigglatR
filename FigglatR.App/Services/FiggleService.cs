using System.Collections.Generic;
using System.Linq;
using Figgle;

namespace FigglatR.App.Services
{
    public class FiggleService
    {
        public string[] GetFontNames()
        {
            return typeof(FiggleFonts).GetProperties()
                .Where(x => x.PropertyType == typeof(FiggleFont))
                .OrderBy(x => x.Name)
                .Select(x => x.Name)
                    .ToArray();
        }

        public FiggleFont GetFontByName(string name)
        {
            return (FiggleFont)typeof(FiggleFonts).GetProperties()
                .Where(x => x.PropertyType == typeof(FiggleFont))
                .Where(x => x.Name == name)
                .First()
                    .GetValue(typeof(FiggleFonts));
        }

        public string GetBannerInFont(string fontName, string bannerText)
        {
            try 
            {
                return GetFontByName(fontName).Render(bannerText);
            }
            catch
            {
                return fontName;
            }
        }
    }
}