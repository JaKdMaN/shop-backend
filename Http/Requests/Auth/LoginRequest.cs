using System.ComponentModel.DataAnnotations;

namespace shop_backend.Http.Requests.Auth
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public bool remember { get; set; }
    }
}
