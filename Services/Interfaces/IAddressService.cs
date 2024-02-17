using shop_backend.Http.Requests.Address;
using shop_backend.Http.Resources.Address;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace shop_backend.Services.Interfaces
{
    public interface IAddressService
    {
        Task<ICollection<AddressResource>> GetAll(string jwtRefreshToken);

        Task<AddressResource> Create(AddressCreateRequest address);

        Task<AddressResource> GetById(int id);

        Task<AddressResource> Update(int id, AddressUpdateRequest address);

        Task<bool> Delete(int id);
    }
}
