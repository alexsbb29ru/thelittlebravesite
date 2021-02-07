namespace GameWebSite.Components.Models
{
    public class ScreenshotModel
    {
        private int _number;
        private string _format;
        private string _smallImgSrc;
        private string _mediumImgSrc;
        private string _largeImgSrc;

        public int Number
        {
            get => _number;
            set => _number = value;
        }

        public string Format
        {
            get => _format;
            set => _format = value;
        }

        public string SmallImgSrc
        {
            get => _smallImgSrc;
            set => _smallImgSrc = value;
        }

        public string MediumImgSrc
        {
            get => _mediumImgSrc;
            set => _mediumImgSrc = value;
        }

        public string LargeImgSrc
        {
            get => _largeImgSrc;
            set => _largeImgSrc = value;
        }
    }
}