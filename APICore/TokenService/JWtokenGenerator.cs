using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using APICore.ModelService;
using APICore.TokenService;
using APICore.DataModelService;

namespace APICore.TokenService
{
    public class JWtokenGenerator : IJWtokenGenerator
    {
        private readonly AppSettings _appConfig;
        private readonly UserManager<ApplicationUser> _userManager;

        public JWtokenGenerator(IOptions<AppSettings> appConfig, UserManager<ApplicationUser> userManager)
        {
            _appConfig = appConfig.Value;
            _userManager = userManager;
        }

        public async Task<string> GenerateToken(ApplicationUser user)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            claims.Add(new Claim(ClaimTypes.Name, user.FirstName));
            claims.Add(new Claim(ClaimTypes.Surname, user.LastName));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.GivenName, user.UserName));


            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appConfig.Key));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(Convert.ToDouble(_appConfig.TokenExpiry)),
                SigningCredentials = creds,
                Issuer = _appConfig.Issuer
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

    }

}