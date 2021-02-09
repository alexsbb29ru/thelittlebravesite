using System.Collections.Generic;
using GameWebSite.Components.Models;

namespace GameWebSite.Services.Interfaces
{
    public interface IGetSocialMedia
    {
        IEnumerable<SocialModel> GetMedia();
    }
}