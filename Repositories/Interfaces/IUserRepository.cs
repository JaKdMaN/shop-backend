using shop_backend.Models;
using System.Linq;
using System.Threading.Tasks;

namespace shop_backend.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Create(User entity);

        IQueryable<User> GetAll();

        Task<User> GetById(int id);

        Task<User> GetByToken(string token);

        Task<User> Update(User entity);

        Task<bool> Delete(User entity);

    }
}
