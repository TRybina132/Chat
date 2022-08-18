using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Net.Sockets;
using System.Text;

namespace Chat.Configurations
{
    public static class AuthConfiguration
    {
        private static JwtBearerOptions GetJwtConfiguration(IConfiguration configuration)
        {
            var jwtProperties = configuration.GetSection("JWTConfig");

            var jwtOptions = new JwtBearerOptions();

            jwtOptions.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtProperties["ValidIssuer"],
                ValidAudience = jwtProperties["ValidAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtProperties["SecretKey"]))
            };

            return jwtOptions;
        }
            
        public static void ConfigureAuthentication(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer();
        }
    }
}
