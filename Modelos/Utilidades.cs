using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using API_Camiones.Modelos;


namespace API_Camiones.Modelos
{
    public class Utilidades
    {
        private readonly IConfiguration _configuration;
        public Utilidades(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string encriptSHA256(string text)
        {
            using (SHA256 sha256hash = SHA256.Create()) {

                byte[] bytes = sha256hash.ComputeHash(Encoding.UTF8.GetBytes(text));

                //convertir el array de bytes
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++) { 
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public string generateJWT(User model)
        {
            //create information for the token
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, model.IdUser.ToString()),
                new Claim(ClaimTypes.Email, model.Correo!)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            //creation of token details
            var jwetConfig = new JwtSecurityToken(
                claims: userClaims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(jwetConfig);

        }

    
    
    }
}
