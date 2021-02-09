using System.Collections.Generic;
using GameWebSite.Components.Models;
using GameWebSite.Services.Interfaces;

namespace GameWebSite.Services
{
    public class GetSocialMedia : IGetSocialMedia
    {
        public IEnumerable<SocialModel> GetMedia()
        {
            var media = new List<SocialModel>()
            {
                new()
                {
                    SocialName = "Twitter",
                    SocialLogoImgPath = "images/socialMedia/twitter.png",
                    Link = "https://twitter.com/"
                },
                new()
                {
                    SocialName  = "Youtube",
                    SocialLogoImgPath = "images/socialMedia/youtube.png",
                    Link = "#"
                },
                new()
                {
                    SocialName = "Instagram",
                    SocialLogoImgPath = "images/socialMedia/instagram.png",
                    Link = "#"
                }
            };
            return media;
        }
    }
}