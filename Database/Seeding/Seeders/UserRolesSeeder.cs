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
            if (!context.userRoles.Any())
            {
                List<UserRole> roles = new List<UserRole>
                {
                    new UserRole
                    {
                        Id = 1,
                        Name = "admin",
                    },
                    new UserRole
                    {
                        Id= 2,
                        Name = "customer",
                    }
                };

                context.userRoles.AddRange(roles);
                context.SaveChanges();
            }
        }
    }
}
