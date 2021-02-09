using System;
using System.Collections.Generic;
using GameWebSite.Components.Models;
using GameWebSite.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace GameWebSite.Components.ViewModels
{
    public class SocialNetVm : ComponentBase
    {
        [Inject] private IGetSocialMedia GetSocialMedia { get; set; }
        
        protected IList<SocialModel> SocialsList;

        protected override void OnInitialized()
        {
            SocialsList = (IList<SocialModel>) GetSocialMedia.GetMedia();
        }
    }
}