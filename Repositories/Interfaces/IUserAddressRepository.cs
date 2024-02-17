using System.Linq;
using shop_backend.Models;
using System.Threading.Tasks;

namespace shop_backend.Repositories.Interfaces
{
    public interface IUserAddressRepository
    {
        IQueryable<UserAddress> GetAll(int userId);

        Task<UserAddress> Create(UserAddress userAddress);

        Task<UserAddress> GetById(int addressId);

        Task<UserAddress> Update(UserAddress address);

        Task<bool> DeleteById(int addressId);
    }
}
