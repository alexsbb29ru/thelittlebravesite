using System;
using System.Collections.Generic;
using GameWebSite.Components.Models;
using GameWebSite.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace GameWebSite.Components.ViewModels
{
    public class FooterVm : ComponentBase
    {
        [Inject]
        private IGetSocialMedia GetSocialMedia { get; set; }
        
        protected IList<SocialModel> SocialsList;
        protected IList<PegiModel> PegiList;
        protected PersonModel DeveloperContact;
        protected string MadeWithLogoSrc;
        protected string CopyrightStr;

        protected override void OnInitialized()
        {
            SocialsList = (IList<SocialModel>) GetSocialMedia.GetMedia();
            PegiList = new List<PegiModel>()
            {
                new()
                {
                    Name = "Pegi",
                    LogoSrc = "images/footer/rates/pegi7.png"
                },
                new()
                {
                    Name = "Violence",
                    LogoSrc = "images/footer/rates/violence.jpg"
                }
            };
            DeveloperContact = new PersonModel()
            {
                Name = "Dmitrii Batov",
                Mail = "mailto:BatovDmitry@yandex.ru",
                Media = new SocialModel()
                {
                    SocialName = "Instagram",
                    Link = "https://www.instagram.com/dmitry.batov"
                }
            };
            MadeWithLogoSrc = "/images/footer/made_with_unity.png";
            CopyrightStr = $"© {DateTime.Now.Year} {DeveloperContact.Name}. The game Little Brave is developing by an " +
                           $"independent single developer. The brand name the Little Brave is property of {DeveloperContact.Name} " +
                           $"by right of first using trademarks and logos are the property of their respective owners.";
        }
    }
}