using System.ComponentModel.DataAnnotations;

namespace shop_backend.Http.Requests.User
{
    public class ProfileUpdateRequest
    {
        public string? Name { get; set; }

        public string? Surname { get; set; }

        [Required]
        public string Email { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
