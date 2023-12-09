using System.ComponentModel.DataAnnotations;

namespace shop_backend.Http.Requests.Auth
{
    public class RegisterRequest
    {
        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        [Compare("password")]
        public string repeatPassword { get; set; }
    }
}
