using System.Collections.Generic;
using GameWebSite.Components.Models;
using GameWebSite.Components.ViewModels;

namespace GameWebSite.Services.Interfaces
{
    public interface IGetScreenshots
    {
        IList<ScreenshotSeparateModel> GetAllScreenshots();
        IList<ScreenshotModel> GetSeparatedScreenshots();
    }
}