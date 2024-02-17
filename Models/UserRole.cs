using System.Collections.Generic;

namespace shop_backend.Models
{
    public class UserRole
    {
        public int Id { get; set; }

        public string Name { get; set; }

        // --------------- Связи --------------- //
        public ICollection<User> Users { get; set; }
    }
}
