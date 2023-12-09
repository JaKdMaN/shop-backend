using shop_backend.Database.Seeding.Interfaces;
using shop_backend.Helpers;
using shop_backend.Models;
using System.Collections.Generic;
using System.Linq;

namespace shop_backend.Database.Seeding.Seeders
{
    public class UserSeeder : ISeeder
    {
        public void Seed(ShopDbContext context)
        {
            if (!context.users.Any())
            {

                List<User> users = new List<User>
                {
                    new User 
                    {
                        Id = 1,
                        Name = "Максим",
                        Surname = "Потапов",
                        Patronymic = "Андреевич",
                        Email = "admin@example.com",
                        Password = HashPasswordHelper.HashPassword("Password-1"),
                        UserRoleId = 1,
                    }
                };

                context.users.AddRange(users);
                context.SaveChanges();
            }

        }
    }
}
