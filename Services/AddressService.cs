using AutoMapper;
using Microsoft.EntityFrameworkCore;
using shop_backend.Exceptions;
using shop_backend.Http.Requests.Address;
using shop_backend.Http.Resources.Address;
using shop_backend.Models;
using shop_backend.Repositories.Interfaces;
using shop_backend.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace shop_backend.Services
{
    public class AddressService : IAddressService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IUserAddressRepository _userAddressRepository;

        public AddressService (
            IMapper mapper,
            IUserRepository userRepository,
            IUserAddressRepository userAddressRepository
            )
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userAddressRepository = userAddressRepository;
        }

        public async Task<ICollection<AddressResource>> GetAll(string jwtRefreshToken)
        {
            var user = await _userRepository.GetByToken(jwtRefreshToken);

            if (user == null)
            {
                throw new HttpException("Вы не авторизованы", 401);
            }

            var addressCollection = await _userAddressRepository.GetAll(user.Id).ToListAsync();
            var addressCollectionResource = _mapper.Map<ICollection<AddressResource>>(addressCollection);

            return addressCollectionResource;
        }

        public async Task<AddressResource> Create(AddressCreateRequest address)
        {
            var user = await _userRepository.GetByEmail(address.Email);

            if (user == null)
            {
                throw new HttpException("Вы не авторизованы", 401);
            }
            var newAddress = await _userAddressRepository.Create(new UserAddress
            {
                Name = address.Name,
                Surname = address.Surname,
                Email = address.Email,
                PhoneNumber = address.PhoneNumber,
                CompanyName = address.CompanyName,
                Country = address.Country,
                Street = address.Street,
                HouseAndApartmentNumber = address.HouseAndApartmentNumber,
                City = address.City,
                Region = address.Region,
                Postcode = address.Postcode,
                UserId = user.Id,
            });

            var addressResource = _mapper.Map<AddressResource>(newAddress);

            return addressResource;
        }

        public async Task<AddressResource> GetById(int id)
        {
            var address = await _userAddressRepository.GetById(id);
            var addressResource = _mapper.Map<AddressResource>(address);

            return addressResource;
        }

        public async Task<AddressResource> Update(int id, AddressUpdateRequest address)
        {
            var addressToUpdate = await _userAddressRepository.GetById(id);

            if (addressToUpdate == null)
            {
                throw new HttpException("Такого адреса не существует", 400);
            }

            addressToUpdate.Name = address.Name;
            addressToUpdate.Surname = address.Surname;
            addressToUpdate.Email = address.Email;
            addressToUpdate.PhoneNumber = address.PhoneNumber;
            addressToUpdate.CompanyName = address.CompanyName;
            addressToUpdate.Country = address.Country;
            addressToUpdate.Street = address.Street;
            addressToUpdate.HouseAndApartmentNumber = address.HouseAndApartmentNumber;
            addressToUpdate.City = address.City;
            addressToUpdate.Region = address.Region;
            addressToUpdate.Postcode = address.Postcode;

            var addressResource = _mapper.Map<AddressResource>(addressToUpdate);

            return addressResource;
        }

        public async Task<bool> Delete(int id)
        {
            var address = await _userAddressRepository.GetById(id);

            if ( address == null )
            {
                throw new HttpException("Такого адреса не существует", 400);
            }

            return await _userAddressRepository.DeleteById(id);
        }
    }
}
