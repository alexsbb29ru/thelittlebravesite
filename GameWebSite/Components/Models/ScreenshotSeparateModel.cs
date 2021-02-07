namespace GameWebSite.Components.Models
{
    public class ScreenshotSeparateModel
    {
        public string Name { get; init; }
        public int Number { get; init; }
        
        public byte[] Data { get; set; }
        public string Base64 { get; set; }
        public string Format { get; set; }
    }
}