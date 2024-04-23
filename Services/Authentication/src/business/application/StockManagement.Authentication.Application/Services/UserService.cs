using AutoMapper;
using Microsoft.AspNetCore.Identity;
using StockManagement.User.ApplicationContracts.ServiceContracts;
using StockManagement.User.Domain.DTOs;
using StockManagement.User.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.User.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(UserManager<UserApp> userManager, IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        public async Task<UserAppDTO> CreateUserAsync(CreateUserDTO createUserDto)
        {
            var user = new UserApp();

            if (createUserDto.Address != null && createUserDto.PhoneNumber != null)
            {
                user = new UserApp { Email = createUserDto.Email, Address = createUserDto.Address, PhoneNumber = createUserDto.PhoneNumber };
            }
            else if(createUserDto.Address != null && createUserDto.PhoneNumber is null)
            {
                user = new UserApp { Email = createUserDto.Email,Address = createUserDto.Address };
            }
            else if (createUserDto.PhoneNumber != null && createUserDto.Address is null)
            {
                user = new UserApp { Email = createUserDto.Email, PhoneNumber = createUserDto.PhoneNumber };
            }
            else
            {
                user = new UserApp { Email = createUserDto.Email };
            }

            var result = await _userManager.CreateAsync(user, createUserDto.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();

                throw new Exception(errors.ToString());
            }

            var userApp = _mapper.Map<UserAppDTO>(user);

            return userApp;
        }

        public async Task CreateUserRoles(CreateUserRolesDTO createUserRolesDTO)
        {
            var user = await _userManager.FindByIdAsync(createUserRolesDTO.UserId.ToString());

            //AspNetUserRoles tablosu
            await _userManager.AddToRoleAsync(user, createUserRolesDTO.Roles);

        }

        public async Task CreateRoles(CreateRolesDTO createRolesDTO)
        {
            //AspNetRoles tablosu
            if (!await _roleManager.RoleExistsAsync(createRolesDTO.Roles))
            {
                await _roleManager.CreateAsync(new() { Name = createRolesDTO.Roles });
            }

        }

        public async Task<UserAppDTO> GetUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) throw new Exception("Email not found");

            var userApp = _mapper.Map<UserAppDTO>(user);

            return userApp;
        }
    }
}
