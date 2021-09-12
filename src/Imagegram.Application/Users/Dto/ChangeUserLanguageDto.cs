using System.ComponentModel.DataAnnotations;

namespace Imagegram.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}