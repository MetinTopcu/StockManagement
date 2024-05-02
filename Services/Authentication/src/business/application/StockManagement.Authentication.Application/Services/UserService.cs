using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using StockManagement.Shared.Domain.Interfaces.UnitOfWork;
using StockManagement.User.ApplicationContracts.ServiceContracts;
using StockManagement.User.Domain.DTOs;
using StockManagement.User.Domain.Entities;
using StockManagement.User.Infrastructure;
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
        private readonly IUnitOfWork<UserDbContext> _unitOfWork;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(UserManager<UserApp> userManager, IMapper mapper, RoleManager<IdentityRole> roleManager, IUnitOfWork<UserDbContext> unitOfWork)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserAppDTO> CreateUserAsync(CreateUserDTO createUserDto) //register
        {
            var cancellationToken = new CancellationToken();
            await _unitOfWork.BeginTransactionAsync(cancellationToken);

            try
            {
                var user = new UserApp();

                user = new UserApp { Email = createUserDto.Email, Address = createUserDto.Address, Name = createUserDto.Name, Surname = createUserDto.Surname, PhoneNumber = createUserDto.PhoneNumber, UserName = createUserDto.UserName };
                

                var result = await _userManager.CreateAsync(user, createUserDto.Password);

                if (!result.Succeeded)
                {
                    var errors = result.Errors.Select(x => x.Description).ToList();

                    throw new Exception(errors.ToString());
                }

                var userApp = _mapper.Map<UserAppDTO>(user);

                await _unitOfWork.CommitAsync(cancellationToken);

                return userApp;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task CreateUserRoles(CreateUserRolesDTO createUserRolesDTO)
        {
            var cancellationToken = new CancellationToken();
            await _unitOfWork.BeginTransactionAsync(cancellationToken);

            try
            {
                var user = await _userManager.FindByIdAsync(createUserRolesDTO.UserId.ToString());

                //AspNetUserRoles tablosu
                await _userManager.AddToRoleAsync(user, createUserRolesDTO.Roles);

                await _unitOfWork.CommitAsync(cancellationToken);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task CreateRoles(CreateRolesDTO createRolesDTO)
        {
            var cancellationToken = new CancellationToken();
            await _unitOfWork.BeginTransactionAsync(cancellationToken);

            try
            {
                //AspNetRoles tablosu
                if (!await _roleManager.RoleExistsAsync(createRolesDTO.Roles))
                {
                    await _roleManager.CreateAsync(new() { Name = createRolesDTO.Roles });
                }
                await _unitOfWork.CommitAsync(cancellationToken);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync(cancellationToken);
                throw;
            } 
        }

        public async Task<UserAppDTO> GetUserByNameAsync(string userName)
        {
            var cancellationToken = new CancellationToken();
            await _unitOfWork.BeginTransactionAsync(cancellationToken);

            try
            {
                var user = await _userManager.FindByNameAsync(userName);

                //var user = await _userManager.FindByEmailAsync(email);

                if (user == null) throw new Exception("Email not found");

                var userApp = _mapper.Map<UserAppDTO>(user);

                await _unitOfWork.CommitAsync(cancellationToken);

                return userApp;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }

            
        }
    }
}
