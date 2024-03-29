﻿using Microsoft.EntityFrameworkCore;
using shop_backend.Models;

namespace shop_backend.Database
{
    public class ShopDbContext: DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }

        public DbSet<User> users { get; set; }
        public DbSet<UserRole> userRoles { get; set; }
        public DbSet<UserAddress> userAddresses { get; set; }
    }
}
