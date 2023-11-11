using Microsoft.EntityFrameworkCore;

namespace shop_backend.Database
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }
    }
}
