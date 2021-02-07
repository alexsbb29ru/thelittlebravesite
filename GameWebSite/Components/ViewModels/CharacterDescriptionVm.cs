using Microsoft.AspNetCore.Components;

namespace GameWebSite.Components.ViewModels
{
    public class CharacterDescriptionVm : ComponentBase
    {
        [Parameter]
        public string CharacterDescription { get; set; }
        [Parameter] 
        public string ImageSrc { get; set; }
    }
}