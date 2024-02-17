namespace shop_backend.Models
{
    public class UserAddress
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string? CompanyName { get; set; }

        public string Country { get; set; }

        public string Street { get; set; }

        public string HouseAndApartmentNumber { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string Postcode { get; set; }

        // --------------------- Связи --------------------- //
        public int UserId { get; set; }

        public User User { get; set; }

    }
}
