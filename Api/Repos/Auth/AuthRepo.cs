using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Api.Data;
using Api.DTOs.Auth;
using Api.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Api.Repos.Auth
{
    public class AuthRepo : IAuthRepo
    {
        private readonly DatingAppDbContext datingAppDbContext;
        private readonly IConfiguration configuration;
        public AuthRepo(DatingAppDbContext datingAppDbContext, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.datingAppDbContext = datingAppDbContext;
        }

        public Token loginUser(Login login)
        {
            login.Nombre = login.Nombre.ToLower();
            var userDb = datingAppDbContext.Usuarios.FirstOrDefault(x => x.Username == login.Nombre);
            if (userDb == null)
            {
                return null;
            }
            if (!Decypt(login.Clave, userDb.Hash, userDb.Salt))
            {
                return null;
            }
            string myToken = BuildToken(userDb);
            Token tokenObj = new Token(){
                myToken = myToken
            };
            return tokenObj;
        }

        private string BuildToken(Usuario userDb)
        {
            var myClaims = new[]{
                new Claim(ClaimTypes.NameIdentifier, userDb.Document),
                new Claim(ClaimTypes.Name, userDb.Username)
            };
            var myKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes
                (configuration.GetSection("Key:Token").Value));
            var mySigningCreds = new SigningCredentials(myKey, SecurityAlgorithms.HmacSha512Signature);

            var myTokenDescriptor = new SecurityTokenDescriptor(){
                Subject = new ClaimsIdentity(myClaims),
                SigningCredentials = mySigningCreds,
                Expires = DateTime.Now.AddDays(1)
            };
            var myTokenHandler = new JwtSecurityTokenHandler();
            var myToken = myTokenHandler.CreateToken(myTokenDescriptor);
            return myTokenHandler.WriteToken(myToken);
        }

        private bool Decypt(string clave, byte[] hash, byte[] salt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(salt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(clave));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != hash[i]) { return false; }
                }
            }
            return true;
        }

        public bool registerUser(Register register)
        {
            register.Nombre = register.Nombre.ToLower();
            if (datingAppDbContext.Usuarios.Any(x => x.Username == register.Nombre)) { return false; }
            byte[] myHash, mySalt;
            Encyrpt(register.Clave, out myHash, out mySalt);
            Usuario usuario = new Usuario()
            {
                Document = register.Document,
                Username = register.Nombre,
                Hash = myHash,
                Salt = mySalt
            };
            datingAppDbContext.Usuarios.Add(usuario);
            datingAppDbContext.SaveChanges();
            return true;
        }

        private void Encyrpt(string clave, out byte[] myHash, out byte[] mySalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                myHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(clave));
                mySalt = hmac.Key;
            }
        }
    }
}