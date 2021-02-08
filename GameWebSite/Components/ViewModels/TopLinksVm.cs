using System.Collections.Generic;
using GameWebSite.Components.Models;
using Microsoft.AspNetCore.Components;

namespace GameWebSite.Components.ViewModels
{
    public class TopLinksVm : ComponentBase
    {
        protected List<PlatformModel> Platforms { get; }
        protected bool IsAvailable = false;
        
        public TopLinksVm()
        {
            Platforms = new List<PlatformModel>()
            {
                new PlatformModel()
                {
                    PlatformName = "Steam",
                    LogoSrc = "images/steam.png"
                },
                new PlatformModel()
                {
                    PlatformName = "Epic games",
                    LogoSrc = "images/epic_games.png"
                }
            };
        }
    }
}