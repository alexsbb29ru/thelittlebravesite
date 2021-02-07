using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GameWebSite.Components.Models;
using GameWebSite.Data;
using GameWebSite.Pages;
using GameWebSite.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace GameWebSite.Components.ViewModels
{
    public class LoadScreenShotsVm : ComponentBase
    {
        [Inject] private IGetScreenshots GetScreenshots { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }

        protected bool IsShowSpinner = false;

        protected readonly IList<ScreenshotSeparateModel> ImageDataUrls = new List<ScreenshotSeparateModel>();
        
        /// <summary>
        /// Допустимые форматы файлов
        /// </summary>
        private string[] _allowedExtensions;

        protected override void OnInitialized()
        {
            _allowedExtensions = new[] {"image/png", "image/jpeg"};
        }

        /// <summary>
        /// Событие загрузки файлов на сервер
        /// </summary>
        /// <returns></returns>
        protected async Task OnLoadFile()
        {
            if (ImageDataUrls.Any())
            {
                //Отобразим спиннер загрузки данных
                IsShowSpinner = true;
                await InvokeAsync(StateHasChanged);

                await Task.Run(async () =>
                {
                    foreach (var image in ImageDataUrls)
                    {
                        //Путь, куда будем грузить скрины
                        var path = GlobalPath.LongScreenshotPath;
                        //Очередной порядковый номер
                        var imageNameIterator = GetFileNameIterator();
                        //Формат изображения
                        var imageFormat = Image.DetectFormat(image.Data).Name;
                        
                        //Формируем исходное изображение
                        var largeImage = Image.Load(image.Data);
                        //Если не удалось сформировать (подкинули фальшивый файл), пропускаем
                        if (largeImage == null)
                            continue;
                        //Формируем изображение поменьше для отображения в карусели на главной странице
                        var mediumImage = largeImage.Clone(x => x.Resize(largeImage.Width / 2, largeImage.Height / 2));
                        
                        //Сохраняем оба файла
                        await largeImage.SaveAsync(
                            $"{path}/{GlobalScreenName.LargeName}-{imageNameIterator}.{imageFormat}");
                        await mediumImage.SaveAsync(
                            $"{path}/{GlobalScreenName.MediumName}-{imageNameIterator}.{imageFormat}");
                    }

                    //Скроем спиннер загрузки
                    IsShowSpinner = false;
                    //Обновим страницу
                    NavigationManager.NavigateTo(nameof(AdminPage), true);
                });
            }
        }

        /// <summary>
        /// Предзагрузочная подготовка выбранных файлов
        /// </summary>
        /// <param name="e">Событие Input при выборе файлов</param>
        /// <returns></returns>
        protected async Task OnInputFileChange(InputFileChangeEventArgs e)
        {
            //Отобразим спиннер загрузки данных
            IsShowSpinner = true;
            await InvokeAsync(StateHasChanged);

            //Максимальное число файлов для загрузки
            const int maxAllowedFiles = 5;
            //Максимальный размер файлов для загрузки
            const int maxAllowedSize = maxAllowedFiles * 1024 * 1024;

            //При каждом новом выборе файлов очищаем коллекцию
            ImageDataUrls.Clear();

            foreach (var imageFile in e.GetMultipleFiles(maxAllowedFiles))
            {
                var buffer = new byte[imageFile.Size];
                await imageFile.OpenReadStream(maxAllowedSize).ReadAsync(buffer);
                var format = imageFile.ContentType;

                //Если не подходит формат файла, пропускаем его
                if (!_allowedExtensions.Any(f => f.ToLower().Equals(imageFile.ContentType.ToLower())))
                    continue;

                //Получаем base64 для формирования нового изображения и получения данных о ширине и высоте
                var base64 = Convert.ToBase64String(buffer);
                var imageUrl = $"data:{format};base64,{base64}";

                //Сохраним в коллекцию для отображения загружаемого файла
                ImageDataUrls.Add(new ScreenshotSeparateModel()
                {
                    Data = buffer,
                    Base64 = imageUrl
                });
            }

            //Скроем спиннер загрузки
            IsShowSpinner = false;
        }

        /// <summary>
        /// Получаем очередной порядковый номер
        /// </summary>
        /// <returns>Следующий порядковый номер для скриншота</returns>
        private int GetFileNameIterator()
        {
            var iterator = 0;
            var screenshots =
                GetScreenshots.GetAllScreenshots();

            if (screenshots != null && screenshots.Any())
                iterator = screenshots.OrderBy(x => x.Number).LastOrDefault().Number;

            iterator++;
            return iterator;
        }
    }
}