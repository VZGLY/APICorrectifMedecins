using BLL.Interfaces;
using DAL.Entities;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    
    public class JwtService : IJwtService
    {

        private readonly string SecretKey;

        private readonly string ExpiresDays;

        public JwtService(string secretKey, string expiresDays)
        {
            SecretKey = secretKey;
            ExpiresDays = expiresDays;
        }

        public string CreateToken(Doctor doctor)
        {
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));

            var Credentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            List<Claim> Claims = new List<Claim>();

            Claims.Add(new Claim(ClaimTypes.NameIdentifier, doctor.Id.ToString()));

            var token = new JwtSecurityToken(claims: Claims, expires: DateTime.Now.AddDays(Convert.ToUInt32(ExpiresDays)),signingCredentials: Credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
