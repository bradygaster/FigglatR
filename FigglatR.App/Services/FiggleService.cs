using System.Collections.Generic;
using System.Linq;
using Figgle;

namespace FigglatR.App.Services
{
    public class FiggleService
    {
        readonly IDictionary<string, FiggleFont> _fonts;

        public FiggleService() =>
            _fonts = typeof(FiggleFonts).GetProperties()
                .Where(x => x.PropertyType == typeof(FiggleFont))
                .OrderBy(x => x.Name)
                .Select(x => (x.Name, Font: (FiggleFont)x.GetValue(typeof(FiggleFonts))))
                .ToDictionary(x => x.Name, x => x.Font);

        public string[] GetFontNames() => _fonts.Keys.ToArray();

        public FiggleFont GetFontByName(string name) =>
            _fonts.TryGetValue(name, out var font) ? font : default;

        public string GetBannerInFont(string fontName, string bannerText)
        {
            try
            {
                return GetFontByName(fontName)?.Render(bannerText) ?? fontName;
            }
            catch
            {
                return fontName;
            }
        }
    }
}