using System.Collections.Generic;
using System.Threading.Tasks;
using GameWebSite.Components.Models;
using GameWebSite.Data;
using Microsoft.AspNetCore.Components;

namespace GameWebSite.Components.ViewModels
{
    public class CharacterListVm : ComponentBase
    {
        protected IList<CharacterModel> CharacterList = new List<CharacterModel>();

        public CharacterListVm()
        {
            CharacterList.Add(new CharacterModel()
            {
                Name = "Keely",
                Description = "Keely is responsible and courageous boy. " +
                              "He likes stories about wardens and magic. " +
                              "One day he dreams of going on an adventure to discover the secrets of the past",
                AvatarImageSrc = $"{GlobalPath.ShortCharacterImgPath}/keely.png"
            });
        }
    }
}