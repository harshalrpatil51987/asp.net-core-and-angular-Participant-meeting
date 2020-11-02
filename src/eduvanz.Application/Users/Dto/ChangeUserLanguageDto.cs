using System.ComponentModel.DataAnnotations;

namespace eduvanz.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}