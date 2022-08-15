using System.ComponentModel.DataAnnotations;

namespace WiFi_Antennas_Win.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Поле обязательно к заполнению!")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Длинна Login должны составлять 3-10 символов")]
        public string? Login { get; set; }

        [Required(ErrorMessage = "Поле обязательно к заполнению!")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "Длинна пароля должны составлять 8-15 символов")]
        public string? Password { get; set; }
    }
}
