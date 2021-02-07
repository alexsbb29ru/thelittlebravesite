using System.ComponentModel.DataAnnotations;

namespace GameWebSite.Components.Models
{
    public class CharacterModel
    {
        public string Name { get; set; }
        public string AvatarImageSrc { get; set; }
        public string Description { get; set; }
    }
}