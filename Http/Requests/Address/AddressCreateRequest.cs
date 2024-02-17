using System.ComponentModel.DataAnnotations;

namespace shop_backend.Http.Requests.Address
{
    public class AddressCreateRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string? CompanyName { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string HouseAndApartmentNumber { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Region { get; set; }

        [Required]
        public string Postcode { get; set; }
    }
}
