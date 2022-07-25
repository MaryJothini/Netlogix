
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NTG.ShipmentManagement.Applicaiton.Constants;
using NTG.ShipmentManagement.Applicaiton.Contracts.Authentication;
using NTG.ShipmentManagement.Applicaiton.Models;
using NTG.ShipmentManagement.Applicaiton.UserLogin;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NTG.ShipmentManagement.Identity.Authentication
{
    public class AuthenticationService : IAuthenticatinService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly AuthSettings _authSettings;

        public AuthenticationService(UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager, IOptions<AuthSettings> authSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authSettings = authSettings.Value;
        }

        public async Task<LoginResponse> Login(UserLoginDto login)
        {
            var user = await _userManager.FindByNameAsync(login.UserName);

            if (user == null)
            {
                throw new Exception($"User with {login.UserName} not found.");
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, login.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                throw new Exception($"Credentials for '{login.UserName} aren't valid'.");
            }

            var jwtSecurityToken = await GetToken(user);

            var response = new LoginResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                UserName = user.UserName
            };

            return response;
        }
        private async Task<JwtSecurityToken> GetToken(IdentityUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(NtgClaimTypes.UserId, user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _authSettings.Issuer,
                audience: _authSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_authSettings.ExpireInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }
    }
}
