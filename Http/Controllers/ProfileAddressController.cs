using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shop_backend.Exceptions;
using shop_backend.Http.Requests.Address;
using shop_backend.Http.Resources.Address;
using shop_backend.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace shop_backend.Http.Controllers
{
    [Authorize]
    [Route("api/profile/addresses")]
    [ApiController]
    public class ProfileAddressController : ControllerBase
    {

        private readonly IAddressService _addressService;

        public ProfileAddressController(IAddressService addressService) 
        {
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AddressResource>>> GetAdresses()
        {
            try
            {
                var jwtRefreshToken = Request.Cookies["JwtRefreshToken"];

                var addressCollectionResource = await _addressService.GetAll(jwtRefreshToken);

                return Ok(addressCollectionResource);

            }
            catch (HttpException ex)
            {
                return StatusCode(ex.StatusCode, new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<AddressResource>> CreateAddress(AddressCreateRequest address)
        {
            try
            {
                var addressResource = await _addressService.Create(address);

                return Created("created", addressResource);

            } catch (HttpException ex)
            {
                return StatusCode(ex.StatusCode, new {message = ex.Message});
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AddressResource>> UpdateAddress(int id, AddressUpdateRequest address)
        {
            try
            {
                var addressResource = await _addressService.Update(id, address);

                return addressResource;

            }
            catch (HttpException ex)
            {
                return StatusCode(ex.StatusCode, new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAddress(int id)
        {
            try
            {
                await _addressService.Delete(id);

                return NoContent();

            } catch (HttpException ex)
            {
                return StatusCode(ex.StatusCode, new { message = ex.Message });
            }
        }
    }
}
