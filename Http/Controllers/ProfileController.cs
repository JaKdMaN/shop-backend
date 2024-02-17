using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using shop_backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using shop_backend.Http.Resources.User;
using shop_backend.Exceptions;
using shop_backend.Http.Requests.User;

namespace shop_backend.Controllers
{
    [Authorize]
    [Route("api/profile")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet]
        public async Task<ActionResult<ProfileResource>> GetProfile()
        {
            try
            {
                var jwtRefreshToken = Request.Cookies["JwtRefreshToken"];

                var profileResource = await _profileService.GetProfile(jwtRefreshToken);

                return Ok(profileResource);

            } catch (HttpException ex)
            {
                return StatusCode(ex.StatusCode, new { message = ex.Message });
            }

        }

        [HttpPut]
        public async Task<ActionResult<ProfileResource>> UpdateProfile(ProfileUpdateRequest profile)
        {
            try
            {
                var profileResource = await _profileService.UpdateProfile(profile);

                return Ok(profileResource);

            } catch (HttpException ex)
            {
                return StatusCode(ex.StatusCode, new { message = ex.Message });
            }
        }

        [HttpGet("orders")]
        public IActionResult GetOrders()
        {
            return Ok();
        }

        [HttpGet("orders-history")]
        public IActionResult GetOrdersHistory()
        {
            return Ok();
        }
    }
}