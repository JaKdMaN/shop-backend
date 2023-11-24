namespace shop_backend.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        // --------------- Связи --------------- //
        public int UserRoleId { get; set; }

        public UserRole UserRole { get; set; }

    }
}
