using shop_backend.Database.Seeding.Interfaces;
using shop_backend.Models;
using System.Collections.Generic;
using System.Linq;

namespace shop_backend.Database.Seeding.Seeders
{
    public class UserRolesSeeder: ISeeder
    {
        public void Seed(ShopDbContext context)
        {
            if (!context.UserRoles.Any())
            {
                List<UserRole> roles = new List<UserRole>
                {
                    new UserRole
                    {
                        Id = 1,
                        Name = "Администратор",
                    }
                };

                context.UserRoles.AddRange(roles);
                context.SaveChanges();
            }
        }
    }
}
