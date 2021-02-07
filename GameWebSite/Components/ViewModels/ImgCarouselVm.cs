using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using GameWebSite.Components.Models;
using GameWebSite.Data;
using GameWebSite.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;

namespace GameWebSite.Components.ViewModels
{
    public class ImgCarouselVm : ComponentBase
    {
        [Inject] private IGetScreenshots GetScreenshots { get; set; }
        
        protected readonly List<ScreenshotModel> Screenshots;

        public ImgCarouselVm()
        {
            Screenshots = new List<ScreenshotModel>();
        }

        protected override void OnInitialized()
        {
            LoadImages();
        }
        /// <summary>
        /// Загружаем скриншоты для отображения в карусельке
        /// </summary>
        private void LoadImages()
        {
            Screenshots.AddRange(GetScreenshots.GetSeparatedScreenshots());
        }
    }
}