using System.Collections.Generic;
using GameWebSite.Components.Models;
using Microsoft.AspNetCore.Components;

namespace GameWebSite.Components.ViewModels
{
    public class TopLinksVm : ComponentBase
    {
        protected List<PlatformModel> Platforms { get; }
        
        public TopLinksVm()
        {
            Platforms = new List<PlatformModel>()
            {
                new PlatformModel()
                {
                    PlatformName = "PlayStation",
                    LogoSrc = "images/ps-logo.svg"
                },
                new PlatformModel()
                {
                    PlatformName = "XBOX",
                    LogoSrc = "images/xbox-logo.svg"
                }
            };
        }
    }
}