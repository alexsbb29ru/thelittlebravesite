using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using GameWebSite.Components.Models;
using GameWebSite.Components.ViewModels;
using GameWebSite.Data;
using GameWebSite.Services.Interfaces;

namespace GameWebSite.Services
{
    public class GetScreenshots : IGetScreenshots
    {
        /// <summary>
        /// Получаем все скриншоты из папки, при это разделяя их на имя и порядковый номер
        /// </summary>
        /// <returns>Список скриншотов</returns>
        public IList<ScreenshotSeparateModel> GetAllScreenshots()
        {
            //Получаем все файлы из папки со скриншотами
            var files = Directory.GetFiles(GlobalPath.LongScreenshotPath);
            IList<ScreenshotSeparateModel> separatedScreens = new List<ScreenshotSeparateModel>();

            foreach (var screenshot in files)
            {
                //Забираем имя и раскидываем с помощью регулярки
                var fileName = Path.GetFileName(screenshot);
                var screenFormat = Path.GetExtension(screenshot);
                var nameRegex = new Regex(@"[A-z]*-([0-9]*)[.][A-z]{3}");
                var fileNumber = nameRegex.Matches(fileName)[0].Groups[1].Value;

                separatedScreens.Add(new ScreenshotSeparateModel()
                {
                    Name = fileName,
                    Number = int.Parse(fileNumber),
                    Format = screenFormat
                });
            }

            return separatedScreens;
        }
        /// <summary>
        /// Получение скриншотов, разделенных на пару "Большой - маленький"
        /// </summary>
        /// <returns>Список объединенных скриншотов</returns>
        public IList<ScreenshotModel> GetSeparatedScreenshots()
        {
            var screenshots = new List<ScreenshotModel>();
            //Забираем скриншоты
            var allScreenshots = 
                GetAllScreenshots()
                    .OrderBy(s => s.Number);

            if (allScreenshots.Any())
            {
                //Раскидываем на пары "Большой - маленький" и объединяем в общую модель
                var currentNumber = -1;

                foreach (var screen in allScreenshots)
                {
                    if (screen.Number == currentNumber) continue;
                    currentNumber = screen.Number;

                    var imageFormat = screen.Format;

                    var mediumScreenName = Path.GetFileName(allScreenshots
                        .FirstOrDefault(s => s.Name.Contains("medium") && s.Number.Equals(currentNumber))?.Name);
                    var largeScreenName = Path.GetFileName(allScreenshots
                        .FirstOrDefault(s => s.Name.Contains("large") && s.Number.Equals(currentNumber))?.Name);

                    if (!string.IsNullOrEmpty(mediumScreenName) && !string.IsNullOrEmpty(largeScreenName))
                    {
                        screenshots.Add(new ScreenshotModel()
                        {
                            Number = currentNumber,
                            Format = imageFormat,
                            MediumImgSrc = $"/images/screenshots/{mediumScreenName}",
                            LargeImgSrc = $"/images/screenshots/{largeScreenName}"
                        });
                    }
                }
            }

            return screenshots;
        }
    }
}