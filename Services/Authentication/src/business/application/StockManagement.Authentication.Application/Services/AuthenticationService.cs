using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Options;
using StockManagement.Shared.Domain.Interfaces.Repository;
using StockManagement.Shared.Domain.Interfaces.UnitOfWork;
using StockManagement.User.ApplicationContracts.ServiceContracts;
using StockManagement.User.Domain.Configuration;
using StockManagement.User.Domain.DTOs;
using StockManagement.User.Domain.Entities;
using StockManagement.User.Domain.RepositoryContracts;
using StockManagement.User.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.User.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly List<Client> _clients;
        private readonly ITokenService _tokenService;
        private readonly UserManager<UserApp> _userManager;
        private readonly IUnitOfWork<UserDbContext> _unitOfWork;
        private readonly IUserRefreshTokenRepository _userRefreshTokenRepository;

        public AuthenticationService(IOptions<List<Client>> optionsClient, ITokenService tokenService, UserManager<UserApp> userManager, IUnitOfWork<UserDbContext> unitOfWork, IUserRefreshTokenRepository userRefreshTokenRepository)
        {
            _clients = optionsClient.Value;
            _tokenService = tokenService;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _userRefreshTokenRepository = userRefreshTokenRepository;
        }

        public async Task<TokenDTO> LoginAsync(LoginDTO loginDto) //login
        {
            var cancellationToken = new CancellationToken();
            await _unitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                if (loginDto == null) throw new ArgumentNullException(nameof(loginDto));

                var user = await _userManager.FindByEmailAsync(loginDto.Email);

                if (user == null) throw new Exception("Email or Password is wrong");

                if (!await _userManager.CheckPasswordAsync(user, loginDto.Password)) throw new Exception("Email or Password is wrong");

                var token = await _tokenService.CreateTokenAsync(user);

                var userRefreshToken = await _userRefreshTokenRepository.GetRefreshTokenAsyncByUser(user,cancellationToken);

                if (userRefreshToken == null)
                {
                    await _userRefreshTokenRepository.InsertOneAsync(new UserRefreshToken
                    {
                        Id = new Guid(user.Id),
                        Code = token.RefreshToken,
                        Expiration = token.RefrestTokenExpiration
                    }, cancellationToken);
                }
                else
                {
                    userRefreshToken.Code = token.RefreshToken;
                    userRefreshToken.Expiration = token.RefrestTokenExpiration;
                }

                await _unitOfWork.CommitAsync(cancellationToken);

                return token;
            }
            catch(Exception)
            {
                await _unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public ClientTokenDTO CreateTokenByClient(ClientLoginDTO clientLoginDto)
        {
            _unitOfWork.BeginTransaction();
            try
            {
                var client = _clients.SingleOrDefault(x => x.Id == clientLoginDto.ClientId && x.Secret == clientLoginDto.ClientSecret);

                if (client == null)
                {
                    throw new Exception("ClientId or ClientSecret not found");
                }

                var token = _tokenService.CreateTokenByClient(client);

                _unitOfWork.Commit();

                return token;
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        public async Task<TokenDTO> CreateTokenByRefreshToken(string refreshToken)
        {
            var cancellationToken = new CancellationToken();
            await _unitOfWork.BeginTransactionAsync(cancellationToken);

            try
            {
                var existRefreshToken = await _userRefreshTokenRepository.GetRefreshTokenAsync(refreshToken);

                if (existRefreshToken == null) throw new Exception("Refresh token not found");

                var user = await _userManager.FindByIdAsync(existRefreshToken.Id.ToString());

                if (user == null) throw new Exception("User not found");

                var tokenDto = await _tokenService.CreateTokenAsync(user);

                existRefreshToken.Code = tokenDto.RefreshToken;
                existRefreshToken.Expiration = tokenDto.RefrestTokenExpiration;

                await _unitOfWork.CommitAsync(cancellationToken);

                return tokenDto;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task RevokeRefreshToken(string refreshToken)
        {
            var cancellationToken = new CancellationToken();
            await _unitOfWork.BeginTransactionAsync(cancellationToken);

            try
            {
                var existRefreshToken = await _userRefreshTokenRepository.WhereAsync(x => x.Code == refreshToken);

                if (existRefreshToken == null) throw new Exception("Refresh token not found");

                foreach (var item in existRefreshToken)
                {
                    _userRefreshTokenRepository.DeleteOne(item);

                }
                await _unitOfWork.CommitAsync(cancellationToken);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

    }
}
