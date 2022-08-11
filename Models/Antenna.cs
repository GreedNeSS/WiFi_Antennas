using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WiFi_Antennas_Win.Models
{
    [Index("Ip", IsUnique = true)]
    public class Antenna
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле обязательно к заполнению!")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Длинна адреса должны составлять 5-30 символов")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Поле обязательно к заполнению!")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Длинна SSID должны составлять 4-10 символов")]
        public string? SSID { get; set; }

        [Required(ErrorMessage = "Поле обязательно к заполнению!")]
        [StringLength(15, MinimumLength = 7, ErrorMessage = "Длинна IP адреса должны составлять 7-15 символов")]
        public string? Ip { get; set; }
        public bool IsServer { get; set; }

        [Required(ErrorMessage = "Поле обязательно к заполнению!")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Длинна Login должны составлять 3-10 символов")]
        public string? Login { get; set; }

        [Required(ErrorMessage = "Поле обязательно к заполнению!")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "Длинна пароля должны составлять 8-15 символов")]
        public string? Password { get; set; }
        public int ChannelWidth { get; set; } = 40;
        public int Channel { get; set; } = 1;
    }
}
