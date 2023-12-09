using Microsoft.EntityFrameworkCore;
using shop_backend.Database;
using shop_backend.Models;
using shop_backend.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace shop_backend.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly ShopDbContext _db;

        public UserRepository(ShopDbContext db) 
        {
            _db = db;
        }

        public async Task<User> Create(User entity)
        {
            await _db.users.AddAsync(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        public IQueryable<User> GetAll()
        {
            return _db.users.Include(u => u.UserRole);
        }

        public async Task<User> GetById(int id)
        {
            return await _db.users.Include(u => u.UserRole).FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<User> GetByToken(string token)
        {
            return await _db.users.Include(u => u.UserRole).FirstOrDefaultAsync(u => u.RefreshToken == token);
        }

        public async Task<User> Update(User entity)
        {
            _db.users.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Delete(User entity)
        {
            _db.Remove(entity);
            await _db.SaveChangesAsync();

            return true;
        }

    }
}
