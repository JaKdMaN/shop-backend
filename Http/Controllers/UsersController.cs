using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop_backend.Database;
using shop_backend.Http.Resources.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace shop_backend.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ShopDbContext _db;
        private readonly IMapper _mapper;
        public UsersController(ShopDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResource>>> GetUsers()
        {
            var users = await _db.users.Include(u => u.UserRole).ToListAsync();

            var userResource = _mapper.Map<IEnumerable<UserResource>>(users);

            return Ok(userResource);
        }
    }
}