using System.IO;

namespace GameWebSite.Data
{
    public static class GlobalPath
    {
        public static string LongScreenshotPath => $"{Directory.GetCurrentDirectory()}{@"\wwwroot\images\screenshots"}";
        public static string LongImagePath => $"{Directory.GetCurrentDirectory()}{@"\wwwroot\images\"}";
        public static string LongCharacterImgPath => $"{Directory.GetCurrentDirectory()}{@"\wwwroot"}{ShortCharacterImgPath}";
        public static string ShortCharacterImgPath => "/images/characters";
    }
}