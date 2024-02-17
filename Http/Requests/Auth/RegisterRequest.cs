using System.ComponentModel.DataAnnotations;

namespace shop_backend.Http.Requests.Auth
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Поле Email обязательно для заполнения")]
        public string username { get; set; }

        [Required(ErrorMessage = "Поле пароль обязательно для заполнения")]
        public string password { get; set; }

        [Required]
        [Compare("password", ErrorMessage = "Пароли должны совпадать")]
        public string repeatPassword { get; set; }
    }
}
