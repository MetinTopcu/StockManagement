using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using StockManagement.User.ApplicationContracts.ServiceContracts;
using StockManagement.User.Domain.DTOs;

namespace StockManagement.User.API.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<TokenDTO> Login(LoginDTO loginDto)
        {
            var result = await _authenticationService.LoginAsync(loginDto);

            return result;
        }

        [HttpPost("create-token-by-client")]
        public ClientTokenDTO CreateTokenByClient(ClientLoginDTO clientLoginDto)
        {
            var result = _authenticationService.CreateTokenByClient(clientLoginDto);

            return result;
        }

        [HttpPost("revoke-refresh-token")]
        public async Task<bool> RevokeRefreshToken(RefreshTokenDTO refreshTokenDto)
        {
            await _authenticationService.RevokeRefreshToken(refreshTokenDto.Token);

            return true;
        }

        [HttpPost("create-token-by-refresh-token")]
        public async Task<TokenDTO> CreateTokenByRefreshToken(RefreshTokenDTO refreshTokenDto)
        {
            var result = await _authenticationService.CreateTokenByRefreshToken(refreshTokenDto.Token);

            return result;
        }

    }
}
