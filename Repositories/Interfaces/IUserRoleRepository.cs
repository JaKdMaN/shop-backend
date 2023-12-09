using shop_backend.Models;
using System.Linq;
using System.Threading.Tasks;

namespace shop_backend.Repositories.Interfaces
{
    public interface IUserRoleRepository
    {
        IQueryable<UserRole> GetAll();

        Task<UserRole> GetById(int id);

    }
}
