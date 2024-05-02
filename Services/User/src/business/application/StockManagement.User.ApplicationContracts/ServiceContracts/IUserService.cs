using StockManagement.User.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.User.ApplicationContracts.ServiceContracts
{
    public interface IUserService
    {
        Task<UserAppDTO> CreateUserAsync(CreateUserDTO createUserDto);
        Task<UserAppDTO> GetUserByNameAsync(string userName);
        Task CreateUserRoles(CreateUserRolesDTO createUserRolesDTO);
        Task CreateRoles(CreateRolesDTO createRolesDTO);
    }
}
