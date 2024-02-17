using shop_backend.Http.Resources.Misc;

namespace shop_backend.Http.Resources.Address
{
    public class AddressResource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string? CompanyName { get; set; }

        public string Country { get; set; }

        public string Street { get; set; }

        public string HouseAndAppartmentNumber { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string Postcode { get; set; }
    }
}
