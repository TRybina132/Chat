using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.Interfaces.Handlers
{
    public interface IJwtHandler
    {
        SigningCredentials GetSigningCredentials();
        List<Claim> GetClaims(IdentityUser<int> user);
        JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims);
    }
}
