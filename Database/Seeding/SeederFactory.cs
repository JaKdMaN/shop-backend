using shop_backend.Database.Seeding.Interfaces;
using System.Collections.Generic;

namespace shop_backend.Database.Seeding
{
    public class SeederFactory
    {
        private readonly IEnumerable<ISeeder> _seeders;

        public SeederFactory (IEnumerable<ISeeder> seeders)
        {
            _seeders = seeders;
        }
 
        public void SeedAll(ShopDbContext context)
        {
            foreach (var seeder in _seeders)
            {
                seeder.Seed(context);
            }
        }

    }
}
