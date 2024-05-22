using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ZZTicaret.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        readonly IConfiguration _configuration;

        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("{Token}")]
        public async Task<IActionResult> GetToken(string Token)
        {
            if (Token != "123") return Unauthorized("Şifre geçersiz.");
            string token = GenerateToken();
            return Ok(token);
        }

        private string GenerateToken()
        {
            var rsa = RSA.Create();
            rsa.ImportRSAPrivateKey(Convert.FromBase64String(_configuration["JwtTokenOptions:PrivateKey"]), out _);

            var claims = new List<Claim>()
            {
                new Claim("sub", "fkoseoglu"),
                new Claim("name", "fatih koseoglu")
            };

            var roleClaims = new List<Claim>()
            {
                new Claim("role", "readers"),
                new Claim("role", "writers"),
            };

            claims.AddRange(roleClaims);

            var handler = new JsonWebTokenHandler();
            var now = DateTime.UtcNow;
            var tokenData = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _configuration["JwtTokenOptions:Issuer"],
                Audience = _configuration["JwtTokenOptions:Audience"],
                IssuedAt = now,
                NotBefore = now,
                Subject = new ClaimsIdentity(claims),
                Expires = now.AddMinutes(double.Parse(_configuration["JwtTokenOptions:Expiration"])),
                SigningCredentials = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSsaPssSha256)
            });
            return tokenData;


                

        }
    }
}
