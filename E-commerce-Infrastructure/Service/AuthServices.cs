using E_commerce_core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_Infrastructure.Service
{
    public class AuthServices
    {
        private readonly IConfiguration configuration;
        // defined the call configuration from appsettings.json
        public AuthServices(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        //UserIdentity=>this is model
        public async Task<string> CreateTokenAsync(Users user,
       UserManager<Users> userManager)
        {
            //get configuration
            var configurations = configuration.GetSection("jwt")["secretKey"];
            var AuthClaim = new List<Claim>()
             {
                 new Claim(ClaimTypes.GivenName,user.UserName) ,
                 new Claim(ClaimTypes.Email,user.Email) ,
                 new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()) ,
             };
            var userRole = await userManager.GetRolesAsync(user);
            foreach (var role in userRole)
                AuthClaim.Add(new Claim(ClaimTypes.Role, role));
            var keyAuth = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configurations));
            var token = new JwtSecurityToken(
            //optinles
            audience: "project",
            issuer: "project Saif",
            //requierd
            claims: AuthClaim,
            signingCredentials: new SigningCredentials(keyAuth,
           SecurityAlgorithms.HmacSha256Signature),
            //can change dateTime
            expires: DateTime.UtcNow.AddDays(1)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
