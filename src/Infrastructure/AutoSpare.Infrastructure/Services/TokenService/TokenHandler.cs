using AutoSpare.Application.Abstractions.TokenAbstraction;
using AutoSpare.Application.DTOs;
using AutoSpare.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AutoSpare.Infrastructure.Services.TokenService
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public TokenHandler(IConfiguration configuration, RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _configuration = configuration;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        //public async Task<Token> CreateAccessToken(AppUser user)
        //{
        //  var userRoles=  await _userManager.GetRolesAsync(user);
        //    Token token = new();
        //    SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
        //    SigningCredentials signInCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);
        //    token.Expiration = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["Token:TokenExpiration"]));
        //    var ClaimList=new List<Claim>();
        //    foreach (var role in userRoles)
        //    {
        //        ClaimList.Add(new Claim(ClaimTypes.Role, role));
        //    }
        //    ClaimList.Add(new(ClaimTypes.Name, user.UserName));
        //    JwtSecurityToken securityToken = new(
        //        audience: _configuration["Token:Audience"],
        //        issuer: _configuration["Token:Issuer"],
        //        expires: token.Expiration,
        //        notBefore: DateTime.Now,
        //        signingCredentials: signInCredentials,
        //        claims:ClaimList
        //        );
        //    JwtSecurityTokenHandler tokenHandler = new();
        //    token.AccessToken = tokenHandler.WriteToken(securityToken);
        //    token.RefreshToken = CreateRefreshToken();
        //    return token;
        //} 
        public async Task<Token> CreateAccessToken(AppUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            Token token = new();
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            SigningCredentials signInCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);
            token.Expiration = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["Token:TokenExpiration"]));
            var ClaimList = new List<Claim>();

            // Add roles to claims
            foreach (var role in userRoles)
            {
                ClaimList.Add(new Claim(ClaimTypes.Role, role));
            }

            // Add username to claims
            ClaimList.Add(new(ClaimTypes.Name, user.UserName));

            // Add companyId to claims
            ClaimList.Add(new("companyId", user.CompanyId.ToString()));

            JwtSecurityToken securityToken = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: token.Expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: signInCredentials,
                claims: ClaimList
            );

            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);
            token.RefreshToken = CreateRefreshToken();

            return token;
        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(number);
            return Convert.ToBase64String(number);
        }
    }
}
