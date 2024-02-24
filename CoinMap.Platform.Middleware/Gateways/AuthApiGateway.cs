using CoinMap.Platform.Infrastructure.Auth;
using CoinMap.Platform.Middleware.Dto;
using CoinMap.Platform.Middleware.Enums;
using CoinMap.Platform.Middleware.Extensions;
using CoinMap.Platform.Middleware.Patterns.Proxy.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CoinMap.Platform.Middleware.Gateways
{
    internal class AuthApiGateway : IAuthProxy
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<ApplicationRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthApiGateway(IServiceProvider provider)
        {
            IServiceScope scope = provider.CreateScope();

            this._userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            this._roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            this._configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
        }

        public async Task<AuthDto> Login(UserDto user)
        {
            var appUser = await this._userManager.FindByNameAsync(user.UserName);

            if (appUser == null)
            {
                return new AuthDto { Login = new LoginDto { Status = AuthStatusEnum.InvalidUsername, Message = AuthStatusEnum.InvalidUsername.ToDescription() } };
            }

            if (!await this._userManager.CheckPasswordAsync(appUser, user.Password)) 
            {
                return new AuthDto { Login = new LoginDto { Status = AuthStatusEnum.InvalidPassword, Message = AuthStatusEnum.InvalidPassword.ToDescription() } };
            }

            var userRoles = await this._userManager.GetRolesAsync(appUser);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            string token = GenerateToken(authClaims);

            if (string.IsNullOrEmpty(token)) 
            {
                return new AuthDto { Login = new LoginDto { Status = AuthStatusEnum.InvalidToken, Message = AuthStatusEnum.InvalidToken.ToDescription() } };
            }

            return new AuthDto { Login = new LoginDto { Status = AuthStatusEnum.TokenCreatedSuccessfully, Message = AuthStatusEnum.TokenCreatedSuccessfully.ToDescription(), Token = token } };
        }

        public async Task<AuthDto> Registration(UserDto user)
        {
            var userExists = await this._userManager.FindByNameAsync(user.UserName);

            if (userExists != null)
            {
                return new AuthDto { Register = new RegisterDto { Status = AuthStatusEnum.UserAlreadyExists, Message = AuthStatusEnum.UserAlreadyExists.ToDescription() } };
            }

            ApplicationUser appUser = new ApplicationUser { UserName = user.UserName, Email = user.Email };

            var createUserResult = await this._userManager.CreateAsync(appUser, user.Password);

            if (!createUserResult.Succeeded) 
            {
                return new AuthDto { Register = new RegisterDto { Status = AuthStatusEnum.UserAlreadyExists, Message = AuthStatusEnum.UserCreationFailed.ToDescription() } };
            }

            if (!await this._roleManager.RoleExistsAsync(user.Role)) 
            {
                await this._roleManager.CreateAsync(new ApplicationRole { Name = user.Role });
            }

            await this._userManager.AddToRoleAsync(appUser, user.Role);

            return new AuthDto { Register = new RegisterDto { Status = AuthStatusEnum.UserCreatedSuccessfully, Message = AuthStatusEnum.UserCreatedSuccessfully.ToDescription() } };
        }

        private string GenerateToken(IEnumerable<Claim> claims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecurityKey"]));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["JWT:Issuer"],
                Audience = _configuration["JWT:Audience"],
                Expires = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["JWT:Expires"])),
                SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
