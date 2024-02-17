using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_backend.Exceptions;
using shop_backend.Http.Requests.Auth;
using shop_backend.Http.Resources.User;
using shop_backend.Services.Auth.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop_backend.Http.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;

        public AuthController(
            IAuthService authService,
            ITokenService tokenService) 
        {
            _authService = authService;
            _tokenService = tokenService;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {

                var userResource = await _authService.Register(request);

                var tokens = _tokenService.CreateTokens(userResource.Email, userResource.Role.Name);
                await _tokenService.SaveRefreshToken(userResource.Id, tokens.RefreshToken);

                var cookieOptions = new CookieOptions
                {
                    Secure = true,
                    HttpOnly = true,
                    Expires = DateTime.UtcNow.AddDays(30),
                };

                Response.Cookies.Append(
                    "JwtRefreshToken",
                    tokens.RefreshToken,
                    cookieOptions);

                return Created("created", new { token = tokens.AccessToken, user = userResource});

            } catch (HttpException ex)
            {
                return StatusCode(ex.StatusCode, new { message = ex.Message });

            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserResource>> Login([FromBody] LoginRequest request)
        {
            try
            {
                var userResource = await _authService.Login(request);

                var tokens = _tokenService.CreateTokens(userResource.Email, userResource.Role.Name);
                await _tokenService.SaveRefreshToken(userResource.Id, tokens.RefreshToken);

                var cookieOptions = new CookieOptions
                {
                    Secure = true,
                    HttpOnly = true,
                    Expires = DateTime.UtcNow.AddDays(30),
                };

                Response.Cookies.Append(
                    "JwtRefreshToken",
                    tokens.RefreshToken,
                    cookieOptions); 

                return Ok(new {token = tokens.AccessToken, user = userResource});

            } catch (HttpException ex)
            {
                return StatusCode(ex.StatusCode, new { message = ex.Message });

            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var jwtRefreshToken = Request.Cookies["JwtRefreshToken"];

            await _authService.Logout(jwtRefreshToken);

            Response.Cookies.Delete("JwtRefreshToken");

            return NoContent();
        }

        //[Authorize()]
        [HttpPut("refresh")]
        public async Task<IActionResult> Refresh()
        {
            try
            {
                var jwtRefreshToken = Request.Cookies["JwtRefreshToken"];

                var verifiedUserResource = await _authService.Refresh(jwtRefreshToken);

                if (verifiedUserResource == null)
                {
                    return Unauthorized("Вы не авторизованы");
                }

                var tokens = _tokenService.CreateTokens(verifiedUserResource.Email, verifiedUserResource.Role.Name);
                await _tokenService.SaveRefreshToken(verifiedUserResource.Id, tokens.RefreshToken);

                var cookieOptions = new CookieOptions
                {
                    Secure = true,
                    HttpOnly = true,
                    Expires = DateTime.UtcNow.AddDays(30),
                };

                Response.Cookies.Append(
                    "JwtRefreshToken",
                    tokens.RefreshToken,
                    cookieOptions);

                return Ok(new { token = tokens.AccessToken });

            } catch (HttpException ex)
            {
                return Unauthorized();

            } catch (Exception ex)
            {
                return StatusCode(500, "Внутренняя ошибка сервера");
            }

        }
    }
}
