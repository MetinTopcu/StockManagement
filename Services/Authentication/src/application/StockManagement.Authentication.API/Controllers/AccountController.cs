using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StockManagement.User.ApplicationContracts.ServiceContracts;
using StockManagement.User.Domain.DTOs;
using StockManagement.User.Domain.Entities;

namespace StockManagement.User.API.Controllers
{
    [Route("account")]
    [Authorize]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<UserAppDTO> Register(CreateUserDTO createUserDto)
        {
            var result = await _userService.CreateUserAsync(createUserDto);
            return result;
        }


        [HttpGet("get-user-by-name")]
        public async Task<UserAppDTO> GetUserByNameAsync()
        {
            //var email = HttpContext.User.Claims.Where(x => x.Type == "email").FirstOrDefault();
            var result = await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name);
            return result;
        }

        [HttpPost("create-user-role")]
        [AllowAnonymous]
        public async Task<bool> CreateUserRole(CreateUserRolesDTO createUserRolesDTO)
        {
            await _userService.CreateUserRoles(createUserRolesDTO);

            return true;
        }
        [HttpPost("create-role")]
        [AllowAnonymous]
        public async Task<bool> CreateRole(CreateRolesDTO createRolesDTO)
        {
            await _userService.CreateRoles(createRolesDTO);
            return true;
        }
    }
}
