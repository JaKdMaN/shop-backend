using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using shop_backend.Exceptions;
using System.Threading.Tasks;
using shop_backend.Services.Interfaces;
using System;

namespace shop_backend.Http.Controllers
{

    [Route("api/me")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetMe()
        {
            try
            {
                var jwtRefreshToken = Request.Cookies["JwtRefreshToken"];

                var userResource = await _userService.GetMe(jwtRefreshToken);

                return Ok(userResource);

            } catch (HttpException ex)
            {
                return StatusCode(ex.StatusCode, new { message = ex.errorMessage });

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
