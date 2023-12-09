using Microsoft.EntityFrameworkCore;
using shop_backend.Database;
using shop_backend.Models;
using shop_backend.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace shop_backend.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly ShopDbContext _db;

        public UserRoleRepository(ShopDbContext db) 
        {
            _db = db;
        }

        public IQueryable<UserRole> GetAll()
        {
            return _db.userRoles;
        }

        public async Task<UserRole> GetById(int id)
        {
            return await _db.userRoles.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
