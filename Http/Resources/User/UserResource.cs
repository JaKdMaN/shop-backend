using shop_backend.Http.Resources.Auth;
using shop_backend.Http.Resources.Misc;

namespace shop_backend.Http.Resources.User
{
    public class UserResource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public NameValueResource Role { get; set; }
    }
}
