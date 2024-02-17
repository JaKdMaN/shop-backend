using Microsoft.EntityFrameworkCore;
using shop_backend.Database;
using shop_backend.Models;
using shop_backend.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace shop_backend.Repositories
{
    public class UserAddressRepository : IUserAddressRepository
    {
        private ShopDbContext _db;
        public UserAddressRepository(ShopDbContext db)
        {
            _db = db;
        }

        public IQueryable<UserAddress> GetAll(int userId)
        {
            return _db.userAddresses.Where(address => address.UserId == userId);
        }

        public async Task<UserAddress> Create(UserAddress userAddress)
        {
            await _db.AddAsync(userAddress);
            await _db.SaveChangesAsync();

            return userAddress;
        }

        public async Task<UserAddress> GetById(int addressId)
        {
            return await _db.userAddresses.FirstOrDefaultAsync(address => address.Id == addressId);
        }

        public async Task<UserAddress> Update(UserAddress address)
        {
            _db.userAddresses.Update(address);
            await _db.SaveChangesAsync();

            return address;
        }

        public async Task<bool> DeleteById(int addressId)
        {
            _db.Remove(addressId);
            await _db.SaveChangesAsync();

            return true;
        }
    }
}
