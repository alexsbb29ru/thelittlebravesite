using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GameWebSite.Components.Models;
using GameWebSite.Data;
using GameWebSite.Services;
using GameWebSite.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace GameWebSite.Components.ViewModels
{
    public class ScreenshotManageVm : ComponentBase
    {
        [Inject] private IGetScreenshots GetScreenshots { get; set; }
        
        protected readonly List<ScreenshotModel> Screenshots;

        public ScreenshotManageVm()
        {
            Screenshots = new List<ScreenshotModel>();
        }

        protected override void OnInitialized()
        {
            Screenshots.AddRange(GetScreenshots.GetSeparatedScreenshots());
        }
        /// <summary>
        /// Событие удаления скрина из общей папки
        /// </summary>
        /// <param name="e"></param>
        /// <param name="screenNumber">Порядковый номер</param>
        /// <param name="format">Формат изображения</param>
        /// <returns></returns>
        protected async Task RemoveScreenshot(MouseEventArgs e, int screenNumber, string format)
        {
            //Формируем имена скриншотов по образцу
            var largeFileName = $"{GlobalScreenName.LargeName}-{screenNumber}{format}";
            var mediumFileName = $"{GlobalScreenName.MediumName}-{screenNumber}{format}";
            
            //Формируем пути для этих скриншотов
            var largeFilePath = $"{GlobalPath.LongScreenshotPath}\\{largeFileName}";
            var mediumFilePath = $"{GlobalPath.LongScreenshotPath}\\{mediumFileName}";
            
            //Запустим удаление скриншотов из папки
            await Task.Run(() =>
            {
                File.Delete(largeFilePath);
                File.Delete(mediumFilePath);
            });
            //Удалим из коллекции скриншотов, чтобы не нужно было перезгружать страницу
            var screen = Screenshots.FirstOrDefault(s => s.Number == screenNumber);
            Screenshots.Remove(screen);
            //Уведомим об этом View
            await InvokeAsync(StateHasChanged);
        }
    }
}