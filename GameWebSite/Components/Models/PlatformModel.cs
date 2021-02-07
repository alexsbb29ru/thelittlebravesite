namespace GameWebSite.Components.Models
{
    public class PlatformModel
    {
        private string _platformName;
        private string _logoSrc;
        
        public string PlatformName
        {
            get => _platformName;
            set => _platformName = value;
        }
        public string LogoSrc
        {
            get => _logoSrc;
            set => _logoSrc = value;
        }
    }
}